using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;

namespace KronosExternalScanner
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, int size, out int bytesRead);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);

        const int PROCESS_VM_READ = 0x0010;
        const int PROCESS_QUERY_INFORMATION = 0x0400;

        private Process TargetProcess;
        private IntPtr TargetBaseAddress;
        private readonly List<string> matchesFound = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxProcesses.Items.Clear();
            foreach (var p in Process.GetProcesses())
                comboBoxProcesses.Items.Add($"{p.ProcessName}:{p.Id}");
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (comboBoxProcesses.SelectedItem == null) return;

            string processName = comboBoxProcesses.SelectedItem.ToString().Split(':')[0];
            int processId = int.Parse(comboBoxProcesses.SelectedItem.ToString().Split(':')[1]);

            TargetProcess = Process.GetProcessById(processId);
            TargetBaseAddress = TargetProcess.MainModule.BaseAddress;

            labelModuleInfo.Text = $"{TargetProcess.MainModule.ModuleName} loaded at 0x{TargetBaseAddress.ToInt64():X}";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBoxResults.Items.Clear();
            matchesFound.Clear();
        }

        private byte?[] PatternToBytes(string pattern)
        {
            string[] patternParts = pattern.Split(' ');
            var patternBytes = new byte?[patternParts.Length];

            for (int i = 0; i < patternParts.Length; i++)
            {
                if (patternParts[i] == "?" || patternParts[i] == "??")
                    patternBytes[i] = null;
                else
                    patternBytes[i] = Convert.ToByte(patternParts[i], 16);
            }
            return patternBytes;
        }

        private void buttonScan_Click(object sender, EventArgs e)
        {
            matchesFound.Clear();
            listBoxResults.Items.Clear();

            if (TargetProcess == null || TargetProcess.HasExited)
            {
                MessageBox.Show("Select a valid target process first.");
                return;
            }

            string patternTextbox = textBoxPattern.Text.Trim();
            if (string.IsNullOrEmpty(patternTextbox))
            {
                MessageBox.Show("Please input a valid pattern.");
                return;
            }

            byte?[] pattern = PatternToBytes(patternTextbox);
            IntPtr hProcess = OpenProcess(PROCESS_VM_READ | PROCESS_QUERY_INFORMATION, false, TargetProcess.Id);

            if (hProcess == IntPtr.Zero)
            {
                MessageBox.Show("Failed to open process.");
                return;
            }

            byte[] moduleBytes = new byte[TargetProcess.MainModule.ModuleMemorySize];
            int bytesRead;

            bool result = ReadProcessMemory(hProcess, TargetBaseAddress, moduleBytes, moduleBytes.Length, out bytesRead);
            CloseHandle(hProcess);

            if (!result || bytesRead <= 0)
            {
                MessageBox.Show("Failed to read process memory.");
                return;
            }

            for (int idx = 0; idx <= moduleBytes.Length - pattern.Length; idx++)
            {
                bool found = true;
                for (int p = 0; p < pattern.Length; p++)
                {
                    if (pattern[p].HasValue && moduleBytes[idx + p] != pattern[p].Value)
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    string match = $"0x{(TargetBaseAddress.ToInt64() + idx):X}";
                    matchesFound.Add(match);
                    listBoxResults.Items.Add(match);
                }
            }

            if (matchesFound.Count == 0)
                listBoxResults.Items.Add("No matches found!");
        }

        private void buttonExportJSON_Click_1(object sender, EventArgs e)
        {
            if (TargetProcess == null || matchesFound.Count == 0)
            {
                MessageBox.Show("No scan results to export. Perform a scan first.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                FileName = $"ScanResults_{TargetProcess.ProcessName}.json"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var exportData = new
                {
                    ProcessName = TargetProcess.ProcessName,
                    ProcessId = TargetProcess.Id,
                    SignaturePattern = textBoxPattern.Text.Trim(),
                    ModuleName = TargetProcess.MainModule.ModuleName,
                    ModuleBaseAddress = $"0x{TargetBaseAddress.ToInt64():X}",
                    Matches = matchesFound
                };

                var jsonOptions = new JsonSerializerOptions() { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(exportData, jsonOptions);
                File.WriteAllText(sfd.FileName, jsonString);
                MessageBox.Show("Results successfully exported to JSON");
            }
        }

    }
}

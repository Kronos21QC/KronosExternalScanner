using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace KronosExternalScanner
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        // WinAPI imports
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

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxProcesses.Items.Clear();
            foreach (var p in Process.GetProcesses())
            {
                comboBoxProcesses.Items.Add($"{p.ProcessName}:{p.Id}");
            }
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (comboBoxProcesses.SelectedItem != null)
            {
                string processInfo = comboBoxProcesses.SelectedItem.ToString();
                string processName = processInfo.Split(':')[0];
                int processId = int.Parse(processInfo.Split(':')[1]);

                TargetProcess = Process.GetProcessById(processId);
                TargetBaseAddress = TargetProcess.MainModule.BaseAddress;

                labelModuleInfo.Text = $"{TargetProcess.MainModule.ModuleName} loaded at 0x{TargetBaseAddress.ToInt64():X}";
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBoxResults.Items.Clear();
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
            if (TargetProcess == null || TargetProcess.HasExited)
            {
                MessageBox.Show("Please select a valid target process first.");
                return;
            }

            string patternTextbox = textBoxPattern.Text.Trim();
            if (string.IsNullOrEmpty(patternTextbox))
            {
                MessageBox.Show("Please input a valid pattern first.");
                return;
            }

            byte?[] pattern = PatternToBytes(patternTextbox);

            IntPtr hProcess = OpenProcess(PROCESS_VM_READ | PROCESS_QUERY_INFORMATION, false, TargetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                MessageBox.Show("Failed to open target process!");
                return;
            }

            byte[] moduleBytes = new byte[TargetProcess.MainModule.ModuleMemorySize];
            int bytesRead;

            bool result = ReadProcessMemory(hProcess, TargetBaseAddress, moduleBytes, moduleBytes.Length, out bytesRead);

            if (!result || bytesRead == 0)
            {
                MessageBox.Show("Failed to read module memory!");
                CloseHandle(hProcess);
                return;
            }

            CloseHandle(hProcess);

            int matchCount = 0;
            for (int idx = 0; idx < moduleBytes.Length - pattern.Length; idx++)
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
                    matchCount++;
                    listBoxResults.Items.Add($"Match {matchCount}: 0x{(TargetBaseAddress.ToInt64() + idx):X}");
                }
            }

            if (matchCount == 0)
            {
                listBoxResults.Items.Add("No match found!");
            }
        }

        
    }
}

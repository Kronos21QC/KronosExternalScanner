namespace KronosExternalScanner
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelModuleInfo = new System.Windows.Forms.Label();
            this.textBoxPattern = new MetroFramework.Controls.MetroTextBox();
            this.buttonScan = new MetroFramework.Controls.MetroButton();
            this.buttonClear = new MetroFramework.Controls.MetroButton();
            this.buttonSelect = new MetroFramework.Controls.MetroButton();
            this.listBoxResults = new MetroFramework.Controls.MetroListView();
            this.comboBoxProcesses = new MetroFramework.Controls.MetroComboBox();
            this.buttonExportJSON = new MetroFramework.Controls.MetroButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelModuleInfo
            // 
            this.labelModuleInfo.AutoSize = true;
            this.labelModuleInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.labelModuleInfo.Location = new System.Drawing.Point(252, 346);
            this.labelModuleInfo.Name = "labelModuleInfo";
            this.labelModuleInfo.Size = new System.Drawing.Size(101, 13);
            this.labelModuleInfo.TabIndex = 5;
            this.labelModuleInfo.Text = "No Process Chosen";
            // 
            // textBoxPattern
            // 
            // 
            // 
            // 
            this.textBoxPattern.CustomButton.Image = null;
            this.textBoxPattern.CustomButton.Location = new System.Drawing.Point(308, 1);
            this.textBoxPattern.CustomButton.Name = "";
            this.textBoxPattern.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.textBoxPattern.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBoxPattern.CustomButton.TabIndex = 1;
            this.textBoxPattern.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBoxPattern.CustomButton.UseSelectable = true;
            this.textBoxPattern.CustomButton.Visible = false;
            this.textBoxPattern.ForeColor = System.Drawing.Color.GreenYellow;
            this.textBoxPattern.Lines = new string[0];
            this.textBoxPattern.Location = new System.Drawing.Point(23, 154);
            this.textBoxPattern.MaxLength = 32767;
            this.textBoxPattern.Name = "textBoxPattern";
            this.textBoxPattern.PasswordChar = '\0';
            this.textBoxPattern.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxPattern.SelectedText = "";
            this.textBoxPattern.SelectionLength = 0;
            this.textBoxPattern.SelectionStart = 0;
            this.textBoxPattern.ShortcutsEnabled = true;
            this.textBoxPattern.Size = new System.Drawing.Size(330, 23);
            this.textBoxPattern.Style = MetroFramework.MetroColorStyle.Lime;
            this.textBoxPattern.TabIndex = 8;
            this.textBoxPattern.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.textBoxPattern.UseCustomForeColor = true;
            this.textBoxPattern.UseSelectable = true;
            this.textBoxPattern.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBoxPattern.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // buttonScan
            // 
            this.buttonScan.ForeColor = System.Drawing.Color.Turquoise;
            this.buttonScan.Location = new System.Drawing.Point(23, 183);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(106, 23);
            this.buttonScan.Style = MetroFramework.MetroColorStyle.Teal;
            this.buttonScan.TabIndex = 9;
            this.buttonScan.Text = "Start Scan";
            this.buttonScan.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonScan.UseCustomForeColor = true;
            this.buttonScan.UseSelectable = true;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.ForeColor = System.Drawing.Color.Turquoise;
            this.buttonClear.Location = new System.Drawing.Point(135, 183);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(106, 23);
            this.buttonClear.Style = MetroFramework.MetroColorStyle.Teal;
            this.buttonClear.TabIndex = 10;
            this.buttonClear.Text = "Clear Results";
            this.buttonClear.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonClear.UseCustomForeColor = true;
            this.buttonClear.UseSelectable = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSelect
            // 
            this.buttonSelect.ForeColor = System.Drawing.Color.Turquoise;
            this.buttonSelect.Location = new System.Drawing.Point(247, 183);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(106, 23);
            this.buttonSelect.Style = MetroFramework.MetroColorStyle.Teal;
            this.buttonSelect.TabIndex = 11;
            this.buttonSelect.Text = "Select Process";
            this.buttonSelect.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonSelect.UseCustomForeColor = true;
            this.buttonSelect.UseSelectable = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // listBoxResults
            // 
            this.listBoxResults.BackColor = System.Drawing.Color.Black;
            this.listBoxResults.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.listBoxResults.ForeColor = System.Drawing.Color.YellowGreen;
            this.listBoxResults.FullRowSelect = true;
            this.listBoxResults.Location = new System.Drawing.Point(23, 225);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.OwnerDraw = true;
            this.listBoxResults.Size = new System.Drawing.Size(479, 109);
            this.listBoxResults.Style = MetroFramework.MetroColorStyle.Lime;
            this.listBoxResults.TabIndex = 12;
            this.listBoxResults.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.listBoxResults.UseCompatibleStateImageBehavior = false;
            this.listBoxResults.UseCustomBackColor = true;
            this.listBoxResults.UseCustomForeColor = true;
            this.listBoxResults.UseSelectable = true;
            this.listBoxResults.UseStyleColors = true;
            // 
            // comboBoxProcesses
            // 
            this.comboBoxProcesses.FormattingEnabled = true;
            this.comboBoxProcesses.ItemHeight = 23;
            this.comboBoxProcesses.Location = new System.Drawing.Point(359, 154);
            this.comboBoxProcesses.Name = "comboBoxProcesses";
            this.comboBoxProcesses.Size = new System.Drawing.Size(143, 29);
            this.comboBoxProcesses.Style = MetroFramework.MetroColorStyle.Lime;
            this.comboBoxProcesses.TabIndex = 13;
            this.comboBoxProcesses.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.comboBoxProcesses.UseSelectable = true;
            // 
            // buttonExportJSON
            // 
            this.buttonExportJSON.ForeColor = System.Drawing.Color.Turquoise;
            this.buttonExportJSON.Location = new System.Drawing.Point(23, 340);
            this.buttonExportJSON.Name = "buttonExportJSON";
            this.buttonExportJSON.Size = new System.Drawing.Size(98, 23);
            this.buttonExportJSON.Style = MetroFramework.MetroColorStyle.Lime;
            this.buttonExportJSON.TabIndex = 14;
            this.buttonExportJSON.Text = "EXPORT";
            this.buttonExportJSON.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonExportJSON.UseCustomForeColor = true;
            this.buttonExportJSON.UseSelectable = true;
            this.buttonExportJSON.Click += new System.EventHandler(this.buttonExportJSON_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KronosExternalScanner.Properties.Resources.LogoMakerCa_1733007418237;
            this.pictureBox1.Location = new System.Drawing.Point(23, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(479, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 369);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonExportJSON);
            this.Controls.Add(this.comboBoxProcesses);
            this.Controls.Add(this.listBoxResults);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonScan);
            this.Controls.Add(this.textBoxPattern);
            this.Controls.Add(this.labelModuleInfo);
            this.Name = "Form1";
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Text = "KronosQC - External Pattern Scanner";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelModuleInfo;
        private MetroFramework.Controls.MetroTextBox textBoxPattern;
        private MetroFramework.Controls.MetroButton buttonScan;
        private MetroFramework.Controls.MetroButton buttonClear;
        private MetroFramework.Controls.MetroButton buttonSelect;
        private MetroFramework.Controls.MetroListView listBoxResults;
        private MetroFramework.Controls.MetroComboBox comboBoxProcesses;
        private MetroFramework.Controls.MetroButton buttonExportJSON;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}


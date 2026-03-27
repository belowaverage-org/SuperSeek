namespace SuperSeek
{
    partial class Settings
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
            btnCancel = new Button();
            btnOK = new Button();
            tlpMain = new TableLayoutPanel();
            mtbMemCeiling = new MaskedTextBox();
            lblMemCeiling = new Label();
            lblMaxFileSize = new Label();
            lblScan = new Label();
            tbAggression = new TrackBar();
            mtbMaxFileSize = new MaskedTextBox();
            hpMain = new HelpProvider();
            tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAggression).BeginInit();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.FlatStyle = FlatStyle.System;
            btnCancel.Location = new Point(116, 276);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.FlatStyle = FlatStyle.System;
            btnOK.Location = new Point(197, 276);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 1;
            btnOK.Text = "&OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpMain.Controls.Add(mtbMemCeiling, 0, 5);
            tlpMain.Controls.Add(lblMemCeiling, 0, 4);
            tlpMain.Controls.Add(lblMaxFileSize, 0, 2);
            tlpMain.Controls.Add(lblScan, 0, 0);
            tlpMain.Controls.Add(tbAggression, 0, 1);
            tlpMain.Controls.Add(mtbMaxFileSize, 0, 3);
            tlpMain.Dock = DockStyle.Top;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.Padding = new Padding(10, 0, 10, 0);
            tlpMain.RowCount = 8;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tlpMain.Size = new Size(284, 253);
            tlpMain.TabIndex = 2;
            // 
            // mtbMemCeiling
            // 
            mtbMemCeiling.Dock = DockStyle.Bottom;
            hpMain.SetHelpString(mtbMemCeiling, "How much memory should Super Seek consume before throttling scans?");
            mtbMemCeiling.Location = new Point(13, 160);
            mtbMemCeiling.Mask = "##### MB";
            mtbMemCeiling.Name = "mtbMemCeiling";
            mtbMemCeiling.PromptChar = ' ';
            hpMain.SetShowHelp(mtbMemCeiling, true);
            mtbMemCeiling.Size = new Size(258, 23);
            mtbMemCeiling.TabIndex = 5;
            // 
            // lblMemCeiling
            // 
            lblMemCeiling.AutoSize = true;
            lblMemCeiling.Dock = DockStyle.Bottom;
            hpMain.SetHelpString(lblMemCeiling, "How much memory should Super Seek consume before throttling scans?");
            lblMemCeiling.Location = new Point(13, 140);
            lblMemCeiling.Name = "lblMemCeiling";
            hpMain.SetShowHelp(lblMemCeiling, true);
            lblMemCeiling.Size = new Size(258, 15);
            lblMemCeiling.TabIndex = 3;
            lblMemCeiling.Text = "Memory Ceiling";
            // 
            // lblMaxFileSize
            // 
            lblMaxFileSize.AutoSize = true;
            lblMaxFileSize.Dock = DockStyle.Bottom;
            hpMain.SetHelpString(lblMaxFileSize, "Max file size that Super Seek will scan.");
            lblMaxFileSize.Location = new Point(13, 78);
            lblMaxFileSize.Name = "lblMaxFileSize";
            hpMain.SetShowHelp(lblMaxFileSize, true);
            lblMaxFileSize.Size = new Size(258, 15);
            lblMaxFileSize.TabIndex = 2;
            lblMaxFileSize.Text = "Max File Size";
            // 
            // lblScan
            // 
            lblScan.AutoSize = true;
            lblScan.Dock = DockStyle.Bottom;
            hpMain.SetHelpString(lblScan, "How aggressive should Super Seek be when scanning file contents?");
            lblScan.Location = new Point(13, 16);
            lblScan.Name = "lblScan";
            hpMain.SetShowHelp(lblScan, true);
            lblScan.Size = new Size(258, 15);
            lblScan.TabIndex = 0;
            lblScan.Text = "Scan Aggressiveness";
            // 
            // tbAggression
            // 
            tbAggression.Dock = DockStyle.Bottom;
            hpMain.SetHelpString(tbAggression, "How aggressive should Super Seek be when scanning file contents?");
            tbAggression.LargeChange = 10;
            tbAggression.Location = new Point(13, 34);
            tbAggression.Maximum = 200;
            tbAggression.Name = "tbAggression";
            hpMain.SetShowHelp(tbAggression, true);
            tbAggression.Size = new Size(258, 25);
            tbAggression.TabIndex = 1;
            tbAggression.TickFrequency = 10;
            tbAggression.TickStyle = TickStyle.TopLeft;
            // 
            // mtbMaxFileSize
            // 
            mtbMaxFileSize.Dock = DockStyle.Bottom;
            hpMain.SetHelpString(mtbMaxFileSize, "Max file size that Super Seek will scan.");
            mtbMaxFileSize.Location = new Point(13, 98);
            mtbMaxFileSize.Mask = "##### MB";
            mtbMaxFileSize.Name = "mtbMaxFileSize";
            mtbMaxFileSize.PromptChar = ' ';
            hpMain.SetShowHelp(mtbMaxFileSize, true);
            mtbMaxFileSize.Size = new Size(258, 23);
            mtbMaxFileSize.TabIndex = 4;
            // 
            // Settings
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(284, 311);
            Controls.Add(tlpMain);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            HelpButton = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Settings";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            tlpMain.ResumeLayout(false);
            tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAggression).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnCancel;
        private Button btnOK;
        private TableLayoutPanel tlpMain;
        private Label lblScan;
        private TrackBar tbAggression;
        private Label lblMemCeiling;
        private Label lblMaxFileSize;
        private MaskedTextBox mtbMaxFileSize;
        private MaskedTextBox mtbMemCeiling;
        private HelpProvider hpMain;
    }
}
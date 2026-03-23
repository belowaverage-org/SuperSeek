namespace SuperSeek
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            msMain = new MenuStrip();
            miFile = new ToolStripMenuItem();
            miOpenFolder = new ToolStripMenuItem();
            tssFile1 = new ToolStripSeparator();
            miExit = new ToolStripMenuItem();
            miView = new ToolStripMenuItem();
            miToggleExtensions = new ToolStripMenuItem();
            scMain = new SplitContainer();
            tlpExtensions = new TableLayoutPanel();
            tbExtensionSearch = new TextBox();
            lvExtensions = new ListView();
            chExtension = new ColumnHeader();
            chFiles = new ColumnHeader();
            tlpResults = new TableLayoutPanel();
            lvResults = new ListView();
            chFile = new ColumnHeader();
            chMatches = new ColumnHeader();
            tlpSearch = new TableLayoutPanel();
            tbMainSearch = new TextBox();
            btnSearchOrCancel = new Button();
            ssMain = new StatusStrip();
            tspbMain = new ToolStripProgressBar();
            tsslStatus = new ToolStripStatusLabel();
            tsslCurrentFolder = new ToolStripStatusLabel();
            tsslSelectedFiles = new ToolStripStatusLabel();
            tsslScanned = new ToolStripStatusLabel();
            tsslResults = new ToolStripStatusLabel();
            fbMain = new FolderBrowserDialog();
            tsbOpenFolder = new ToolStripButton();
            tsbRefreshExts = new ToolStripButton();
            tsbSearchPath = new ToolStripButton();
            tsMain = new ToolStrip();
            tssMain1 = new ToolStripSeparator();
            tsbSearchContent = new ToolStripButton();
            tssMain2 = new ToolStripSeparator();
            tsbReveal = new ToolStripButton();
            tsbOpenWith = new ToolStripButton();
            tslMemory = new ToolStripLabel();
            tslCpuUsage = new ToolStripLabel();
            msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scMain).BeginInit();
            scMain.Panel1.SuspendLayout();
            scMain.Panel2.SuspendLayout();
            scMain.SuspendLayout();
            tlpExtensions.SuspendLayout();
            tlpResults.SuspendLayout();
            tlpSearch.SuspendLayout();
            ssMain.SuspendLayout();
            tsMain.SuspendLayout();
            SuspendLayout();
            // 
            // msMain
            // 
            msMain.Items.AddRange(new ToolStripItem[] { miFile, miView });
            msMain.Location = new Point(0, 0);
            msMain.Name = "msMain";
            msMain.RenderMode = ToolStripRenderMode.Professional;
            msMain.Size = new Size(784, 24);
            msMain.TabIndex = 1;
            msMain.Text = "msMain";
            // 
            // miFile
            // 
            miFile.DropDownItems.AddRange(new ToolStripItem[] { miOpenFolder, tssFile1, miExit });
            miFile.Name = "miFile";
            miFile.Size = new Size(37, 20);
            miFile.Text = "&File";
            // 
            // miOpenFolder
            // 
            miOpenFolder.Image = Properties.Resources.folder_open_16dp_8C1AF6_FILL0_wght400_GRAD0_opsz20;
            miOpenFolder.Name = "miOpenFolder";
            miOpenFolder.Size = new Size(148, 22);
            miOpenFolder.Text = "&Open Folder...";
            miOpenFolder.Click += OpenFolder;
            // 
            // tssFile1
            // 
            tssFile1.Name = "tssFile1";
            tssFile1.Size = new Size(145, 6);
            // 
            // miExit
            // 
            miExit.Image = Properties.Resources.close_16dp_8C1AF6_FILL0_wght400_GRAD0_opsz20;
            miExit.Name = "miExit";
            miExit.Size = new Size(148, 22);
            miExit.Text = "&Exit";
            miExit.Click += miExit_Click;
            // 
            // miView
            // 
            miView.DropDownItems.AddRange(new ToolStripItem[] { miToggleExtensions });
            miView.Name = "miView";
            miView.Size = new Size(44, 20);
            miView.Text = "&View";
            // 
            // miToggleExtensions
            // 
            miToggleExtensions.Checked = true;
            miToggleExtensions.CheckState = CheckState.Checked;
            miToggleExtensions.Name = "miToggleExtensions";
            miToggleExtensions.Size = new Size(175, 22);
            miToggleExtensions.Text = "File Extension Filter";
            miToggleExtensions.Click += ToggleExtensionList;
            // 
            // scMain
            // 
            scMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            scMain.Location = new Point(5, 70);
            scMain.Margin = new Padding(0);
            scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            scMain.Panel1.Controls.Add(tlpExtensions);
            scMain.Panel1.Padding = new Padding(0, 1, 0, 0);
            // 
            // scMain.Panel2
            // 
            scMain.Panel2.Controls.Add(tlpResults);
            scMain.Size = new Size(774, 364);
            scMain.SplitterDistance = 224;
            scMain.SplitterWidth = 5;
            scMain.TabIndex = 2;
            // 
            // tlpExtensions
            // 
            tlpExtensions.ColumnCount = 1;
            tlpExtensions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpExtensions.Controls.Add(tbExtensionSearch, 0, 0);
            tlpExtensions.Controls.Add(lvExtensions, 0, 1);
            tlpExtensions.Dock = DockStyle.Fill;
            tlpExtensions.Location = new Point(0, 1);
            tlpExtensions.Margin = new Padding(0);
            tlpExtensions.Name = "tlpExtensions";
            tlpExtensions.RowCount = 2;
            tlpExtensions.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpExtensions.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpExtensions.Size = new Size(224, 363);
            tlpExtensions.TabIndex = 2;
            // 
            // tbExtensionSearch
            // 
            tbExtensionSearch.Dock = DockStyle.Fill;
            tbExtensionSearch.Location = new Point(0, 0);
            tbExtensionSearch.Margin = new Padding(0, 0, 0, 2);
            tbExtensionSearch.Multiline = true;
            tbExtensionSearch.Name = "tbExtensionSearch";
            tbExtensionSearch.PlaceholderText = "Extension Search";
            tbExtensionSearch.Size = new Size(224, 28);
            tbExtensionSearch.TabIndex = 2;
            tbExtensionSearch.TextChanged += FilterExtensions;
            tbExtensionSearch.KeyDown += tbExtensionSearch_KeyDown;
            // 
            // lvExtensions
            // 
            lvExtensions.CheckBoxes = true;
            lvExtensions.Columns.AddRange(new ColumnHeader[] { chExtension, chFiles });
            lvExtensions.Dock = DockStyle.Fill;
            lvExtensions.FullRowSelect = true;
            lvExtensions.Location = new Point(0, 34);
            lvExtensions.Margin = new Padding(0, 4, 0, 0);
            lvExtensions.Name = "lvExtensions";
            lvExtensions.Size = new Size(224, 329);
            lvExtensions.Sorting = SortOrder.Ascending;
            lvExtensions.TabIndex = 1;
            lvExtensions.UseCompatibleStateImageBehavior = false;
            lvExtensions.View = View.Details;
            lvExtensions.ColumnClick += SortColumn;
            lvExtensions.ItemChecked += lvExtensions_ItemChecked;
            // 
            // chExtension
            // 
            chExtension.Text = "Extension";
            chExtension.Width = 125;
            // 
            // chFiles
            // 
            chFiles.Text = "Files";
            chFiles.TextAlign = HorizontalAlignment.Right;
            // 
            // tlpResults
            // 
            tlpResults.ColumnCount = 1;
            tlpResults.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpResults.Controls.Add(lvResults, 0, 1);
            tlpResults.Controls.Add(tlpSearch, 0, 0);
            tlpResults.Dock = DockStyle.Fill;
            tlpResults.Location = new Point(0, 0);
            tlpResults.Margin = new Padding(0);
            tlpResults.Name = "tlpResults";
            tlpResults.RowCount = 2;
            tlpResults.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpResults.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpResults.Size = new Size(545, 364);
            tlpResults.TabIndex = 1;
            // 
            // lvResults
            // 
            lvResults.Columns.AddRange(new ColumnHeader[] { chFile, chMatches });
            lvResults.Dock = DockStyle.Fill;
            lvResults.FullRowSelect = true;
            lvResults.Location = new Point(0, 35);
            lvResults.Margin = new Padding(0, 5, 1, 0);
            lvResults.Name = "lvResults";
            lvResults.Size = new Size(544, 329);
            lvResults.TabIndex = 0;
            lvResults.UseCompatibleStateImageBehavior = false;
            lvResults.View = View.Details;
            lvResults.ColumnClick += SortColumn;
            lvResults.ItemSelectionChanged += lvResults_ItemSelectionChanged;
            lvResults.KeyDown += lvResults_KeyDown;
            lvResults.MouseDoubleClick += OpenSelectedFiles;
            // 
            // chFile
            // 
            chFile.Text = "File";
            chFile.Width = 300;
            // 
            // chMatches
            // 
            chMatches.Text = "Matches";
            chMatches.Width = 200;
            // 
            // tlpSearch
            // 
            tlpSearch.ColumnCount = 2;
            tlpSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tlpSearch.Controls.Add(tbMainSearch, 0, 0);
            tlpSearch.Controls.Add(btnSearchOrCancel, 1, 0);
            tlpSearch.Dock = DockStyle.Fill;
            tlpSearch.Location = new Point(0, 0);
            tlpSearch.Margin = new Padding(0);
            tlpSearch.Name = "tlpSearch";
            tlpSearch.RowCount = 1;
            tlpSearch.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpSearch.Size = new Size(545, 30);
            tlpSearch.TabIndex = 1;
            // 
            // tbMainSearch
            // 
            tbMainSearch.Dock = DockStyle.Fill;
            tbMainSearch.Location = new Point(0, 1);
            tbMainSearch.Margin = new Padding(0, 1, 0, 1);
            tbMainSearch.Multiline = true;
            tbMainSearch.Name = "tbMainSearch";
            tbMainSearch.PlaceholderText = "Regular Expressions";
            tbMainSearch.Size = new Size(465, 28);
            tbMainSearch.TabIndex = 1;
            tbMainSearch.KeyDown += tbMainSearch_KeyDown;
            // 
            // btnSearchOrCancel
            // 
            btnSearchOrCancel.Dock = DockStyle.Fill;
            btnSearchOrCancel.FlatStyle = FlatStyle.System;
            btnSearchOrCancel.Location = new Point(469, 0);
            btnSearchOrCancel.Margin = new Padding(4, 0, 0, 0);
            btnSearchOrCancel.Name = "btnSearchOrCancel";
            btnSearchOrCancel.Size = new Size(76, 30);
            btnSearchOrCancel.TabIndex = 2;
            btnSearchOrCancel.Text = "Search";
            btnSearchOrCancel.UseVisualStyleBackColor = true;
            btnSearchOrCancel.Click += SearchOrCancel;
            // 
            // ssMain
            // 
            ssMain.Items.AddRange(new ToolStripItem[] { tspbMain, tsslStatus, tsslCurrentFolder, tsslSelectedFiles, tsslScanned, tsslResults });
            ssMain.Location = new Point(0, 439);
            ssMain.Name = "ssMain";
            ssMain.RenderMode = ToolStripRenderMode.Professional;
            ssMain.Size = new Size(784, 22);
            ssMain.SizingGrip = false;
            ssMain.TabIndex = 3;
            ssMain.Text = "ssMain";
            // 
            // tspbMain
            // 
            tspbMain.Name = "tspbMain";
            tspbMain.Padding = new Padding(6, 0, 0, 0);
            tspbMain.Size = new Size(106, 16);
            // 
            // tsslStatus
            // 
            tsslStatus.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsslStatus.Name = "tsslStatus";
            tsslStatus.Size = new Size(325, 17);
            tsslStatus.Spring = true;
            tsslStatus.Text = "Status: {0}";
            tsslStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tsslCurrentFolder
            // 
            tsslCurrentFolder.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsslCurrentFolder.Name = "tsslCurrentFolder";
            tsslCurrentFolder.Overflow = ToolStripItemOverflow.Never;
            tsslCurrentFolder.RightToLeft = RightToLeft.No;
            tsslCurrentFolder.Size = new Size(103, 17);
            tsslCurrentFolder.Text = "Current Folder: {0}";
            // 
            // tsslSelectedFiles
            // 
            tsslSelectedFiles.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsslSelectedFiles.Name = "tsslSelectedFiles";
            tsslSelectedFiles.Size = new Size(97, 17);
            tsslSelectedFiles.Text = "Selected Files: {0}";
            // 
            // tsslScanned
            // 
            tsslScanned.Name = "tsslScanned";
            tsslScanned.Size = new Size(72, 17);
            tsslScanned.Text = "Scanned: {0}";
            // 
            // tsslResults
            // 
            tsslResults.Name = "tsslResults";
            tsslResults.Size = new Size(64, 17);
            tsslResults.Text = "Results: {0}";
            // 
            // fbMain
            // 
            fbMain.RootFolder = Environment.SpecialFolder.History;
            // 
            // tsbOpenFolder
            // 
            tsbOpenFolder.Image = Properties.Resources.folder_open_16dp_8C1AF6_FILL0_wght400_GRAD0_opsz20;
            tsbOpenFolder.ImageTransparentColor = Color.Magenta;
            tsbOpenFolder.Margin = new Padding(0, 1, 5, 2);
            tsbOpenFolder.Name = "tsbOpenFolder";
            tsbOpenFolder.Size = new Size(85, 35);
            tsbOpenFolder.Text = "Open Folder...";
            tsbOpenFolder.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbOpenFolder.Click += OpenFolder;
            // 
            // tsbRefreshExts
            // 
            tsbRefreshExts.Image = Properties.Resources.refresh_16dp_8C1AF6_FILL0_wght400_GRAD0_opsz20;
            tsbRefreshExts.ImageTransparentColor = Color.Magenta;
            tsbRefreshExts.Margin = new Padding(0, 1, 5, 2);
            tsbRefreshExts.Name = "tsbRefreshExts";
            tsbRefreshExts.Size = new Size(86, 35);
            tsbRefreshExts.Text = "Refresh Folder";
            tsbRefreshExts.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbRefreshExts.ToolTipText = "Refresh the selected directory.";
            tsbRefreshExts.Click += RefreshFolder;
            // 
            // tsbSearchPath
            // 
            tsbSearchPath.Checked = true;
            tsbSearchPath.CheckOnClick = true;
            tsbSearchPath.CheckState = CheckState.Checked;
            tsbSearchPath.Image = Properties.Resources.manage_search_16dp_8C1AF6_FILL0_wght400_GRAD0_opsz20;
            tsbSearchPath.ImageTransparentColor = Color.Magenta;
            tsbSearchPath.Margin = new Padding(0, 1, 5, 2);
            tsbSearchPath.Name = "tsbSearchPath";
            tsbSearchPath.Size = new Size(73, 35);
            tsbSearchPath.Text = "Search Path";
            tsbSearchPath.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbSearchPath.ToolTipText = "Search using the file path.";
            // 
            // tsMain
            // 
            tsMain.GripStyle = ToolStripGripStyle.Hidden;
            tsMain.Items.AddRange(new ToolStripItem[] { tsbOpenFolder, tsbRefreshExts, tssMain1, tsbSearchPath, tsbSearchContent, tssMain2, tsbReveal, tsbOpenWith, tslMemory, tslCpuUsage });
            tsMain.Location = new Point(0, 24);
            tsMain.Name = "tsMain";
            tsMain.Padding = new Padding(5, 5, 5, 0);
            tsMain.Size = new Size(784, 43);
            tsMain.TabIndex = 4;
            tsMain.Text = "tsMain";
            // 
            // tssMain1
            // 
            tssMain1.Margin = new Padding(0, 0, 5, 0);
            tssMain1.Name = "tssMain1";
            tssMain1.Size = new Size(6, 38);
            // 
            // tsbSearchContent
            // 
            tsbSearchContent.Checked = true;
            tsbSearchContent.CheckOnClick = true;
            tsbSearchContent.CheckState = CheckState.Checked;
            tsbSearchContent.Image = Properties.Resources.document_search_16dp_8C1AF6_FILL0_wght400_GRAD0_opsz20;
            tsbSearchContent.ImageTransparentColor = Color.Magenta;
            tsbSearchContent.Margin = new Padding(0, 1, 5, 2);
            tsbSearchContent.Name = "tsbSearchContent";
            tsbSearchContent.Size = new Size(92, 35);
            tsbSearchContent.Text = "Search Content";
            tsbSearchContent.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbSearchContent.ToolTipText = "Search using the file content.";
            // 
            // tssMain2
            // 
            tssMain2.Margin = new Padding(0, 0, 5, 0);
            tssMain2.Name = "tssMain2";
            tssMain2.Size = new Size(6, 38);
            // 
            // tsbReveal
            // 
            tsbReveal.Enabled = false;
            tsbReveal.Image = Properties.Resources.folder_eye_16dp_8C1AF6_FILL0_wght400_GRAD0_opsz20;
            tsbReveal.ImageTransparentColor = Color.Magenta;
            tsbReveal.Margin = new Padding(0, 1, 5, 2);
            tsbReveal.Name = "tsbReveal";
            tsbReveal.Size = new Size(76, 35);
            tsbReveal.Text = "Show Folder";
            tsbReveal.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbReveal.ToolTipText = "Open the folder of the selected file.";
            tsbReveal.Click += OpenSelectedFiles;
            // 
            // tsbOpenWith
            // 
            tsbOpenWith.Enabled = false;
            tsbOpenWith.Image = Properties.Resources.open_in_browser_16dp_8C1AF6_FILL0_wght400_GRAD0_opsz20;
            tsbOpenWith.ImageTransparentColor = Color.Magenta;
            tsbOpenWith.Margin = new Padding(0, 1, 5, 2);
            tsbOpenWith.Name = "tsbOpenWith";
            tsbOpenWith.Size = new Size(77, 35);
            tsbOpenWith.Text = "Open With...";
            tsbOpenWith.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbOpenWith.ToolTipText = "Open selected file with...";
            tsbOpenWith.Click += OpenSelectedFiles;
            // 
            // tslMemory
            // 
            tslMemory.Alignment = ToolStripItemAlignment.Right;
            tslMemory.AutoSize = false;
            tslMemory.Image = Properties.Resources.memory_16dp_8C1AF6_FILL0_wght400_GRAD0_opsz20;
            tslMemory.Name = "tslMemory";
            tslMemory.Size = new Size(50, 35);
            tslMemory.Text = "{0}M";
            tslMemory.TextImageRelation = TextImageRelation.ImageAboveText;
            tslMemory.ToolTipText = "Memory Usage";
            // 
            // tslCpuUsage
            // 
            tslCpuUsage.Alignment = ToolStripItemAlignment.Right;
            tslCpuUsage.AutoSize = false;
            tslCpuUsage.Image = Properties.Resources.speed_16dp_8C1AF6_FILL0_wght400_GRAD0_opsz20;
            tslCpuUsage.Name = "tslCpuUsage";
            tslCpuUsage.Size = new Size(50, 35);
            tslCpuUsage.Text = "{0}%";
            tslCpuUsage.TextImageRelation = TextImageRelation.ImageAboveText;
            tslCpuUsage.ToolTipText = "CPU Usage";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(tsMain);
            Controls.Add(ssMain);
            Controls.Add(scMain);
            Controls.Add(msMain);
            MainMenuStrip = msMain;
            Name = "Main";
            Text = "Super Seek: High Performance File Search Tool";
            FormClosing += Main_FormClosing;
            Load += Initialize;
            msMain.ResumeLayout(false);
            msMain.PerformLayout();
            scMain.Panel1.ResumeLayout(false);
            scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scMain).EndInit();
            scMain.ResumeLayout(false);
            tlpExtensions.ResumeLayout(false);
            tlpExtensions.PerformLayout();
            tlpResults.ResumeLayout(false);
            tlpSearch.ResumeLayout(false);
            tlpSearch.PerformLayout();
            ssMain.ResumeLayout(false);
            ssMain.PerformLayout();
            tsMain.ResumeLayout(false);
            tsMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip msMain;
        private ListView lvResults;
        private TableLayoutPanel tlpResults;
        private TextBox tbMainSearch;
        private ToolStripMenuItem miFile;
        private ToolStripMenuItem miOpenFolder;
        private ToolStripSeparator tssFile1;
        private ToolStripMenuItem miExit;
        private StatusStrip ssMain;
        public SplitContainer scMain;
        private FolderBrowserDialog fbMain;
        private ToolStripStatusLabel tsslCurrentFolder;
        private ToolStripStatusLabel tsslStatus;
        private TableLayoutPanel tlpSearch;
        private Button btnSearchOrCancel;
        private ToolStripMenuItem miView;
        private ToolStripMenuItem miToggleExtensions;
        private ToolStripStatusLabel tsslSelectedFiles;
        private ListView lvExtensions;
        private ColumnHeader chExtension;
        private ColumnHeader chFiles;
        private TableLayoutPanel tlpExtensions;
        private TextBox tbExtensionSearch;
        private ColumnHeader chFile;
        private ColumnHeader chMatches;
        private ToolStripStatusLabel tsslResults;
        private ToolStripProgressBar tspbMain;
        private ToolStripStatusLabel tsslScanned;
        private ToolStripButton tsbOpenFolder;
        private ToolStripButton tsbRefreshExts;
        private ToolStripButton tsbSearchPath;
        private ToolStrip tsMain;
        private ToolStripButton tsbSearchContent;
        private ToolStripSeparator tssMain2;
        private ToolStripButton tsbOpenWith;
        private ToolStripSeparator tssMain1;
        private ToolStripButton tsbReveal;
        private ToolStripLabel tslCpuUsage;
        private ToolStripLabel tslMemory;
    }
}

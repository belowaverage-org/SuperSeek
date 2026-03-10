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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openFolderToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            fileExtensionFilterToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            tableLayoutPanel3 = new TableLayoutPanel();
            textBox1 = new TextBox();
            listView2 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            tableLayoutPanel2 = new TableLayoutPanel();
            listView1 = new ListView();
            tableLayoutPanel1 = new TableLayoutPanel();
            textBox2 = new TextBox();
            button1 = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            folderBrowserDialog1 = new FolderBrowserDialog();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Size = new Size(784, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openFolderToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // openFolderToolStripMenuItem
            // 
            openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            openFolderToolStripMenuItem.Size = new Size(148, 22);
            openFolderToolStripMenuItem.Text = "&Open Folder...";
            openFolderToolStripMenuItem.Click += openFolderToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(145, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(148, 22);
            exitToolStripMenuItem.Text = "&Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fileExtensionFilterToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "&View";
            // 
            // fileExtensionFilterToolStripMenuItem
            // 
            fileExtensionFilterToolStripMenuItem.Checked = true;
            fileExtensionFilterToolStripMenuItem.CheckState = CheckState.Checked;
            fileExtensionFilterToolStripMenuItem.Name = "fileExtensionFilterToolStripMenuItem";
            fileExtensionFilterToolStripMenuItem.Size = new Size(175, 22);
            fileExtensionFilterToolStripMenuItem.Text = "File Extension Filter";
            fileExtensionFilterToolStripMenuItem.Click += fileExtensionFilterToolStripMenuItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(5, 30);
            splitContainer1.Margin = new Padding(0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel3);
            splitContainer1.Panel1.Padding = new Padding(0, 1, 0, 0);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel2);
            splitContainer1.Size = new Size(773, 403);
            splitContainer1.SplitterDistance = 224;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(textBox1, 0, 0);
            tableLayoutPanel3.Controls.Add(listView2, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 1);
            tableLayoutPanel3.Margin = new Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(224, 402);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(0, 0);
            textBox1.Margin = new Padding(0, 0, 0, 2);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Extension Search";
            textBox1.Size = new Size(224, 28);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // listView2
            // 
            listView2.CheckBoxes = true;
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listView2.Dock = DockStyle.Fill;
            listView2.FullRowSelect = true;
            listView2.Location = new Point(0, 34);
            listView2.Margin = new Padding(0, 4, 0, 0);
            listView2.Name = "listView2";
            listView2.Size = new Size(224, 368);
            listView2.Sorting = SortOrder.Ascending;
            listView2.TabIndex = 1;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            listView2.ItemChecked += listView2_ItemChecked;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Extension";
            columnHeader1.Width = 125;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Files";
            columnHeader2.TextAlign = HorizontalAlignment.Right;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(listView1, 0, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(544, 403);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4 });
            listView1.Dock = DockStyle.Fill;
            listView1.FullRowSelect = true;
            listView1.Location = new Point(0, 35);
            listView1.Margin = new Padding(0, 5, 1, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(543, 368);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.Controls.Add(textBox2, 0, 0);
            tableLayoutPanel1.Controls.Add(button1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(544, 30);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(0, 1);
            textBox2.Margin = new Padding(0, 1, 0, 1);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Regular Expressions";
            textBox2.Size = new Size(464, 28);
            textBox2.TabIndex = 1;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.FlatStyle = FlatStyle.System;
            button1.Location = new Point(468, 0);
            button1.Margin = new Padding(4, 0, 0, 0);
            button1.Name = "button1";
            button1.Size = new Size(76, 30);
            button1.TabIndex = 2;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel2, toolStripStatusLabel3, toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 439);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.RenderMode = ToolStripRenderMode.Professional;
            statusStrip1.Size = new Size(784, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(64, 17);
            toolStripStatusLabel2.Text = "Status: Idle";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(89, 17);
            toolStripStatusLabel3.Text = "Selected Files: 0";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(105, 17);
            toolStripStatusLabel1.Text = "Current Folder: C:\\";
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.History;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "File";
            columnHeader3.Width = 300;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Matching Text";
            columnHeader4.Width = 200;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(statusStrip1);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Main";
            Text = "SuperSeek";
            Load += Main_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ListView listView1;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox textBox2;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openFolderToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private StatusStrip statusStrip1;
        public SplitContainer splitContainer1;
        private FolderBrowserDialog folderBrowserDialog1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button1;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem fileExtensionFilterToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ListView listView2;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox textBox1;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
    }
}

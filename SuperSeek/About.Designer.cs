namespace SuperSeek
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            pbLogo = new PictureBox();
            lblProduct = new Label();
            lblDescription = new Label();
            btnOK = new Button();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // pbLogo
            // 
            pbLogo.Image = Properties.Resources.logo;
            pbLogo.Location = new Point(121, 12);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(146, 153);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 0;
            pbLogo.TabStop = false;
            // 
            // lblProduct
            // 
            lblProduct.FlatStyle = FlatStyle.System;
            lblProduct.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblProduct.ForeColor = Color.FromArgb(64, 64, 64);
            lblProduct.Location = new Point(12, 168);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(347, 31);
            lblProduct.TabIndex = 1;
            lblProduct.Text = "Product";
            lblProduct.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblDescription
            // 
            lblDescription.FlatStyle = FlatStyle.System;
            lblDescription.Location = new Point(12, 199);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(347, 54);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Description\r\nCopyright\r\nVersion";
            lblDescription.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnOK
            // 
            btnOK.FlatStyle = FlatStyle.System;
            btnOK.Location = new Point(284, 270);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 3;
            btnOK.Text = "&OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += BtnOK_Click;
            // 
            // About
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnOK;
            ClientSize = new Size(371, 305);
            Controls.Add(btnOK);
            Controls.Add(lblDescription);
            Controls.Add(pbLogo);
            Controls.Add(lblProduct);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "About";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbLogo;
        private Label lblProduct;
        private Label lblDescription;
        private Button btnOK;
    }
}
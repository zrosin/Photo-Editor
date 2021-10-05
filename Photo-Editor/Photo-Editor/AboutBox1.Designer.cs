namespace Photo_Editor
{
    partial class AboutBox1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox1));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.labelProductName1 = new System.Windows.Forms.Label();
            this.labelVersion1 = new System.Windows.Forms.Label();
            this.labelCopyright1 = new System.Windows.Forms.Label();
            this.labelCompanyName1 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelProductName1, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelVersion1, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.labelCopyright1, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.labelCompanyName1, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.textBoxDescription, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.okButton, 1, 5);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(417, 265);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(3, 3);
            this.logoPictureBox.Name = "logoPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 6);
            this.logoPictureBox.Size = new System.Drawing.Size(131, 259);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // labelProductName1
            // 
            this.labelProductName1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProductName1.Location = new System.Drawing.Point(143, 0);
            this.labelProductName1.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelProductName1.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelProductName1.Name = "labelProductName1";
            this.labelProductName1.Size = new System.Drawing.Size(271, 17);
            this.labelProductName1.TabIndex = 19;
            this.labelProductName1.Text = "Photo Editor Project";
            this.labelProductName1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVersion1
            // 
            this.labelVersion1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelVersion1.Location = new System.Drawing.Point(143, 26);
            this.labelVersion1.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelVersion1.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelVersion1.Name = "labelVersion1";
            this.labelVersion1.Size = new System.Drawing.Size(271, 17);
            this.labelVersion1.TabIndex = 0;
            this.labelVersion1.Text = "Version 1.0";
            this.labelVersion1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCopyright1
            // 
            this.labelCopyright1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCopyright1.Location = new System.Drawing.Point(143, 52);
            this.labelCopyright1.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelCopyright1.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelCopyright1.Name = "labelCopyright1";
            this.labelCopyright1.Size = new System.Drawing.Size(271, 17);
            this.labelCopyright1.TabIndex = 21;
            this.labelCopyright1.Text = "Copyright? No";
            this.labelCopyright1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCompanyName1
            // 
            this.labelCompanyName1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCompanyName1.Location = new System.Drawing.Point(143, 78);
            this.labelCompanyName1.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelCompanyName1.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelCompanyName1.Name = "labelCompanyName1";
            this.labelCompanyName1.Size = new System.Drawing.Size(271, 17);
            this.labelCompanyName1.TabIndex = 22;
            this.labelCompanyName1.Text = "Jacob Rails, Zach Rosin";
            this.labelCompanyName1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(143, 107);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDescription.Size = new System.Drawing.Size(271, 126);
            this.textBoxDescription.TabIndex = 23;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Text = "Simple photo editor and browser. To use, select a directory and double click on a" +
    "n image you want to edit, launching the edit tool.";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(339, 239);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "&OK";
            // 
            // AboutBox1
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 283);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox1";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AboutBox1";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label labelProductName1;
        private System.Windows.Forms.Label labelVersion1;
        private System.Windows.Forms.Label labelCopyright1;
        private System.Windows.Forms.Label labelCompanyName1;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button okButton;
    }
}

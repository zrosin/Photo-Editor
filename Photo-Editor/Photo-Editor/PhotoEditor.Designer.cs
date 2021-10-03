namespace Photo_Editor
{
    partial class PhotoEditor
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.InvertImage = new System.Windows.Forms.Button();
            this.tintImage = new System.Windows.Forms.Button();
            this.brightnessBar = new System.Windows.Forms.TrackBar();
            this.tintPicker = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(379, 326);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // InvertImage
            // 
            this.InvertImage.Location = new System.Drawing.Point(156, 459);
            this.InvertImage.Name = "InvertImage";
            this.InvertImage.Size = new System.Drawing.Size(75, 23);
            this.InvertImage.TabIndex = 1;
            this.InvertImage.Text = "Invert";
            this.InvertImage.UseVisualStyleBackColor = true;
            this.InvertImage.Click += new System.EventHandler(this.InvertImage_Click);
            // 
            // tintImage
            // 
            this.tintImage.Location = new System.Drawing.Point(278, 459);
            this.tintImage.Name = "tintImage";
            this.tintImage.Size = new System.Drawing.Size(75, 23);
            this.tintImage.TabIndex = 2;
            this.tintImage.Text = "Tint";
            this.tintImage.UseVisualStyleBackColor = true;
            this.tintImage.Click += new System.EventHandler(this.tintImage_Click);
            // 
            // brightnessBar
            // 
            this.brightnessBar.Location = new System.Drawing.Point(12, 459);
            this.brightnessBar.Name = "brightnessBar";
            this.brightnessBar.Size = new System.Drawing.Size(104, 45);
            this.brightnessBar.TabIndex = 3;
            // 
            // PhotoEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 494);
            this.Controls.Add(this.brightnessBar);
            this.Controls.Add(this.tintImage);
            this.Controls.Add(this.InvertImage);
            this.Controls.Add(this.pictureBox);
            this.Name = "PhotoEditor";
            this.Text = "PhotoEditor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button InvertImage;
        private System.Windows.Forms.Button tintImage;
        private System.Windows.Forms.TrackBar brightnessBar;
        private System.Windows.Forms.ColorDialog tintPicker;
    }
}
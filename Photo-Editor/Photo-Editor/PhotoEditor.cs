using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photo_Editor
{
    public partial class PhotoEditor : Form
    {
        private string imageLocation;
        ProgressBar progressBar;
        private CancellationTokenSource cancellationTokenSource;

        public PhotoEditor()
        {
            InitializeComponent();
        }

        public PhotoEditor(string s)
        {
            InitializeComponent();

            this.imageLocation = s;

            byte[] bytes = System.IO.File.ReadAllBytes(imageLocation);
            pictureBox.Image = Image.FromStream(new System.IO.MemoryStream(bytes));
        }

        private void disableForm()
        {
            brightnessBar.Enabled = false;
            invertImage.Enabled = false;
            tintImage.Enabled = false;
            saveButton.Enabled = false;
            saveAsButton.Enabled = false;
            cancelButton.Enabled = false;
        }

        private void enableForm()
        {
            brightnessBar.Enabled = true;
            invertImage.Enabled = true;
            tintImage.Enabled = true;
            saveButton.Enabled = true;
            saveAsButton.Enabled = true;
            cancelButton.Enabled = true;
        }

        private void ProgressBar_CancelTransform()
        {
            cancellationTokenSource.Cancel();
        }

        private void startProgressBar()
        {
            cancellationTokenSource = new CancellationTokenSource();
            //Launch Progressbar
            progressBar = new ProgressBar();
            //Subscribe to childs event
            progressBar.CancelTransform += ProgressBar_CancelTransform;
            progressBar.Show();
        }

        private void closeProgressBar()
        {
            try
            {
                progressBar.Close();
            }
            catch
            {
                //Otherwise it was already closed
            }
        }

        private async void invertImage_Click(object sender, EventArgs e)
        {
            //Disable Buttons and start progressbar
            disableForm();
            startProgressBar();

            //Do transformation
            var newImage = new Bitmap(pictureBox.Image);
            await InvertColors(newImage);

            //Apply if not cancelled
            if (!cancellationTokenSource.Token.IsCancellationRequested)
                pictureBox.Image = newImage;

            //Close progressbar and renable form
            closeProgressBar();
            enableForm();
        }

        private async void tintImage_Click(object sender, EventArgs e)
        {
            //Disable Buttons
            disableForm();
            

            var newImage = new Bitmap(pictureBox.Image);

            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = true;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                startProgressBar();

                await AlterColors(newImage, colorDialog.Color);

                if (!cancellationTokenSource.Token.IsCancellationRequested)
                    pictureBox.Image = newImage;

                
                closeProgressBar();
                
            }

            enableForm();
        }

        private async void brightnessBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Disable Buttons and start progressbar
                disableForm();
                startProgressBar();

                var newImage = new Bitmap(pictureBox.Image);
                await ChangeBrightness(newImage, brightnessBar.Value * 10);

                if (!cancellationTokenSource.Token.IsCancellationRequested)
                    pictureBox.Image = newImage;

                //Close progressbar and renable form
                closeProgressBar();
                enableForm();
            }
        }

        private async void brightnessBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //Disable Buttons and start progressbar
                disableForm();
                startProgressBar();

                var newImage = new Bitmap(pictureBox.Image);
                await ChangeBrightness(newImage, brightnessBar.Value * 10);

                if (!cancellationTokenSource.Token.IsCancellationRequested)
                    pictureBox.Image = newImage;

                //Close progressbar and renable form
                closeProgressBar();
                enableForm();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            //Make sure child is closed
            closeProgressBar();
            Close();
        }

        void requestUpdateProgressBar(int progress)
        {
            try
            {
                Invoke((Action)delegate ()
                {
                    progressBar.updateProgressBar(progress);
                });
            }
            catch (ObjectDisposedException)
            { }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            pictureBox.Image.Save(imageLocation, ImageFormat.Jpeg);
            this.DialogResult = DialogResult.OK;
        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "jpeg files (*.jpeg)|*.jpg, *.jpeg|All files (*.*)|*.*";
            saveFileDialog1.InitialDirectory = Path.GetDirectoryName(imageLocation);

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image.Save(saveFileDialog1.FileName.ToString(), ImageFormat.Jpeg);

                this.DialogResult = DialogResult.OK;
            }
        }


        //Core of this code is from McCown
        private async Task InvertColors(Bitmap transformedBitmap)
        {
            await Task.Run(() =>
            {
                int updateTime = transformedBitmap.Height / 20;
                int progress = 0;

                for (int y = 0; y < transformedBitmap.Height; y++)
                {
                    if (y % updateTime == 0 && y != 0)
                    {
                        progress += 5;
                        requestUpdateProgressBar(progress);
                    }

                    for (int x = 0; x < transformedBitmap.Width; x++)
                    {
                        if (cancellationTokenSource.Token.IsCancellationRequested)
                            break;

                        var color = transformedBitmap.GetPixel(x, y);
                        int newRed = Math.Abs(color.R - 255);
                        int newGreen = Math.Abs(color.G - 255);
                        int newBlue = Math.Abs(color.B - 255);
                        Color newColor = Color.FromArgb(newRed, newGreen, newBlue);
                        transformedBitmap.SetPixel(x, y, newColor);
                    }
                }
            });
            
        }

        //Core of this code is from McCown
        private async Task AlterColors(Bitmap transformedBitmap, Color chosenColor)
        {
            await Task.Run(() =>
            {
                int updateTime = transformedBitmap.Height / 20;
                int progress = 0;

                for (int y = 0; y < transformedBitmap.Height; y++)
                {
                    if (y % updateTime == 0 && y != 0)
                    {
                        progress += 5;
                        requestUpdateProgressBar(progress);
                    }

                    for (int x = 0; x < transformedBitmap.Width; x++)
                    {
                        if (cancellationTokenSource.Token.IsCancellationRequested)
                            break;

                        var color = transformedBitmap.GetPixel(x, y);
                        int ave = (color.R + color.G + color.B) / 3;
                        double percent = ave / 255.0;
                        int newRed = Convert.ToInt32(chosenColor.R * percent);
                        int newGreen = Convert.ToInt32(chosenColor.G * percent);
                        int newBlue = Convert.ToInt32(chosenColor.B * percent);
                        var newColor = Color.FromArgb(newRed, newGreen, newBlue);
                        transformedBitmap.SetPixel(x, y, newColor);
                    }
                }
            });
            
        }

        //Core of this code is from McCown
        private async Task ChangeBrightness(Bitmap transformedBitmap, int brightness)
        {
            await Task.Run(() =>
            {
                int updateTime = transformedBitmap.Height / 20;
                int progress = 0;

                // Calculate amount to change RGB
                int amount = Convert.ToInt32(2 * (50 - brightness) * 0.01 * 255);
                for (int y = 0; y < transformedBitmap.Height; y++)
                {
                    if (y % updateTime == 0 && y != 0)
                    {
                        progress += 5;
                        requestUpdateProgressBar(progress);
                    }

                    for (int x = 0; x < transformedBitmap.Width; x++)
                    {
                        if (cancellationTokenSource.Token.IsCancellationRequested)
                            break;

                        var color = transformedBitmap.GetPixel(x, y);
                        int newRed = Math.Max(0, Math.Min(color.R - amount, 255));
                        int newGreen = Math.Max(0, Math.Min(color.G - amount, 255));
                        int newBlue = Math.Max(0, Math.Min(color.B - amount, 255));
                        var newColor = Color.FromArgb(newRed, newGreen, newBlue);
                        transformedBitmap.SetPixel(x, y, newColor);
                    }
                }
            });
        }

        
    }
}

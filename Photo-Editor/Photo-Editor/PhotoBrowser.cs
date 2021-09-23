using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Photo_Editor
{

    public partial class PhotoBrowser : Form
    {
        private string photoDirectory;
        private List<FileInfo> photoFiles;
        public ListBox.ObjectCollection Items { get; }

        //This does a thing
        public PhotoBrowser()
        {
            InitializeComponent();

            photoDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            label2.Text = photoDirectory;

            PopulateImages();
        }

        private void PopulateImages()
        {
            photoFiles = new List<FileInfo>();
            DirectoryInfo homeDir = new DirectoryInfo(photoDirectory);

            foreach (FileInfo file in homeDir.GetFiles("*.jpg"))
            {
                photoFiles.Add(file);
                PictureList.Items.Add(file.ToString());
            }
        }



        private void LaunchEditor(object sender, EventArgs e)
        {
            string x = photoDirectory + "\\" + PictureList.SelectedItems[0].Text;

            PhotoEditor photoEditor = new PhotoEditor(x);

            photoEditor.ShowDialog();
        }
    }
}

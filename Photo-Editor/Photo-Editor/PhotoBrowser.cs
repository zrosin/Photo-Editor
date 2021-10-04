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
using System.Threading;

namespace Photo_Editor
{

    public partial class PhotoBrowser : Form
    {
        private string photoDirectory;
        private List<FileInfo> photoFiles;
        public ListBox.ObjectCollection Items { get; }
        private CancellationTokenSource cancellationTokenSource;

        //This does a thing
        public PhotoBrowser()
        {
            InitializeComponent();
            
            //makes the initial directory the MyPictures directory
            photoDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            //loads the initial directory
            loadDirectory();
        }

        //loads a directory
        private async void loadDirectory()
        {
            ListDirectory(treeView1, photoDirectory);
            await PopulateImages();
        }

        //Populates the listview with the images in the selected directory
        private async Task PopulateImages()
        {
            cancellationTokenSource = new CancellationTokenSource();

            await Task.Run(() =>
            {
                photoFiles = new List<FileInfo>();
                DirectoryInfo homeDir = new DirectoryInfo(photoDirectory);

                foreach (FileInfo file in homeDir.GetFiles("*.jpg"))
                {
                       photoFiles.Add(file);
                       PictureList.Items.Add(file.ToString());


                    //Stop looping if a new directory is selected
                    if (cancellationTokenSource.Token.IsCancellationRequested)
                        break;
                }
                foreach (FileInfo file in homeDir.GetFiles("*.jpeg"))
                { 
                        photoFiles.Add(file);
                        PictureList.Items.Add(file.ToString());

                    //Stop looping if a new directory is selected
                    if (cancellationTokenSource.Token.IsCancellationRequested)
                        break;
                }
            });
           
        }


        //Opens the photo editor
        private void LaunchEditor(object sender, EventArgs e)
        {
            string x = photoDirectory + "\\" + PictureList.SelectedItems[0].Text;

            PhotoEditor photoEditor = new PhotoEditor(x);

            photoEditor.ShowDialog();
        }

        //The next two functions work together to poulate the treeview 
        //From https://stackoverflow.com/questions/6239544/populate-treeview-with-file-system-directory-structure
        private void ListDirectory(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
        }

        //From https://stackoverflow.com/questions/6239544/populate-treeview-with-file-system-directory-structure
        private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            return directoryNode;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

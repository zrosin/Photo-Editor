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

            Marqee.Hide();
            //makes the initial directory the MyPictures directory
            photoDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            //loads the initial directory
            loadDirectory();
        }

        //loads a directory
        private async void loadDirectory()
        {
            ListDirectory(directoryView, photoDirectory);
            await PopulateImages(photoDirectory);
        }

        //Populates the listview with the images in the selected directory
        private async Task PopulateImages( string directory)
        {
            cancellationTokenSource = new CancellationTokenSource();

            await Task.Run(() =>
            {
                photoFiles = new List<FileInfo>();
                DirectoryInfo homeDir = new DirectoryInfo(directory);
                ImageList largeImageList = new ImageList();
                ImageList smallImageList = new ImageList();
                largeImageList.ImageSize = new Size(100, 100);
                smallImageList.ImageSize = new Size(64, 64);
                int count = 0;
                
                
                //clear the items list for PictureList so that we can populate it with different files
                if (InvokeRequired)
                {
                    Invoke((Action)delegate ()
                    {
                        PictureList.Items.Clear();
                    });
                }
                else
                {
                    PictureList.Items.Clear();
                }
                

                if (InvokeRequired)
                {
                    Invoke((Action)delegate ()
                    {
                        Marqee.Show();
                    });
                }
                else
                {
                    Marqee.Show();
                }
                


                foreach (FileInfo file in homeDir.GetFiles("*.jpg"))
                {
                    byte[] bytes = System.IO.File.ReadAllBytes(file.FullName);
                    MemoryStream ms = new MemoryStream(bytes);
                    Image img = Image.FromStream(ms);
                    String[] buffer = { file.ToString(), file.LastWriteTime.ToString(), file.Length.ToString() + "B" };
                    ListViewItem item = new ListViewItem(buffer, count);

                    if (InvokeRequired)
                    {
                        Invoke((Action)delegate ()
                        {
                            photoFiles.Add(file);
                            PictureList.Items.Add(item);
                            largeImageList.Images.Add(img);
                            smallImageList.Images.Add(img);
                            PictureList.LargeImageList = largeImageList;
                            PictureList.SmallImageList = smallImageList;
                        });
                    }
                    else
                    {
                        photoFiles.Add(file);
                        PictureList.Items.Add(item);
                        largeImageList.Images.Add(img);
                        smallImageList.Images.Add(img);
                        PictureList.LargeImageList = largeImageList;
                        PictureList.SmallImageList = smallImageList;
                    }

                    //Stop looping if a new directory is selected
                    if (cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        if (InvokeRequired)
                        {
                            Invoke((Action)delegate ()
                            {
                                Marqee.Hide();
                            });
                        }
                        else
                        {
                            Marqee.Hide();
                        }
                        break;
                    }
                    count++;
                }

                foreach (FileInfo file in homeDir.GetFiles("*.jpeg"))
                {
                    byte[] bytes = System.IO.File.ReadAllBytes(file.FullName);
                    MemoryStream ms = new MemoryStream(bytes);
                    Image img = Image.FromStream(ms);
                    String[] buffer = { file.ToString(), file.LastWriteTime.ToString(), file.Length.ToString() + "B" };
                    ListViewItem item = new ListViewItem(buffer, count);

                    if (InvokeRequired)
                    {
                        Invoke((Action)delegate ()
                        {
                            photoFiles.Add(file);
                            PictureList.Items.Add(item);
                            largeImageList.Images.Add(img);
                            smallImageList.Images.Add(img);
                            PictureList.LargeImageList = largeImageList;
                            PictureList.SmallImageList = smallImageList;
                        });
                    }
                    else
                    {
                        photoFiles.Add(file);
                        PictureList.Items.Add(item);
                        largeImageList.Images.Add(img);
                        smallImageList.Images.Add(img);
                        PictureList.LargeImageList = largeImageList;
                        PictureList.SmallImageList = smallImageList;
                    }

                    //Stop looping if a new directory is selected
                    if (cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        if (InvokeRequired)
                        {
                            Invoke((Action)delegate ()
                            {
                                Marqee.Hide();
                            });
                        }
                        else
                        {
                            Marqee.Hide();
                        }
                        break;
                    }
                    count++;
                }
            });

            if (InvokeRequired)
            {
                Invoke((Action)delegate ()
                {
                    Marqee.Hide();
                });
            }
            else
            {
                Marqee.Hide();
            }
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

        private void directoryView_AfterSelect(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //https://stackoverflow.com/questions/11624298/how-to-use-openfiledialog-to-select-a-folder/11624322 helped me with a problem I had with opening the directory
        private void selectRootFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFolderDialog = new OpenFileDialog();
            openFolderDialog.InitialDirectory = photoDirectory;
            openFolderDialog.ValidateNames = false;
            openFolderDialog.CheckFileExists = false;
            openFolderDialog.CheckPathExists = true;
            openFolderDialog.FileName = "Folder Selection.";
            if (openFolderDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified directory
                photoDirectory = Path.GetDirectoryName(openFolderDialog.FileName);
                loadDirectory();
            }
        }
    }
}

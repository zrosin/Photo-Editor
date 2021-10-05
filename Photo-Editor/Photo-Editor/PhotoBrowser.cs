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
using System.Diagnostics;

namespace Photo_Editor
{

    public partial class PhotoBrowser : Form
    {
        private string rootDirectory, currentDirectory;
        private List<FileInfo> photoFiles;
        public ListBox.ObjectCollection Items { get; }
        private CancellationTokenSource cancellationTokenSource;

        public PhotoBrowser()
        {
            InitializeComponent();

            Marqee.Hide();
            //makes the initial directory the MyPictures directory
            rootDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            currentDirectory = rootDirectory;

            //loads the initial directory
            loadDirectory();
        }

        //loads a directory and populating the treeView
        private void loadDirectory()
        {
            ListDirectory(directoryView, rootDirectory);
        }

        //Populates the listview with the images in the selected directory
        private async Task PopulateImages( string directory)
        {
            CancellationTokenSource originalToken = cancellationTokenSource;

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
                

                //loads all images of the .jpg type
                foreach (FileInfo file in homeDir.GetFiles("*.jpg"))
                {
                    //load the file and image and puts them into a ListViewItem to be put into the list
                    byte[] bytes = System.IO.File.ReadAllBytes(file.FullName);
                    MemoryStream ms = new MemoryStream(bytes);
                    Image img = Image.FromStream(ms);
                    String[] buffer = { file.ToString(), file.LastWriteTime.ToString(), file.Length.ToString() + "B" };
                    ListViewItem item = new ListViewItem(buffer, count);

                    //Stop looping if a new directory is selected
                    if (originalToken.Token.IsCancellationRequested)
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

                    //adds the ListViewItem to the list
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


                    count++;
                }

                //loads all images of the .jpeg type
                foreach (FileInfo file in homeDir.GetFiles("*.jpeg"))
                {
                    //load the file and image and puts them into a ListViewItem to be put into the list
                    byte[] bytes = System.IO.File.ReadAllBytes(file.FullName);
                    MemoryStream ms = new MemoryStream(bytes);
                    Image img = Image.FromStream(ms);
                    String[] buffer = { file.ToString(), file.LastWriteTime.ToString(), file.Length.ToString() + "B" };
                    ListViewItem item = new ListViewItem(buffer, count);

                    //Stop looping if a new directory is selected
                    if (originalToken.Token.IsCancellationRequested)
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

                    //adds the ListViewItem to the list
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
            string x = currentDirectory + "\\" + PictureList.SelectedItems[0].Text;

            PhotoEditor photoEditor = new PhotoEditor(x);

            if (photoEditor.ShowDialog() == DialogResult.OK)
            {
                //Call function to refresh tree view


                //This isn't actually needed. Once treeview is refreshed afterselect will actually do this
                //No need to await this. It can run in background no problem.
                cancellationTokenSource.Cancel();
                cancellationTokenSource = new CancellationTokenSource();
                PopulateImages(currentDirectory);
            }
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

        //The next two listeners add functions to the tool strip
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //https://stackoverflow.com/questions/11624298/how-to-use-openfiledialog-to-select-a-folder/11624322 helped me with a problem I had with opening the directory
        private void selectRootFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFolderDialog = new OpenFileDialog();
            openFolderDialog.InitialDirectory = rootDirectory;
            openFolderDialog.ValidateNames = false;
            openFolderDialog.CheckFileExists = false;
            openFolderDialog.CheckPathExists = true;
            openFolderDialog.FileName = "Folder Selection.";
            if (openFolderDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified directory
                rootDirectory = Path.GetDirectoryName(openFolderDialog.FileName);
                loadDirectory();
            }
        }

        //Allows the user to select a new directory to display on the ListView
        private async void directoryView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (cancellationTokenSource == null || cancellationTokenSource.Token.IsCancellationRequested)
            {
                cancellationTokenSource = new CancellationTokenSource();
            }    
            else
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource = new CancellationTokenSource();
            }
                
            TreeNode selectedNode = e.Node;
            selectedNode.Expand();
            currentDirectory = Directory.GetParent(rootDirectory).FullName + "\\" + selectedNode.FullPath;
            await PopulateImages(currentDirectory);
        }

        //Next five listeners all add a function to the tool strip
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.ShowDialog();
        }

        private void detailedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureList.View = View.Details;
            smallToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = false;
        }

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureList.View = View.SmallIcon;
            detailedToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = false;
        }

        private void largeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureList.View = View.LargeIcon;
            detailedToolStripMenuItem.Checked = false;
            smallToolStripMenuItem.Checked = false;
        }

        private void locateOnDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = null;
            if (PictureList.SelectedItems.Count > 0)
            {
                filePath = currentDirectory + "\\" + PictureList.SelectedItems[0].Text;
            }
            if (File.Exists(filePath))
            {
                Process.Start(new ProcessStartInfo("explorer.exe", " /select, " + filePath));
            }
        }

        private async void directoryView_NodeMouseClick_1(object sender, TreeNodeMouseClickEventArgs e)
        {

        }
    }
}

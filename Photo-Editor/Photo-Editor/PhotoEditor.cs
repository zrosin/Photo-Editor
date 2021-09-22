using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photo_Editor
{
    public partial class PhotoEditor : Form
    {
        private string ImageLocation;

        public PhotoEditor()
        {
            InitializeComponent();
        }

        public PhotoEditor(string s)
        {
            InitializeComponent();

            this.ImageLocation = s;

            pictureBox.Image = Image.FromFile(ImageLocation);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photo_Editor
{
    public partial class ProgressBar : Form
    {
        //Delegate to cancel task
        public event CancelTransformHandler CancelTransform;
        public delegate void CancelTransformHandler();

        public ProgressBar()
        {
            InitializeComponent();
            progressBar1.Value = 0;
        }

        public void updateProgressBar(int progress)
        {
            progressBar1.Value = progress;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CancelTransform();

            Close();
        }

        private void ProgressBar_FormClosing(object sender, FormClosingEventArgs e)
        {
            CancelTransform();
        }
    }
}

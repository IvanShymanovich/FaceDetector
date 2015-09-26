using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaceDetector.Filter;

namespace FaceDetector
{
    /// <summary>
    /// Main Form of application. 
    /// Contains controls for loading of images and running face detection.
    /// </summary>
    public partial class MainForm : Form
    {
        private Bitmap Image;
        /// <summary>
        /// Constructor w/o parameters.
        /// </summary>
        /// <see cref="MainForm"/>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler on Load Image button click. Shows dialog for selection file to detect.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            if (OpenImageFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream fileStream = OpenImageFileDialog.OpenFile();
                if (fileStream != null)
                {
                    Image = new Bitmap(fileStream);
                    MainPictureBox.Image = Image;
                    ProcessButton.Enabled = true;
                }
            }
        }

        private void ProcessButton_Click(object sender, EventArgs e)
        {
            if (Image != null)
            {
//                MedianFilter medianFilter = new MedianFilter(Image, (int) medianUpDown.Value);

                MainPictureBox.Image = new MedianFilter().ApplyMedianFilter(Image, (int)medianUpDown.Value);
            }
            else
            {
                MessageBox.Show("There is no image to process. Load it and try again.");
            }
        }
    }
}

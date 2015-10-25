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
using FaceDetector.Detection;
using FaceDetector.Cascades;

namespace FaceDetector
{
    /// <summary>
    /// Main Form of application. 
    /// Contains controls for loading of images and running face detection.
    /// </summary>
    public partial class MainForm : Form
    {
        private Bitmap image;
        private HaarObjectDetector detector;
        /// <summary>
        /// Constructor w/o parameters.
        /// </summary>
        /// <see cref="MainForm"/>
        public MainForm()
        {
            InitializeComponent();
            HaarCascade cascade = new FaceHaarCascade();
            detector = new HaarObjectDetector(cascade, 30);
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
                    image = new Bitmap(fileStream);
                    MainPictureBox.Image = image;
                    ProcessButton.Enabled = true;
                }
            }
        }

        private void ProcessButton_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                
                if (MedianFilterCB.Checked) 
                    image = new MedianFilter().ApplyMedianFilter(image, (int)medianUpDown.Value);
                if (GaussianBlurFilterCB.Checked)
                    image = new GaussianBlurFilter().ApplyGaussianBlur(image,
                        new Rectangle(0, 0, image.Width, image.Height), (int)gaussianUpDown.Value);
                
                /*if (ContrastCB.Checked && contrast_textBox.Text != "100")
                {
                    int percent = Int32.Parse(contrast_textBox.Text);
                    image = new ContrastFilter().apply2(image, new Rectangle(0, 0, image.Width, image.Height), percent);
                    contrast_textBox.Text = "100";

                }
                if (ColorMatchingCB.Checked)
                {
                    image = new ColorMatchingFilter().apply(image, (int)red_numeric.Value, (int)green_numeric.Value, 
                        (int)blueNumeric.Value);
                }
                */

                detector.SearchMode = ObjectDetectorSearchMode.NoOverlap;
                detector.ScalingMode = ObjectDetectorScalingMode.SmallerToGreater;
                detector.ScalingFactor = 1.5f;
                detector.UseParallelProcessing = true;

                Rectangle[] objects = detector.ProcessFrame(image);

                if (objects.Length > 0)
                {
                    RectanglesMarker marker = new RectanglesMarker(objects, Color.Fuchsia);
                    image = ConvertToFormat(image, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    MainPictureBox.Image = marker.Apply(image);
                }

                //MainPictureBox.Image = image;
            }
            else
            {
                MessageBox.Show("There is no image to process. Load it and try again.");
            }
        }
        private static Bitmap ConvertToFormat(Bitmap source, System.Drawing.Imaging.PixelFormat format)
        {
            Bitmap copy = new Bitmap(source.Width, source.Height, format);
            using (Graphics gr = Graphics.FromImage(copy))
            {
                gr.DrawImage(source, new Rectangle(0, 0, copy.Width, copy.Height));
            }
            return copy;
        }

    }
}

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FaceDetector.Filter;
using FaceDetector.ViolaJones.Cascade;
using FaceDetector.ViolaJones;
using System.Collections.Generic;



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
        //private HaarObjectDetector noseDetector;
        //private HaarObjectDetector eyeDetector;
        //private HaarObjectDetector mouthDetector;
        /// <summary>
        /// Constructor w/o parameters.
        /// </summary>
        /// <see cref="MainForm"/>
        public MainForm()
        {
            InitializeComponent();
            detector = new HaarObjectDetector(new FaceHaarCascade());
            //noseDetector = new HaarObjectDetector(new NoseHaarCascade());
            //eyeDetector = new HaarObjectDetector(new EyeHaarCascade());
            //mouthDetector = new HaarObjectDetector(new MouthHaarCascade());
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

                if (ContrastCB.Checked && contrast_textBox.Text != "100")
                {
                    int percent = Int32.Parse(contrast_textBox.Text);
                    image = new ContrastFilter().apply2(image, new Rectangle(0, 0, image.Width, image.Height), percent);
                    contrast_textBox.Text = "100";

                }
                /*if (ColorMatchingCB.Checked)
                {
                    image = new ColorMatchingFilter().apply(image, (int)red_numeric.Value, (int)green_numeric.Value, 
                        (int)blueNumeric.Value);
                }*/


                detector.ScalingMode = ObjectDetectorScalingMode.SmallerToGreater;
                detector.ScalingFactor = 1.5f;

                Rectangle[] objects = detector.ProcessFrame(image);

                if (objects.Length > 0)
                {
                    RectanglesMarker marker = new RectanglesMarker(objects, Color.Yellow);
                    image = ConvertToFormat(image, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    image = marker.Apply(image);
                }
                MainPictureBox.Image = image;

                List<Face> faces = new List<Face>();
                foreach (var rect in objects)
                {
                    Face face = new Face(CropImage(image, rect));
                    faces.Add(face);
                    face.detectAll();
                    //MainPictureBox.Image = face.markRects();
                    //DefinePoints(CropImage(image, rect));
                }


                //MainPictureBox.Image = image;
            }
            else
            {
                MessageBox.Show("There is no image to process. Load it and try again.");
            }
        }
        public static Bitmap ConvertToFormat(Bitmap source, System.Drawing.Imaging.PixelFormat format)
        {
            Bitmap copy = new Bitmap(source.Width, source.Height, format);
            using (Graphics gr = Graphics.FromImage(copy))
            {
                gr.DrawImage(source, new Rectangle(0, 0, copy.Width, copy.Height));
            }
            return copy;
        }

        private Bitmap CropImage(Bitmap source, Rectangle section)
        {
            // An empty bitmap which will hold the cropped image
            Bitmap bmp = new Bitmap(section.Width, section.Height);

            Graphics g = Graphics.FromImage(bmp);

            // Draw the given area (section) of the source image
            // at location 0,0 on the empty bitmap (bmp)
            g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);

            return bmp;
        }

        //private void DefinePoints(Bitmap image)
        //{
        //    noseDetector.ScalingMode = ObjectDetectorScalingMode.SmallerToGreater;
        //    noseDetector.ScalingFactor = 1.5f;

        //    Rectangle[] objects = noseDetector.ProcessFrame(image);

        //    if (objects.Length > 0)
        //    {
        //        RectanglesMarker marker = new RectanglesMarker(objects, Color.Azure);
        //        image = ConvertToFormat(image, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        //        image = marker.Apply(image);
        //    }



        //    FastBitmap notModifiedBitmap = new FastBitmap(image);
        //    FastBitmap fastBitmap = new FastBitmap(image);


        //    Harries dummy = new Harries();
        //    byte[] gray = fastBitmap.GrayPixels;
        //    var ps = dummy.Corner(gray, fastBitmap.Width, fastBitmap.Height);
        //    int r = 3;
        //    var size = new Size(r, r);
        //    foreach (Point p in ps)
        //    {
        //        using (Graphics g = Graphics.FromImage(image))
        //        {
        //            g.DrawRectangle(Pens.GreenYellow, new System.Drawing.Rectangle(p, size));
        //        }
        //    }
        //    MainPictureBox.Image = image;


        //    //for (int i = 0; i < filters.Length; i++)
        //    //{
        //    //    filters[0].DoFilter(fastBitmap);
        //    //}
        //    //Parallel.For(0, fastBitmap.Width, i =>
        //    // {
        //    //     for (int j = 0; j < fastBitmap.Height; j++)
        //    //     {
        //    //         int difference = notModifiedBitmap[i, j] - fastBitmap[i, j];
        //    //         fastBitmap[i, j] = difference > 0 ? (byte)difference : (byte)0;
        //    //     }
        //    // });
        //    //List<System.Drawing.Rectangle> result = detector.getElements(fastBitmap, 1, 1.25f, 0.1f, 2, defaultRect);
        //    //foreach (System.Drawing.Rectangle rect in result)
        //    //{
        //    //    System.Drawing.Rectangle nRect = rect;
        //    //    nRect.Height /= 2;
        //    //    List<System.Drawing.Rectangle> eyeResult = eyeDetector.getElements(fastBitmap, 1, 1.25f, 0.1f, 1, nRect);
        //    //    using (Graphics g = Graphics.FromImage(image))
        //    //    {
        //    //        if (eyeResult.Count > 0) g.DrawRectangles(Pens.Blue, eyeResult.ToArray());
        //    //    }
        //    //};
        //    //using (Graphics g = Graphics.FromImage(image))
        //    //{
        //    //    if (result.Count > 0) g.DrawRectangles(Pens.GreenYellow, result.ToArray());
        //    //}
        //    //pictureBox1.Image = image;
        //}
    }
}

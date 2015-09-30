﻿using System;
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
        private Bitmap image;
        private int old_green_numeric = 6;
        private int old_red_numeric = 6;
        private int old_blue_numeric = 6;
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
                //MedianFilter medianFilter = new MedianFilter(Image, (int) medianUpDown.Value);

                //MainPictureBox.Image = new MedianFilter().ApplyMedianFilter(Image, (int)medianUpDown.Value);
                image = new GaussianBlurFilter().ApplyGaussianBlur(image,
                    new Rectangle(0, 0, image.Width, image.Height), (int)medianUpDown.Value);
                if (contrast_textBox.Text != "100")
                {
                    int percent = Int32.Parse(contrast_textBox.Text);
                    image = new ContrastFilter().apply2(image, new Rectangle(0, 0, image.Width, image.Height), percent);
                    contrast_textBox.Text = "100";

                }
                if ((int)red_numeric.Value != old_green_numeric | green_numeric.Value!=old_green_numeric |
                    old_red_numeric!=blueNumeric.Value)
                {
                    image = new ColorMatchingFilter().apply(image, (int)red_numeric.Value, (int)green_numeric.Value, 
                        (int)blueNumeric.Value);
                    old_green_numeric = (int)red_numeric.Value;
                    old_green_numeric = (int)green_numeric.Value;
                    old_red_numeric = (int)blueNumeric.Value;
                }
                

                MainPictureBox.Image = image;
            }
            else
            {
                MessageBox.Show("There is no image to process. Load it and try again.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void color_matching_label_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

    }
}

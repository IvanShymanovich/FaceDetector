namespace FaceDetector
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainControlPanel = new System.Windows.Forms.Panel();
            this.color_matching_numeric = new System.Windows.Forms.NumericUpDown();
            this.color_matching_label = new System.Windows.Forms.Label();
            this.v = new System.Windows.Forms.Label();
            this.medianUpDown = new System.Windows.Forms.NumericUpDown();
            this.ProcessButton = new System.Windows.Forms.Button();
            this.LoadImageButton = new System.Windows.Forms.Button();
            this.OpenImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.MainPictureBox = new System.Windows.Forms.PictureBox();
            this.contrast_textBox = new System.Windows.Forms.TextBox();
            this.contrast_percent = new System.Windows.Forms.Label();
            this.color_matching_label_px = new System.Windows.Forms.Label();
            this.mainControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.color_matching_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medianUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainControlPanel
            // 
            this.mainControlPanel.Controls.Add(this.color_matching_label_px);
            this.mainControlPanel.Controls.Add(this.contrast_percent);
            this.mainControlPanel.Controls.Add(this.contrast_textBox);
            this.mainControlPanel.Controls.Add(this.color_matching_numeric);
            this.mainControlPanel.Controls.Add(this.color_matching_label);
            this.mainControlPanel.Controls.Add(this.v);
            this.mainControlPanel.Controls.Add(this.medianUpDown);
            this.mainControlPanel.Controls.Add(this.ProcessButton);
            this.mainControlPanel.Controls.Add(this.LoadImageButton);
            this.mainControlPanel.Location = new System.Drawing.Point(545, 12);
            this.mainControlPanel.Name = "mainControlPanel";
            this.mainControlPanel.Size = new System.Drawing.Size(200, 337);
            this.mainControlPanel.TabIndex = 0;
            // 
            // color_matching_numeric
            // 
            this.color_matching_numeric.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.color_matching_numeric.Location = new System.Drawing.Point(122, 141);
            this.color_matching_numeric.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.color_matching_numeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.color_matching_numeric.Name = "color_matching_numeric";
            this.color_matching_numeric.Size = new System.Drawing.Size(47, 20);
            this.color_matching_numeric.TabIndex = 6;
            this.color_matching_numeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // color_matching_label
            // 
            this.color_matching_label.AutoSize = true;
            this.color_matching_label.Location = new System.Drawing.Point(3, 148);
            this.color_matching_label.Name = "color_matching_label";
            this.color_matching_label.Size = new System.Drawing.Size(77, 13);
            this.color_matching_label.TabIndex = 5;
            this.color_matching_label.Text = "Color matching";
            // 
            // v
            // 
            this.v.AutoSize = true;
            this.v.Location = new System.Drawing.Point(3, 122);
            this.v.Name = "v";
            this.v.Size = new System.Drawing.Size(46, 13);
            this.v.TabIndex = 4;
            this.v.Text = "Contrast";
            // 
            // medianUpDown
            // 
            this.medianUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.medianUpDown.Location = new System.Drawing.Point(122, 89);
            this.medianUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.medianUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.medianUpDown.Name = "medianUpDown";
            this.medianUpDown.Size = new System.Drawing.Size(47, 20);
            this.medianUpDown.TabIndex = 2;
            this.medianUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ProcessButton
            // 
            this.ProcessButton.Enabled = false;
            this.ProcessButton.Location = new System.Drawing.Point(3, 51);
            this.ProcessButton.Name = "ProcessButton";
            this.ProcessButton.Size = new System.Drawing.Size(194, 32);
            this.ProcessButton.TabIndex = 1;
            this.ProcessButton.Text = "Process";
            this.ProcessButton.UseVisualStyleBackColor = true;
            this.ProcessButton.Click += new System.EventHandler(this.ProcessButton_Click);
            // 
            // LoadImageButton
            // 
            this.LoadImageButton.Location = new System.Drawing.Point(3, 3);
            this.LoadImageButton.Name = "LoadImageButton";
            this.LoadImageButton.Size = new System.Drawing.Size(194, 33);
            this.LoadImageButton.TabIndex = 0;
            this.LoadImageButton.Text = "Load Image";
            this.LoadImageButton.UseVisualStyleBackColor = true;
            this.LoadImageButton.Click += new System.EventHandler(this.LoadImageButton_Click);
            // 
            // OpenImageFileDialog
            // 
            this.OpenImageFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.Location = new System.Drawing.Point(12, 12);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(516, 337);
            this.MainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MainPictureBox.TabIndex = 1;
            this.MainPictureBox.TabStop = false;
            // 
            // contrast_textBox
            // 
            this.contrast_textBox.Location = new System.Drawing.Point(122, 115);
            this.contrast_textBox.Name = "contrast_textBox";
            this.contrast_textBox.Size = new System.Drawing.Size(47, 20);
            this.contrast_textBox.TabIndex = 7;
            this.contrast_textBox.Text = "100";
            this.contrast_textBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // contrast_percent
            // 
            this.contrast_percent.AutoSize = true;
            this.contrast_percent.Location = new System.Drawing.Point(175, 118);
            this.contrast_percent.Name = "contrast_percent";
            this.contrast_percent.Size = new System.Drawing.Size(15, 13);
            this.contrast_percent.TabIndex = 8;
            this.contrast_percent.Text = "%";
            // 
            // color_matching_label_px
            // 
            this.color_matching_label_px.AutoSize = true;
            this.color_matching_label_px.Location = new System.Drawing.Point(175, 148);
            this.color_matching_label_px.Name = "color_matching_label_px";
            this.color_matching_label_px.Size = new System.Drawing.Size(18, 13);
            this.color_matching_label_px.TabIndex = 9;
            this.color_matching_label_px.Text = "px";
            this.color_matching_label_px.Click += new System.EventHandler(this.label1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 361);
            this.Controls.Add(this.MainPictureBox);
            this.Controls.Add(this.mainControlPanel);
            this.Name = "MainForm";
            this.Text = "Face Detector";
            this.mainControlPanel.ResumeLayout(false);
            this.mainControlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.color_matching_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medianUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainControlPanel;
        private System.Windows.Forms.Button LoadImageButton;
        private System.Windows.Forms.OpenFileDialog OpenImageFileDialog;
        private System.Windows.Forms.PictureBox MainPictureBox;
        private System.Windows.Forms.Button ProcessButton;
        private System.Windows.Forms.NumericUpDown medianUpDown;
        private System.Windows.Forms.Label v;
        private System.Windows.Forms.Label color_matching_label;
        private System.Windows.Forms.NumericUpDown color_matching_numeric;
        private System.Windows.Forms.TextBox contrast_textBox;
        private System.Windows.Forms.Label color_matching_label_px;
        private System.Windows.Forms.Label contrast_percent;
    }
}


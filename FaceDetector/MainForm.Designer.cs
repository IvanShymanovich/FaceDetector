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
            this.contrast_percent = new System.Windows.Forms.Label();
            this.contrast_textBox = new System.Windows.Forms.TextBox();
            this.red_numeric = new System.Windows.Forms.NumericUpDown();
            this.color_matching_label = new System.Windows.Forms.Label();
            this.v = new System.Windows.Forms.Label();
            this.medianUpDown = new System.Windows.Forms.NumericUpDown();
            this.ProcessButton = new System.Windows.Forms.Button();
            this.LoadImageButton = new System.Windows.Forms.Button();
            this.OpenImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.MainPictureBox = new System.Windows.Forms.PictureBox();
            this.red_label = new System.Windows.Forms.Label();
            this.gren_label = new System.Windows.Forms.Label();
            this.green_numeric = new System.Windows.Forms.NumericUpDown();
            this.blueLabel = new System.Windows.Forms.Label();
            this.blueNumeric = new System.Windows.Forms.NumericUpDown();
            this.mainControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.red_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medianUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.green_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // mainControlPanel
            // 
            this.mainControlPanel.Controls.Add(this.blueLabel);
            this.mainControlPanel.Controls.Add(this.blueNumeric);
            this.mainControlPanel.Controls.Add(this.gren_label);
            this.mainControlPanel.Controls.Add(this.green_numeric);
            this.mainControlPanel.Controls.Add(this.red_label);
            this.mainControlPanel.Controls.Add(this.contrast_percent);
            this.mainControlPanel.Controls.Add(this.contrast_textBox);
            this.mainControlPanel.Controls.Add(this.red_numeric);
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
            // contrast_percent
            // 
            this.contrast_percent.AutoSize = true;
            this.contrast_percent.Location = new System.Drawing.Point(175, 118);
            this.contrast_percent.Name = "contrast_percent";
            this.contrast_percent.Size = new System.Drawing.Size(15, 13);
            this.contrast_percent.TabIndex = 8;
            this.contrast_percent.Text = "%";
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
            // red_numeric
            // 
            this.red_numeric.DecimalPlaces = 1;
            this.red_numeric.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.red_numeric.Location = new System.Drawing.Point(6, 183);
            this.red_numeric.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.red_numeric.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.red_numeric.Name = "red_numeric";
            this.red_numeric.Size = new System.Drawing.Size(47, 20);
            this.red_numeric.TabIndex = 6;
            this.red_numeric.Value = new decimal(new int[] {
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
            this.color_matching_label.Size = new System.Drawing.Size(80, 13);
            this.color_matching_label.TabIndex = 5;
            this.color_matching_label.Text = "Color matching:";
            this.color_matching_label.Click += new System.EventHandler(this.color_matching_label_Click);
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
            // red_label
            // 
            this.red_label.AutoSize = true;
            this.red_label.Location = new System.Drawing.Point(6, 165);
            this.red_label.Name = "red_label";
            this.red_label.Size = new System.Drawing.Size(22, 13);
            this.red_label.TabIndex = 9;
            this.red_label.Text = "red";
            // 
            // gren_label
            // 
            this.gren_label.AutoSize = true;
            this.gren_label.Location = new System.Drawing.Point(59, 165);
            this.gren_label.Name = "gren_label";
            this.gren_label.Size = new System.Drawing.Size(34, 13);
            this.gren_label.TabIndex = 11;
            this.gren_label.Text = "green";
            this.gren_label.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // green_numeric
            // 
            this.green_numeric.DecimalPlaces = 1;
            this.green_numeric.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.green_numeric.Location = new System.Drawing.Point(59, 183);
            this.green_numeric.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.green_numeric.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.green_numeric.Name = "green_numeric";
            this.green_numeric.Size = new System.Drawing.Size(47, 20);
            this.green_numeric.TabIndex = 10;
            this.green_numeric.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // blueLabel
            // 
            this.blueLabel.AutoSize = true;
            this.blueLabel.Location = new System.Drawing.Point(112, 165);
            this.blueLabel.Name = "blueLabel";
            this.blueLabel.Size = new System.Drawing.Size(27, 13);
            this.blueLabel.TabIndex = 13;
            this.blueLabel.Text = "blue";
            // 
            // blueNumeric
            // 
            this.blueNumeric.DecimalPlaces = 1;
            this.blueNumeric.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.blueNumeric.Location = new System.Drawing.Point(112, 183);
            this.blueNumeric.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.blueNumeric.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.blueNumeric.Name = "blueNumeric";
            this.blueNumeric.Size = new System.Drawing.Size(47, 20);
            this.blueNumeric.TabIndex = 12;
            this.blueNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            ((System.ComponentModel.ISupportInitialize)(this.red_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medianUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.green_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueNumeric)).EndInit();
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
        private System.Windows.Forms.NumericUpDown red_numeric;
        private System.Windows.Forms.TextBox contrast_textBox;
        private System.Windows.Forms.Label contrast_percent;
        private System.Windows.Forms.Label red_label;
        private System.Windows.Forms.Label blueLabel;
        private System.Windows.Forms.NumericUpDown blueNumeric;
        private System.Windows.Forms.Label gren_label;
        private System.Windows.Forms.NumericUpDown green_numeric;
    }
}


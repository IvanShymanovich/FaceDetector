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
            this.ProcessButton = new System.Windows.Forms.Button();
            this.LoadImageButton = new System.Windows.Forms.Button();
            this.OpenImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.MainPictureBox = new System.Windows.Forms.PictureBox();
            this.medianUpDown = new System.Windows.Forms.NumericUpDown();
            this.mainControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medianUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // mainControlPanel
            // 
            this.mainControlPanel.Controls.Add(this.medianUpDown);
            this.mainControlPanel.Controls.Add(this.ProcessButton);
            this.mainControlPanel.Controls.Add(this.LoadImageButton);
            this.mainControlPanel.Location = new System.Drawing.Point(545, 12);
            this.mainControlPanel.Name = "mainControlPanel";
            this.mainControlPanel.Size = new System.Drawing.Size(200, 337);
            this.mainControlPanel.TabIndex = 0;
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
            // medianUpDown
            // 
            this.medianUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.medianUpDown.Location = new System.Drawing.Point(150, 89);
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
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medianUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainControlPanel;
        private System.Windows.Forms.Button LoadImageButton;
        private System.Windows.Forms.OpenFileDialog OpenImageFileDialog;
        private System.Windows.Forms.PictureBox MainPictureBox;
        private System.Windows.Forms.Button ProcessButton;
        private System.Windows.Forms.NumericUpDown medianUpDown;
    }
}


namespace Sfu.MNISTRecognizer.WinMords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnTestMNISTData = new System.Windows.Forms.Button();
            this.btnTrainNN = new System.Windows.Forms.Button();
            this.picDrawingImage = new System.Windows.Forms.PictureBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDrawingImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTestMNISTData
            // 
            this.btnTestMNISTData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTestMNISTData.Location = new System.Drawing.Point(12, 12);
            this.btnTestMNISTData.Name = "btnTestMNISTData";
            this.btnTestMNISTData.Size = new System.Drawing.Size(183, 40);
            this.btnTestMNISTData.TabIndex = 0;
            this.btnTestMNISTData.Text = "Test MNIST Data...";
            this.btnTestMNISTData.UseVisualStyleBackColor = true;
            this.btnTestMNISTData.Click += new System.EventHandler(this.btnTestMNISTData_Click);
            // 
            // btnTrainNN
            // 
            this.btnTrainNN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTrainNN.Location = new System.Drawing.Point(201, 12);
            this.btnTrainNN.Name = "btnTrainNN";
            this.btnTrainNN.Size = new System.Drawing.Size(215, 40);
            this.btnTrainNN.TabIndex = 1;
            this.btnTrainNN.Text = "Train Neural Network...";
            this.btnTrainNN.UseVisualStyleBackColor = true;
            this.btnTrainNN.Click += new System.EventHandler(this.btnTrainNN_Click);
            // 
            // picDrawingImage
            // 
            this.picDrawingImage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.picDrawingImage.BackColor = System.Drawing.Color.White;
            this.picDrawingImage.Location = new System.Drawing.Point(422, 80);
            this.picDrawingImage.Name = "picDrawingImage";
            this.picDrawingImage.Size = new System.Drawing.Size(280, 280);
            this.picDrawingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDrawingImage.TabIndex = 2;
            this.picDrawingImage.TabStop = false;
            this.picDrawingImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picDrawingImage_MouseDown);
            this.picDrawingImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDrawingImage_MouseMove);
            this.picDrawingImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picDrawingImage_MouseUp);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClear.Location = new System.Drawing.Point(12, 387);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(404, 40);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // rtbOutput
            // 
            this.rtbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtbOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbOutput.Location = new System.Drawing.Point(12, 58);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(404, 323);
            this.rtbOutput.TabIndex = 4;
            this.rtbOutput.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 434);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.picDrawingImage);
            this.Controls.Add(this.btnTrainNN);
            this.Controls.Add(this.btnTestMNISTData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MNIST Recognizer";
            ((System.ComponentModel.ISupportInitialize)(this.picDrawingImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestMNISTData;
        private System.Windows.Forms.Button btnTrainNN;
        private System.Windows.Forms.PictureBox picDrawingImage;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RichTextBox rtbOutput;
    }
}


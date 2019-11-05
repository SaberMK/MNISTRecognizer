namespace Sfu.MNISTRecognizer.WinMords
{
    partial class MNISTTestDataForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTrainingDataset = new System.Windows.Forms.RadioButton();
            this.rbTestDataset = new System.Windows.Forms.RadioButton();
            this.picNumber = new System.Windows.Forms.PictureBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtImageId = new System.Windows.Forms.TextBox();
            this.btnSearchOnMNIST = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblChoosenMNISTLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTestDataset);
            this.groupBox1.Controls.Add(this.rbTrainingDataset);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(31, 231);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dataset";
            // 
            // rbTrainingDataset
            // 
            this.rbTrainingDataset.AutoSize = true;
            this.rbTrainingDataset.Location = new System.Drawing.Point(25, 40);
            this.rbTrainingDataset.Name = "rbTrainingDataset";
            this.rbTrainingDataset.Size = new System.Drawing.Size(188, 29);
            this.rbTrainingDataset.TabIndex = 0;
            this.rbTrainingDataset.Text = "Training Dataset";
            this.rbTrainingDataset.UseVisualStyleBackColor = true;
            this.rbTrainingDataset.CheckedChanged += new System.EventHandler(this.rbTrainingDataset_CheckedChanged);
            // 
            // rbTestDataset
            // 
            this.rbTestDataset.AutoSize = true;
            this.rbTestDataset.Checked = true;
            this.rbTestDataset.Location = new System.Drawing.Point(25, 90);
            this.rbTestDataset.Name = "rbTestDataset";
            this.rbTestDataset.Size = new System.Drawing.Size(152, 29);
            this.rbTestDataset.TabIndex = 1;
            this.rbTestDataset.TabStop = true;
            this.rbTestDataset.Text = "Test Dataset";
            this.rbTestDataset.UseVisualStyleBackColor = true;
            this.rbTestDataset.CheckedChanged += new System.EventHandler(this.rbTestDataset_CheckedChanged);
            // 
            // picNumber
            // 
            this.picNumber.Location = new System.Drawing.Point(293, 21);
            this.picNumber.Name = "picNumber";
            this.picNumber.Size = new System.Drawing.Size(560, 560);
            this.picNumber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNumber.TabIndex = 1;
            this.picNumber.TabStop = false;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCount.Location = new System.Drawing.Point(26, 385);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(29, 25);
            this.lblCount.TabIndex = 2;
            this.lblCount.Text = "Id";
            // 
            // txtImageId
            // 
            this.txtImageId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtImageId.Location = new System.Drawing.Point(31, 426);
            this.txtImageId.Name = "txtImageId";
            this.txtImageId.Size = new System.Drawing.Size(237, 31);
            this.txtImageId.TabIndex = 3;
            // 
            // btnSearchOnMNIST
            // 
            this.btnSearchOnMNIST.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSearchOnMNIST.Location = new System.Drawing.Point(31, 473);
            this.btnSearchOnMNIST.Name = "btnSearchOnMNIST";
            this.btnSearchOnMNIST.Size = new System.Drawing.Size(237, 40);
            this.btnSearchOnMNIST.TabIndex = 4;
            this.btnSearchOnMNIST.Text = "Search On MNIST";
            this.btnSearchOnMNIST.UseVisualStyleBackColor = true;
            this.btnSearchOnMNIST.Click += new System.EventHandler(this.btnSearchOnMNIST_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(31, 532);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(237, 40);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblChoosenMNISTLabel
            // 
            this.lblChoosenMNISTLabel.AutoSize = true;
            this.lblChoosenMNISTLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblChoosenMNISTLabel.Location = new System.Drawing.Point(26, 21);
            this.lblChoosenMNISTLabel.Name = "lblChoosenMNISTLabel";
            this.lblChoosenMNISTLabel.Size = new System.Drawing.Size(0, 25);
            this.lblChoosenMNISTLabel.TabIndex = 6;
            // 
            // MNISTTestDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 589);
            this.Controls.Add(this.lblChoosenMNISTLabel);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSearchOnMNIST);
            this.Controls.Add(this.txtImageId);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.picNumber);
            this.Controls.Add(this.groupBox1);
            this.Name = "MNISTTestDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MNISTTestDataForm";
            this.Load += new System.EventHandler(this.MNISTTestDataForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbTestDataset;
        private System.Windows.Forms.RadioButton rbTrainingDataset;
        private System.Windows.Forms.PictureBox picNumber;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtImageId;
        private System.Windows.Forms.Button btnSearchOnMNIST;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblChoosenMNISTLabel;
    }
}
namespace Sfu.MNISTRecognizer.WinMords
{
    partial class TrainNeuralNetworkForm
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
            this.btnTrainNN = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTestLabelsPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTestImagesPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTrainLabelsPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTrainImagesPath = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtGeneratedModelPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTrainNN
            // 
            this.btnTrainNN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTrainNN.Location = new System.Drawing.Point(384, 156);
            this.btnTrainNN.Name = "btnTrainNN";
            this.btnTrainNN.Size = new System.Drawing.Size(366, 40);
            this.btnTrainNN.TabIndex = 2;
            this.btnTrainNN.Text = "Train Neural Network...";
            this.btnTrainNN.UseVisualStyleBackColor = true;
            this.btnTrainNN.Click += new System.EventHandler(this.btnTrainNN_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTestLabelsPath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTestImagesPath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTrainLabelsPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTrainImagesPath);
            this.groupBox1.Controls.Add(this.lblCount);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 392);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datasets";
            // 
            // txtTestLabelsPath
            // 
            this.txtTestLabelsPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTestLabelsPath.Location = new System.Drawing.Point(15, 338);
            this.txtTestLabelsPath.Name = "txtTestLabelsPath";
            this.txtTestLabelsPath.Size = new System.Drawing.Size(271, 31);
            this.txtTestLabelsPath.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(10, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Test Labels";
            // 
            // txtTestImagesPath
            // 
            this.txtTestImagesPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTestImagesPath.Location = new System.Drawing.Point(15, 253);
            this.txtTestImagesPath.Name = "txtTestImagesPath";
            this.txtTestImagesPath.Size = new System.Drawing.Size(271, 31);
            this.txtTestImagesPath.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(10, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Test Images";
            // 
            // txtTrainLabelsPath
            // 
            this.txtTrainLabelsPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTrainLabelsPath.Location = new System.Drawing.Point(15, 163);
            this.txtTrainLabelsPath.Name = "txtTrainLabelsPath";
            this.txtTrainLabelsPath.Size = new System.Drawing.Size(271, 31);
            this.txtTrainLabelsPath.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Train Labels";
            // 
            // txtTrainImagesPath
            // 
            this.txtTrainImagesPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTrainImagesPath.Location = new System.Drawing.Point(15, 78);
            this.txtTrainImagesPath.Name = "txtTrainImagesPath";
            this.txtTrainImagesPath.Size = new System.Drawing.Size(271, 31);
            this.txtTrainImagesPath.TabIndex = 5;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCount.Location = new System.Drawing.Point(10, 37);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(136, 25);
            this.lblCount.TabIndex = 4;
            this.lblCount.Text = "Train Images";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtGeneratedModelPath);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(384, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 128);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Out Model";
            // 
            // txtGeneratedModelPath
            // 
            this.txtGeneratedModelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtGeneratedModelPath.Location = new System.Drawing.Point(15, 78);
            this.txtGeneratedModelPath.Name = "txtGeneratedModelPath";
            this.txtGeneratedModelPath.Size = new System.Drawing.Size(271, 31);
            this.txtGeneratedModelPath.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(10, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(228, 25);
            this.label7.TabIndex = 4;
            this.label7.Text = "Generated Model Path";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(384, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(296, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "TODO add load/save buttons ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(384, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(378, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "TODO add logs here (ex. richTextBox)";
            // 
            // TrainNeuralNetworkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 408);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTrainNN);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrainNeuralNetworkForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Train Neural Network";
            this.Load += new System.EventHandler(this.TrainNeuralNetworkForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTrainNN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTestLabelsPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTestImagesPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTrainLabelsPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTrainImagesPath;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtGeneratedModelPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
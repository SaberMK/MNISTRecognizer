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
            this.btnTestMNISTData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTestMNISTData
            // 
            this.btnTestMNISTData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTestMNISTData.Location = new System.Drawing.Point(12, 12);
            this.btnTestMNISTData.Name = "btnTestMNISTData";
            this.btnTestMNISTData.Size = new System.Drawing.Size(199, 40);
            this.btnTestMNISTData.TabIndex = 0;
            this.btnTestMNISTData.Text = "Test MNIST Data";
            this.btnTestMNISTData.UseVisualStyleBackColor = true;
            this.btnTestMNISTData.Click += new System.EventHandler(this.btnTestMNISTData_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 812);
            this.Controls.Add(this.btnTestMNISTData);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MNIST Recognizer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestMNISTData;
    }
}


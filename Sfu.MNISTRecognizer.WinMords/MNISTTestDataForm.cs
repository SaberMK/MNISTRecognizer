using Sfu.MNISTRecognizer.MNISTWorker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sfu.MNISTRecognizer.WinMords
{
    public partial class MNISTTestDataForm : Form
    {
        MNISTDataReader _dataReader;

        public MNISTTestDataForm()
        {
            InitializeComponent();
        }

        private void MNISTTestDataForm_Load(object sender, EventArgs e)
        {
            LoadSet(@"TrainingData\t10k-images.idx3-ubyte", @"TrainingData\t10k-labels.idx1-ubyte");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rbTestDataset_CheckedChanged(object sender, EventArgs e)
        {
            LoadSet(@"TrainingData\t10k-images.idx3-ubyte", @"TrainingData\t10k-labels.idx1-ubyte");
        }


        private void rbTrainingDataset_CheckedChanged(object sender, EventArgs e)
        {
            LoadSet(@"TrainingData\train-images.idx3-ubyte", @"TrainingData\train-labels.idx1-ubyte");
        }
        private void LoadSet(string images, string labels)
        {
            _dataReader = new MNISTDataReader();
            _dataReader.Load(images, labels);

            // TODO Better output
            lblCount.Text = $"Id 0...{_dataReader.TotalCount - 1}";
            txtImageId.Text = "0";
        }

        private void btnSearchOnMNIST_Click(object sender, EventArgs e)
        {
            var bitmap = new Bitmap(_dataReader.Rows, _dataReader.Columns);

            // TODO Add Checks to txtImageId_TextChanged()
            var id = int.Parse(txtImageId.Text);

            var (byteImage, label) = _dataReader.GetImage(id);
            lblChoosenMNISTLabel.Text = label.ToString();

            for (var i = 0; i < _dataReader.Rows; ++i)
            {
                for (var j = 0; j < _dataReader.Columns; ++j)
                {
                    bitmap.SetPixel(i, j,
                        byteImage[i, j] == 0 ? Color.White : Color.Black
                        );
                }
            }

            picNumber.Image = bitmap;
        }
    }
}
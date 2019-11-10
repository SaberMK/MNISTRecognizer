using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ML;
using Sfu.MNISTRecognizer.WinMords.Configs;
using Sfu.MNISTRecognizer.WinMords.Models;

namespace Sfu.MNISTRecognizer.WinMords
{
    public partial class MainForm : Form
    {
        private Bitmap _drawArea;
        private Graphics _graphics;
        private bool _isMouseDown = false;
        private Point _lastPoint = Point.Empty;
        private float _ratio;
        private PredictionEngine<InputData, OutputData> _predictionEngine;




        public MainForm()
        {
            InitializeComponent();

            Clear();

            if (!File.Exists(DefaultFilepathesConfig.ModelPath))
            {
                MessageBox.Show("You need to produce a model first!");
            }
            else
            {
                MLContext mlContext = new MLContext();
                var trainedModel = mlContext.Model.Load(DefaultFilepathesConfig.ModelPath, out var modelInputSchema);
                _predictionEngine = mlContext.Model.CreatePredictionEngine<InputData, OutputData>(trainedModel);
            }


            picDrawingImage.Image = _drawArea;
            _graphics = picDrawingImage.CreateGraphics();

            _ratio = (((float)_drawArea.Width / picDrawingImage.Width) + ((float)_drawArea.Height / picDrawingImage.Height)) / 2.0f;
        }



        #region TEST 1111111111111111111111111111111

        MNISTWorker.MNISTDataReader _dataReader;
     
        private void LoadSet(string images, string labels)
        {
            _dataReader = new MNISTWorker.MNISTDataReader();
            _dataReader.Load(images, labels);

            // TODO Better output
            //lblCount.Text = $"Id 0...{_dataReader.TotalCount - 1}";
            //txtImageId.Text = "0";
        }
        #endregion


        private InputData TransformModel()
        {
            #region TEST 2222222222222222222222222222222222222222

            //LoadSet(@"TrainingData\t10k-images.idx3-ubyte", @"TrainingData\t10k-labels.idx1-ubyte");
            //LoadSet(@"TrainingData\t10k-images.idx3-ubyte", @"TrainingData\t10k-labels.idx1-ubyte");
            //LoadSet(@"TrainingData\train-images.idx3-ubyte", @"TrainingData\train-labels.idx1-ubyte");

            //var bitmap = new Bitmap(_dataReader.Rows, _dataReader.Columns);

            //// TODO Add Checks to txtImageId_TextChanged()
            //var r = new Random();
            //var id = r.Next(0, 4000);

            //var (byteImage, label) = _dataReader.GetImage(id);
            ////////////lblChoosenMNISTLabel.Text = label.ToString();

            //for (var i = 0; i < _dataReader.Rows; ++i)
            //{
            //    for (var j = 0; j < _dataReader.Columns; ++j)
            //    {
            //        bitmap.SetPixel(i, j,
            //            byteImage[i, j] == 0 ? Color.White : Color.Black
            //            );


            //        // TEST
            //        ///////////////byteImage[i, j] = byteImage[i, j] > 0 ? (byte)254 : (byte)0;


            //        Console.Write($"{byteImage[i, j]}\t");
            //    }
            //    Console.Write('\n');
            //}

            //picDrawingImage.Image = _drawArea = bitmap;

            //return GeeeeeeeeeeeeeeeeeeeetModel(byteImage);
            #endregion






            var size = _drawArea.Width * _drawArea.Height;

            var byteImage = new byte[_drawArea.Width, _drawArea.Height];

            //////////var line = new float[size];
            var currentPosition = 0;
            for (int x = 0; x < _drawArea.Width; ++x)
            {
                for (int y = 0; y < _drawArea.Height; ++y)
                {
                    var rgb = _drawArea.GetPixel(x, y);
                    if (rgb.R == 255 && rgb.G == 255 && rgb.B == 255) // if white
                    {
                        ////////line[currentPosition] = 0;
                        byteImage[x, y] = 0;
                    }
                    else
                    {
                        ////////line[currentPosition] = 254;
                        byteImage[x, y] = 254;
                    }

                    Console.Write($"{byteImage[x, y]}\t"); // DEBUG

                    currentPosition++;
                }
                Console.Write('\n');// DEBUG
            }

            return GeeeeeeeeeeeeeeeeeeeetModel(byteImage);
        }


        private static InputData GeeeeeeeeeeeeeeeeeeeetModel(byte[,] data)
        {
            var rCount = data.GetLength(0);
            var cCount = data.GetLength(1);
            var size = rCount * cCount;

            var currentLine = new float[size];
            var currentPosition = 0;
            for (int x = 0; x < rCount; ++x)
            {
                for (int y = 0; y < cCount; ++y)
                {
                    currentLine[currentPosition] = data[x, y];
                    currentPosition++;
                }
            }

            return new InputData
            {
                PixelValues = currentLine,
            };
        }








        private void btnTestMNISTData_Click(object sender, EventArgs e)
        {
            Hide();
            new MNISTTestDataForm().ShowDialog();
            Show();
        }

        private void btnTrainNN_Click(object sender, EventArgs e)
        {
            Hide();
            new TrainNeuralNetworkForm().ShowDialog();
            Show();
        }

        private void picDrawingImage_MouseDown(object sender, MouseEventArgs e)
        {
            _lastPoint = new Point((int)(e.Location.X * _ratio), (int)(e.Location.Y * _ratio));
            _isMouseDown = true;
        }

        private void picDrawingImage_MouseUp(object sender, MouseEventArgs e)
        {
            _lastPoint = Point.Empty;
            _isMouseDown = false;
            ///////////////////SaveToFile();
            SValidate();
        }

        private void SValidate()
        {
            var data = TransformModel();
            var predictionResult = _predictionEngine.Predict(data);

            // TODO: To StringBuilder;
            var logString = string.Empty;

            for (int i = 0; i < 10; ++i)
            {
                logString += $"'{i}': \t'{Math.Round(double.Parse(predictionResult.Score[i].ToString()), 4)}'\n";
            }


            var maxValue = predictionResult.Score.Max();
            var bestPredict = predictionResult.Score.ToList().IndexOf(maxValue);

            logString += $"Prediction is {bestPredict}";

            rtbOutput.Text = logString;
        }

        private void picDrawingImage_MouseMove(object sender, MouseEventArgs e)
        {
            var updatedPoint = new Point((int)(e.Location.X * _ratio), (int)(e.Location.Y * _ratio));

            if (_isMouseDown == true && _lastPoint != null)
            {
                //_drawArea.SetPixel(updatedPoint.X, updatedPoint.Y, Color.Black);

                for (int x = updatedPoint.X - 1; x < updatedPoint.X + 1; ++x)
                {
                    for (int y = updatedPoint.Y - 1; y < updatedPoint.Y + 1; ++y)
                    {
                        _drawArea.SetPixel(x, y, Color.Black);

                    }
                }
            }

            picDrawingImage.Invalidate();

            _lastPoint = updatedPoint;
        }

        public void SaveToFile()
        {
            byte[] data = ImageToByte(picDrawingImage.Image);

            StringBuilder hex = new StringBuilder();
            //string format = "{0}";
            int c = 0;
            foreach (byte b in data)
            {
                hex.AppendFormat("{0}\t", b);
                //format = "{0}\t";
                if (c < 27)
                {
                    c++;
                }
                else
                {
                    hex.Append('\n');
                    c = 0;
                }
            }

            File.WriteAllText("img-input.txt", hex.ToString());
        }

        public static byte[] ImageToByte(Image img)
        {
            // as png
            var imageFile = "img-input.png";
            img.Save(imageFile, ImageFormat.Png);

            // 222
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Png);
            return ms.ToArray();

            // to byte
            //ImageConverter converter = new ImageConverter();
            //return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            rtbOutput.Clear();

            _drawArea = new Bitmap(28, 28);
            for (int i = 0; i < 28; ++i)
            {
                for (int j = 0; j < 28; ++j)
                {
                    _drawArea.SetPixel(i, j, Color.White);
                }
            }
            picDrawingImage.Image = _drawArea;
        }
    }
}
using Microsoft.ML;
using Sfu.MNISTRecognizer.WinMords.Configs;
using Sfu.MNISTRecognizer.WinMords.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            if (!File.Exists(DefaultFilepathesConfig.DefaultTrainingDataPath))
            {
                MessageBox.Show("You need to produce a model first!");
            }                
            else
            {
                MLContext mlContext = new MLContext();
                var trainedModel = mlContext.Model.Load("model.bin", out var modelInputSchema);
                _predictionEngine = mlContext.Model.CreatePredictionEngine<InputData, OutputData>(trainedModel);
            }


            picDrawingImage.Image = _drawArea;
            _graphics = picDrawingImage.CreateGraphics();

            _ratio = (((float)_drawArea.Width / picDrawingImage.Width) + ((float)_drawArea.Height / picDrawingImage.Height)) / 2.0f;
        }

        private void Validate()
        {
            var data = TransformModel();
            var predictionResult = _predictionEngine.Predict(data);

            // TODO: To StringBuilder;
            var logString = string.Empty;

            for(int i = 0; i < 10; ++i)
            {
                logString += $"'{i}': {predictionResult.Score}\n";
            }


            var maxValue = predictionResult.Score.Max();
            var bestPredict = predictionResult.Score.ToList().IndexOf(maxValue);

            logString += $"Prediction is {bestPredict}";

            rtbOutput.Text = logString;
        }

        private InputData TransformModel()
        {
            var size = _drawArea.Width * _drawArea.Height;

            var line = new float[size];
            var currentPosition = 0;
            for (int x = 0; x < _drawArea.Width; ++x)
            {
                for (int y = 0; y < _drawArea.Height; ++y)
                {
                    line[currentPosition] = _drawArea.GetPixel(x, y) == Color.Black ? 1 : 0;
                    currentPosition++;
                }
            }

            return new InputData
            {
                PixelValues = line
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
        }

        private void picDrawingImage_MouseMove(object sender, MouseEventArgs e)
        {
            var updatedPoint = new Point((int)(e.Location.X * _ratio), (int)(e.Location.Y * _ratio));

            if (_isMouseDown == true && _lastPoint != null)
            {
                _drawArea.SetPixel(updatedPoint.X, updatedPoint.Y, Color.Black);
            }

            picDrawingImage.Invalidate();

            _lastPoint = updatedPoint;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            _drawArea = new Bitmap(28, 28);
            for (int i = 0; i < 28; ++i)
                for (int j = 0; j < 28; ++j)
                    _drawArea.SetPixel(i, j, Color.White);
        }
    }
}

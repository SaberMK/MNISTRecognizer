using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sfu.MNISTRecognizer.WinMords
{
    public partial class MainForm : Form
    {
        private readonly Bitmap _drawArea;

        private Graphics _graphics;
        private bool _isMouseDown = false;
        private Point _lastPoint = Point.Empty;
        private double _ratio;
        public MainForm()
        {
            InitializeComponent();

            _drawArea = new Bitmap(28, 28);
            for (int i = 0; i < 28; ++i)
                for (int j = 0; j < 28; ++j)
                    _drawArea.SetPixel(i, j, Color.White);

            picDrawingImage.Image = _drawArea;
            _graphics = picDrawingImage.CreateGraphics();

            _ratio = ((_drawArea.Width / picDrawingImage.Width) + (_drawArea.Height / picDrawingImage.Height)) / 2;
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
            _lastPoint = e.Location;
            _isMouseDown = true;
        }

        private void picDrawingImage_MouseUp(object sender, MouseEventArgs e)
        {
            _lastPoint = Point.Empty;
            _isMouseDown = false;
        }

        private void picDrawingImage_MouseMove(object sender, MouseEventArgs e)
        {

            if (_isMouseDown == true && _lastPoint != null)
            {
                
            }

            picDrawingImage.Invalidate();

            _lastPoint = e.Location;
        }
    }
}

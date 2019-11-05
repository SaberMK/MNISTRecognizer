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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnTestMNISTData_Click(object sender, EventArgs e)
        {
            Hide();
            new MNISTTestDataForm().ShowDialog();
            Show();
        }
    }
}

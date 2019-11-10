using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfu.MNISTRecognizer.WinMords.Models
{
    public class OutputData
    {
        [ColumnName("Score")]
        public float[] Score;
    }
}

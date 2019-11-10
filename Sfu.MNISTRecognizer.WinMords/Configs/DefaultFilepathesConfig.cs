using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfu.MNISTRecognizer.WinMords.Configs
{
    public class DefaultFilepathesConfig
    {
        public static string DefaultTrainingDataPath => AppDomain.CurrentDomain.BaseDirectory + "TrainingData";

        public static string TrainImagesPath = Path.Combine(DefaultTrainingDataPath, "train-images.idx3-ubyte");

        public static string TrainLabelsPath = Path.Combine(DefaultTrainingDataPath, "train-labels.idx1-ubyte");

        public static string TestImagesPath = Path.Combine(DefaultTrainingDataPath, "t10k-images.idx3-ubyte");

        public static string TestLabelsPath = Path.Combine(DefaultTrainingDataPath, "t10k-labels.idx1-ubyte");

        public static string TrainCsvPath = Path.Combine(Path.GetTempPath(), "train.csv");

        public static string TestCsvPath = Path.Combine(Path.GetTempPath(), "test.csv");

        public static string ModelPath = Path.Combine(DefaultTrainingDataPath, "brain.bin");
    }
}
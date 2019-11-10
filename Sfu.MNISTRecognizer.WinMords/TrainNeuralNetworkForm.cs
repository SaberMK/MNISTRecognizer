using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;
using Sfu.MNISTRecognizer.MNISTWorker;
using Sfu.MNISTRecognizer.WinMords.Configs;
using Sfu.MNISTRecognizer.WinMords.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sfu.MNISTRecognizer.WinMords
{
    public partial class TrainNeuralNetworkForm : Form
    {
        private readonly MLContext _mlContext;
        private readonly MNISTDataReader _mnistTrain = new MNISTDataReader();
        private readonly MNISTDataReader _mnistTest = new MNISTDataReader();




        public TrainNeuralNetworkForm()
        {
            InitializeComponent();
            _mlContext = new MLContext();
        }

        private void TrainNeuralNetworkForm_Load(object sender, EventArgs e)
        {
            txtTrainImagesPath.Text = DefaultFilepathesConfig.TrainImagesPath;
            txtTrainLabelsPath.Text = DefaultFilepathesConfig.TrainLabelsPath;
            txtTestImagesPath.Text = DefaultFilepathesConfig.TestImagesPath;
            txtTestLabelsPath.Text = DefaultFilepathesConfig.TestLabelsPath;

            txtGeneratedModelPath.Text = DefaultFilepathesConfig.ModelPath;
        }


        private void btnTrainNN_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
                {
                    Train();
                    MessageBox.Show("Done!");
                }
            );
        }

        private void Train()
        {
            _mnistTrain.Load(txtTrainImagesPath.Text, txtTrainLabelsPath.Text);
            _mnistTest.Load(txtTestImagesPath.Text, txtTestLabelsPath.Text);

            PrepareData(_mnistTrain, DefaultFilepathesConfig.TrainCsvPath, 50000);
            PrepareData(_mnistTest, DefaultFilepathesConfig.TestCsvPath, 10000);

            var trainData = _mlContext.Data.LoadFromTextFile(path: DefaultFilepathesConfig.TrainCsvPath,
                columns: new[]
                {
                    new TextLoader.Column(nameof(InputData.PixelValues), DataKind.Single, 0, 783),
                    new TextLoader.Column(nameof(InputData.Number), DataKind.Single, 784)
                },
                hasHeader: false,
                separatorChar: ','
                );

            var testData = _mlContext.Data.LoadFromTextFile(path: DefaultFilepathesConfig.TestCsvPath,
                columns: new[]
                {
                    new TextLoader.Column(nameof(InputData.PixelValues), DataKind.Single, 0, 783),
                    new TextLoader.Column(nameof(InputData.Number), DataKind.Single, 784)
                },
                hasHeader: false,
                separatorChar: ','
                );

            var dataProcessPipeline = _mlContext.Transforms.Conversion.MapValueToKey("Label", "Number", keyOrdinality: ValueToKeyMappingEstimator.KeyOrdinality.ByValue).
                   Append(_mlContext.Transforms.Concatenate("Features", nameof(InputData.PixelValues)).AppendCacheCheckpoint(_mlContext));

            var trainer = _mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy(labelColumnName: "Label", featureColumnName: "Features");
            var trainingPipeline = dataProcessPipeline.Append(trainer).Append(_mlContext.Transforms.Conversion.MapKeyToValue("Number", "Label"));

            // System.Console.WriteLine("=============== Training the model ===============");
            ITransformer trainedModel = trainingPipeline.Fit(trainData);

            // System.Console.WriteLine("===== Evaluating Model's accuracy with Test data =====");
            var predictions = trainedModel.Transform(testData);
            var metrics = _mlContext.MulticlassClassification.Evaluate(data: predictions, labelColumnName: "Number", scoreColumnName: "Score");

            var whereToSaveModel = txtGeneratedModelPath.Text;
            _mlContext.Model.Save(trainedModel, trainData.Schema, whereToSaveModel);

            // System.Console.WriteLine($"The model is saved to {whereToSaveModel}");
        }

        private void PrepareData(MNISTDataReader mnistData, string filename, int count)
        {
            var size = mnistData.Rows * mnistData.Columns + 1;
            var allData = new List<string>();
            for (int i = 0; i < count; ++i)
            {
                var currentLine = new byte[size];
                var (data, label) = mnistData.GetImage(i);

                var currentPosition = 0;
                for (int x = 0; x < mnistData.Rows; ++x)
                {
                    for (int y = 0; y < mnistData.Columns; ++y)
                    {
                        currentLine[currentPosition] = data[x, y];
                        currentPosition++;
                    }
                }
                currentLine[currentPosition] = (byte)label;
                allData.Add(string.Join(",", currentLine));
            }

            File.WriteAllLines(filename, allData);
        }
    }
}
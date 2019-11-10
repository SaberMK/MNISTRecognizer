using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfu.MNISTRecognizer.ConsoleApp
{
    public class OutputData
    {
        [ColumnName("Score")]
        public float[] Score;
    }
    public class InputData
    {
        [ColumnName("PixelValues")]
        [VectorType(784)]
        public float[] PixelValues;

        [LoadColumn(784)]
        public float Number;
    }
    public class Program
    {
        private static string BaseDatasetsRelativePath = @"TrainingData";
        private static string trainImagesPath = $"{BaseDatasetsRelativePath}/train-images.idx3-ubyte";
        private static string trainLabelsPath = $"{BaseDatasetsRelativePath}/train-labels.idx1-ubyte";

        private static string testImagesPath = $"{BaseDatasetsRelativePath}/t10k-images.idx3-ubyte";
        private static string testLabelsPath = $"{BaseDatasetsRelativePath}/t10k-labels.idx1-ubyte";
        
        static void Main(string[] args)
        {
            MLContext mlContext = new MLContext();
            
            Train(mlContext);

            TestSomePredictions(mlContext);
        }

        private static void TestSomePredictions(MLContext mlContext)
        {
            ITransformer trainedModel = mlContext.Model.Load("model.bin", out var modelInputSchema);

            var predEngine = mlContext.Model.CreatePredictionEngine<InputData, OutputData>(trainedModel);

        //https://medium.com/scisharp/neural-network-in-tensorflow-net-1c3c4845bbee

            for(int i = 0;i<200; ++i)
            {
                var model = GetModel(mnistTest, 1000 + i * 5);
                var resultPrediction = predEngine.Predict(model);

                Console.WriteLine($"Actual: {model.Number}     Predicted probability:       zero:  {resultPrediction.Score[0]:0.####}");
                Console.WriteLine($"                                           One :  {resultPrediction.Score[1]:0.####}");
                Console.WriteLine($"                                           two:   {resultPrediction.Score[2]:0.####}");
                Console.WriteLine($"                                           three: {resultPrediction.Score[3]:0.####}");
                Console.WriteLine($"                                           four:  {resultPrediction.Score[4]:0.####}");
                Console.WriteLine($"                                           five:  {resultPrediction.Score[5]:0.####}");
                Console.WriteLine($"                                           six:   {resultPrediction.Score[6]:0.####}");
                Console.WriteLine($"                                           seven: {resultPrediction.Score[7]:0.####}");
                Console.WriteLine($"                                           eight: {resultPrediction.Score[8]:0.####}");
                Console.WriteLine($"                                           nine:  {resultPrediction.Score[9]:0.####}");
                Console.WriteLine();
            }

            //var m1 = GetModel(mnistTest, 100);
            //var m2 = GetModel(mnistTest, 200);
            //var m3 = GetModel(mnistTest, 300);

            //var resultprediction1 = predEngine.Predict(m1);
            //var resultprediction2 = predEngine.Predict(m2);
            //var resultprediction3 = predEngine.Predict(m3);

            //Console.WriteLine($"Actual: {m1.Number}     Predicted probability:       zero:  {resultprediction1.Score[0]:0.####}");
            //Console.WriteLine($"                                           One :  {resultprediction1.Score[1]:0.####}");
            //Console.WriteLine($"                                           two:   {resultprediction1.Score[2]:0.####}");
            //Console.WriteLine($"                                           three: {resultprediction1.Score[3]:0.####}");
            //Console.WriteLine($"                                           four:  {resultprediction1.Score[4]:0.####}");
            //Console.WriteLine($"                                           five:  {resultprediction1.Score[5]:0.####}");
            //Console.WriteLine($"                                           six:   {resultprediction1.Score[6]:0.####}");
            //Console.WriteLine($"                                           seven: {resultprediction1.Score[7]:0.####}");
            //Console.WriteLine($"                                           eight: {resultprediction1.Score[8]:0.####}");
            //Console.WriteLine($"                                           nine:  {resultprediction1.Score[9]:0.####}");
            //Console.WriteLine();
            //Console.WriteLine($"Actual: {m2.Number}     Predicted probability:       zero:  {resultprediction2.Score[0]:0.####}");
            //Console.WriteLine($"                                           One :  {resultprediction2.Score[1]:0.####}");
            //Console.WriteLine($"                                           two:   {resultprediction2.Score[2]:0.####}");
            //Console.WriteLine($"                                           three: {resultprediction2.Score[3]:0.####}");
            //Console.WriteLine($"                                           four:  {resultprediction2.Score[4]:0.####}");
            //Console.WriteLine($"                                           five:  {resultprediction2.Score[5]:0.####}");
            //Console.WriteLine($"                                           six:   {resultprediction2.Score[6]:0.####}");
            //Console.WriteLine($"                                           seven: {resultprediction2.Score[7]:0.####}");
            //Console.WriteLine($"                                           eight: {resultprediction2.Score[8]:0.####}");
            //Console.WriteLine($"                                           nine:  {resultprediction2.Score[9]:0.####}");
            //Console.WriteLine();
            //Console.WriteLine($"Actual: {m3.Number}     Predicted probability:       zero:  {resultprediction3.Score[0]:0.####}");
            //Console.WriteLine($"                                           One :  {resultprediction3.Score[1]:0.####}");
            //Console.WriteLine($"                                           two:   {resultprediction3.Score[2]:0.####}");
            //Console.WriteLine($"                                           three: {resultprediction3.Score[3]:0.####}");
            //Console.WriteLine($"                                           four:  {resultprediction3.Score[4]:0.####}");
            //Console.WriteLine($"                                           five:  {resultprediction3.Score[5]:0.####}");
            //Console.WriteLine($"                                           six:   {resultprediction3.Score[6]:0.####}");
            //Console.WriteLine($"                                           seven: {resultprediction3.Score[7]:0.####}");
            //Console.WriteLine($"                                           eight: {resultprediction3.Score[8]:0.####}");
            //Console.WriteLine($"                                           nine:  {resultprediction3.Score[9]:0.####}");
            //Console.WriteLine();

            Console.ReadLine();
            Console.ReadKey();

            Console.ReadLine();
            Console.ReadKey();

            Console.ReadLine();


            Console.ReadLine();

            Console.ReadLine();

            Console.ReadLine();

            Console.ReadLine();
            Console.ReadKey();
            Console.ReadKey();

            Console.ReadKey();
            Console.ReadKey();
            Console.ReadKey();
        }

        private static InputData GetModel(MNISTDataReader mnist, int index)
        {
            var (data, label) = mnist.GetImage(index);

            var size = mnist.Rows * mnist.Columns;

            var currentLine = new float[size];
            var currentPosition = 0;
            for (int x = 0; x < mnist.Rows; ++x)
            {
                for (int y = 0; y < mnist.Columns; ++y)
                {
                    currentLine[currentPosition] = data[x, y];
                    currentPosition++;
                }
            }

            return new InputData
            {
                PixelValues = currentLine,
                Number = (byte)label
            };
        }

        static MNISTDataReader mnistTrain;
        static MNISTDataReader mnistTest;

        private static void Train(MLContext mlContext)
        {
            mnistTrain = new MNISTDataReader();
            mnistTrain.Load(trainImagesPath, trainLabelsPath);

            mnistTest = new MNISTDataReader();
            mnistTest.Load(testImagesPath, testLabelsPath);

            PrepareDataForTest(mnistTrain, "train.csv" , 50000);
            PrepareDataForTest(mnistTest, "labels.csv", 10000);

            var trainData = mlContext.Data.LoadFromTextFile(path: "train.csv",
                columns: new[]
                {
                    new TextLoader.Column(nameof(InputData.PixelValues), DataKind.Single, 0, 783),
                    new TextLoader.Column(nameof(InputData.Number), DataKind.Single, 784)
                },
                hasHeader: false,
                separatorChar: ','
                );

            var testData = mlContext.Data.LoadFromTextFile(path: "labels.csv",
                columns: new[]
                {
                    new TextLoader.Column(nameof(InputData.PixelValues), DataKind.Single, 0, 783),
                    new TextLoader.Column(nameof(InputData.Number), DataKind.Single, 784)
                },
                hasHeader: false,
                separatorChar: ','
                );

            var dataProcessPipeline = mlContext.Transforms.Conversion.MapValueToKey("Label", "Number", keyOrdinality: ValueToKeyMappingEstimator.KeyOrdinality.ByValue).
                    Append(mlContext.Transforms.Concatenate("Features", nameof(InputData.PixelValues)).AppendCacheCheckpoint(mlContext));

            var trainer = mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy(labelColumnName: "Label", featureColumnName: "Features");
            var trainingPipeline = dataProcessPipeline.Append(trainer).Append(mlContext.Transforms.Conversion.MapKeyToValue("Number", "Label"));

            System.Console.WriteLine("=============== Training the model ===============");
            ITransformer trainedModel = trainingPipeline.Fit(trainData);

            System.Console.WriteLine("===== Evaluating Model's accuracy with Test data =====");
            var predictions = trainedModel.Transform(testData);
            var metrics = mlContext.MulticlassClassification.Evaluate(data: predictions, labelColumnName: "Number", scoreColumnName: "Score");

            //Common.ConsoleHelper.PrintMultiClassClassificationMetrics(trainer.ToString(), metrics);

            mlContext.Model.Save(trainedModel, trainData.Schema, "model.bin");

            System.Console.WriteLine("The model is saved to {0}", "model.bin");

            //var train = PrepareData(mnistTrain);
            //var test = PrepareData(mnistLabels);

            //var trainData = mlContext.Data.LoadFromEnumerable(train);
            //var testData = mlContext.Data.LoadFromEnumerable(test);

            //var dataProcessPipeline = mlContext.Transforms.Conversion.MapValueToKey("Image", "Label", keyOrdinality: ValueToKeyMappingEstimator.KeyOrdinality.ByValue)
            //    .Append(mlContext.Transforms.Concatenate())

        }

        private static void PrepareDataForTest(MNISTDataReader mnistData, string filename, int count)
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

        //public class DataArray
        //{
        //    public byte[] Image { get; set; }
        //    public int Label { get; set; }
        //}

        //private static IEnumerable<DataArray> PrepareData(MNISTDataReader mnistData)
        //{
        //    var size = mnistData.Rows * mnistData.Columns;
        //    for (int i = 0; i < trainCount; ++i)
        //    {
        //        var currentLine = new byte[size];
        //        var (data, label) = mnistData.GetImage(i);

        //        var currentPosition = 0;
        //        for (int x = 0; x < mnistData.Rows; ++x)
        //        {
        //            for (int y = 0; y < mnistData.Columns; ++y)
        //            {
        //                currentLine[currentPosition] = data[x, y];
        //                currentPosition++;
        //            }
        //        }

        //        yield return new DataArray
        //        {
        //            Image = currentLine,
        //            Label = label
        //        };
        //    }            
        //}
    }

    public class MNISTDataReader
    {
        private FileStream _mnistImagesReader;
        private FileStream _mnistLabelsReader;

        public int TotalCount { get; private set; }
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public void Load(string imagesFilePath, string labelsFilePath)
        {
            //var baseFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));

            //baseFolder =  Path.Combine(baseFolder, @"Sfu.MNISTRecognizer.WinMords\bin\Debug\TrainingData");

            //imagesFilePath = Path.Combine(baseFolder, imagesFilePath);
            //labelsFilePath = Path.Combine(baseFolder, labelsFilePath);

            var baseFolder = AppDomain.CurrentDomain.BaseDirectory;
            imagesFilePath = Path.Combine(baseFolder, imagesFilePath);
            labelsFilePath = Path.Combine(baseFolder, labelsFilePath);

            if (!File.Exists(imagesFilePath))
                throw new FileNotFoundException($"Images file {imagesFilePath} not found!");

            if (!File.Exists(labelsFilePath))
                throw new FileNotFoundException($"Labels file {labelsFilePath} not found!");

            _mnistImagesReader = new FileStream(imagesFilePath, FileMode.Open, FileAccess.Read);
            _mnistLabelsReader = new FileStream(labelsFilePath, FileMode.Open, FileAccess.Read);

            LoadMetadata();
        }

        public (byte[,], int) GetImage(int id, bool loadBinary = false)
        {
            if (id < 0 || id >= TotalCount)
                throw new ArgumentOutOfRangeException($"Id must be greater than zero and less than total number. Current: {id}");

            if (_mnistImagesReader == null || _mnistLabelsReader == null)
                throw new ArgumentNullException("You need to perform Load(imagepath, labelpath) method first!");

            var image = new byte[Rows, Columns];
            var imageSize = Rows * Columns;

            _mnistLabelsReader.Position = MNIST_LABELS_DATA_OFFSET + id;
            var label = (byte)_mnistLabelsReader.ReadByte();

            _mnistImagesReader.Position = MNIST_IMAGE_DATA_OFFSET + imageSize * id;

            for (var i = 0; i < Rows; ++i)
                for (var j = 0; j < Columns; ++j)
                {
                    var result = _mnistImagesReader.ReadByte();

                    if (loadBinary)
                        result = result > 0 ? 1 : 0;

                    image[j, i] = (byte)result;
                }


            return (image, label);
        }

        private void LoadMetadata()
        {
            var buff = new byte[4];

            _mnistImagesReader.Read(buff, 0, 4);
            var magicImagesNumber = BitConverter.ToUInt32(buff.Reverse().ToArray(), 0);

            if (magicImagesNumber != MNIST_MAGIC_IMAGES_NUMBER)
                throw new InvalidDataException("Images file is corrupted!");

            _mnistLabelsReader.Read(buff, 0, 4);
            var magicLabelsNumber = BitConverter.ToUInt32(buff.Reverse().ToArray(), 0);

            if (magicLabelsNumber != MNIST_MAGIC_LABELS_NUMBER)
                throw new InvalidDataException("Labels file is corrupted!");


            _mnistImagesReader.Read(buff, 0, 4);
            TotalCount = BitConverter.ToInt32(buff.Reverse().ToArray(), 0);

            _mnistLabelsReader.Read(buff, 0, 4);
            if (TotalCount != BitConverter.ToInt32(buff.Reverse().ToArray(), 0))
                throw new InvalidDataException("Files containment are different");

            _mnistImagesReader.Read(buff, 0, 4);
            Rows = BitConverter.ToInt32(buff.Reverse().ToArray(), 0);

            _mnistImagesReader.Read(buff, 0, 4);
            Columns = BitConverter.ToInt32(buff.Reverse().ToArray(), 0);
        }

        ~MNISTDataReader()
        {
            _mnistImagesReader?.Dispose();
            _mnistLabelsReader?.Dispose();
        }

        private const int MNIST_MAGIC_IMAGES_NUMBER = 2051;
        private const int MNIST_MAGIC_LABELS_NUMBER = 2049;

        private const int MNIST_IMAGE_DATA_OFFSET = 16;
        private const int MNIST_LABELS_DATA_OFFSET = 8;
    }
}

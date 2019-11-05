using Sfu.MNISTRecognizer.WinMords;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfu.MNISTRecognizer.MNISTWorker
{
    public class MNISTDataReader
    {
        private FileStream _mnistImagesReader;
        private FileStream _mnistLabelsReader;

        private int _totalCount;
        private int _rows;
        private int _columns;

        public void Load(string imagesFilePath, string labelsFilePath)
        {
            var baseFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            
            baseFolder =  Path.Combine(baseFolder, @"Sfu.MNISTRecognizer.WinMords\bin\Debug\TrainingData");

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

        public (byte[,], int) GetImage(int id)
        {
            if (id < 0 || id >= _totalCount)
                throw new ArgumentOutOfRangeException($"Id must be greater than zero and less than total number. Current: {id}");

            if (_mnistImagesReader == null || _mnistLabelsReader == null)
                throw new ArgumentNullException("You need to perform Load(imagepath, labelpath) method first!");
            
            var image = new byte[_rows, _columns];
            var imageSize = _rows * _columns;

            _mnistLabelsReader.Position = MNIST_LABELS_DATA_OFFSET + id;
            var label = (byte)_mnistLabelsReader.ReadByte();

            _mnistImagesReader.Position = MNIST_IMAGE_DATA_OFFSET + imageSize * id;

            for (var i = 0; i < _rows; ++i)
                for (var j = 0; j < _columns; ++j)
                    image[i, j] = (byte)(_mnistImagesReader.ReadByte() > 0 ? 1 : 0);

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
            _totalCount = BitConverter.ToInt32(buff.Reverse().ToArray(), 0);

            _mnistLabelsReader.Read(buff, 0, 4);
            if (_totalCount != BitConverter.ToInt32(buff.Reverse().ToArray(), 0))
                throw new InvalidDataException("Files containment are different");

            _mnistImagesReader.Read(buff, 0, 4);
            _rows = BitConverter.ToInt32(buff.Reverse().ToArray(), 0);

            _mnistImagesReader.Read(buff, 0, 4);
            _columns = BitConverter.ToInt32(buff.Reverse().ToArray(), 0);
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

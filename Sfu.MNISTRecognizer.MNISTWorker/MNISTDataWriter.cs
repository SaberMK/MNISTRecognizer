using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfu.MNISTRecognizer.MNISTWorker
{
    public class MNISTDataWriter : IDisposable
    {
        private readonly FileStream _mnistImagesWriter;
        private readonly FileStream _mnistLabelsWriter;
        private readonly byte _rowSize;
        private readonly byte _columnSize;
        private readonly int _imageSize;

        private int _count;
        public MNISTDataWriter(string imagesFilepath, string labelsFilepath, byte rowSize = 28, byte columnSize = 28)
        {
            if (!File.Exists(imagesFilepath))
            {
                _mnistImagesWriter = new FileStream(imagesFilepath, FileMode.Create, FileAccess.ReadWrite);

                var encoded = BitConverter.GetBytes((uint)MNIST_MAGIC_IMAGES_NUMBER).Reverse().ToArray();

                _mnistImagesWriter.Write(encoded, 0, 4); // test more (mb try .Reverse() or uint conversion)
                _mnistImagesWriter.Write(BitConverter.GetBytes(0), 0, 4);
                _mnistImagesWriter.WriteByte(rowSize);
                _mnistImagesWriter.WriteByte(columnSize);

                _count = 0;
            } 
            else
            {
                _mnistImagesWriter = new FileStream(imagesFilepath, FileMode.Open, FileAccess.ReadWrite);

                var buffer = new byte[4];
                _mnistImagesWriter.Seek(8, SeekOrigin.Begin);
                _mnistImagesWriter.Read(buffer, 0, 3);

                _count = BitConverter.ToInt32(buffer, 0);
            }

            if (!File.Exists(labelsFilepath))
            {
                _mnistLabelsWriter = new FileStream(labelsFilepath, FileMode.Create, FileAccess.ReadWrite);
                
                var encoded = BitConverter.GetBytes((uint)MNIST_MAGIC_LABELS_NUMBER).Reverse().ToArray();

                _mnistLabelsWriter.Write(encoded, 0, 4);
                _mnistImagesWriter.Write(BitConverter.GetBytes(0), 0, 4);
            }
            else
            {
                _mnistLabelsWriter = new FileStream(labelsFilepath, FileMode.Open, FileAccess.ReadWrite);
            }

            _rowSize = rowSize;
            _columnSize = columnSize;
            _imageSize = rowSize * columnSize;
        }

        public int SaveImage(byte[,] image, int label, int pos = -1)
        {
            var transpiled = new byte[image.GetLength(0) * image.GetLength(1)];
            
            // SLAVE CHECK THIS
            for (int i = 0; i < image.GetLength(0); ++i)
                for (int j = 0; j < image.GetLength(1); ++j)
                    transpiled[i + j * image.GetLength(0)] = image[i, j];

            return SaveImage(transpiled, label);
        }

        private int SaveImage(byte[] image, int label, int pos = -1)
        {
            long imagesOffset = MNIST_IMAGE_DATA_OFFSET;
            long labelsOffset = MNIST_LABELS_DATA_OFFSET;

            if (pos != -1)
            {
                imagesOffset += pos * _imageSize;
                labelsOffset += pos * _imageSize;
            }
            else
            {
                imagesOffset = _mnistImagesWriter.Length;
                labelsOffset = _mnistLabelsWriter.Length;
            }

            _mnistImagesWriter.Position = imagesOffset;
            _mnistImagesWriter.Write(image, 0, image.Length);

            _mnistLabelsWriter.Position = labelsOffset;

            _count++;

            var encoded = BitConverter.GetBytes((uint)_count).Reverse().ToArray();

            _mnistImagesWriter.Position = 4;
            _mnistImagesWriter.Write(encoded, 0, 4);

            _mnistLabelsWriter.Position = 4;
            _mnistLabelsWriter.Write(encoded, 0, 4);

            return _count;
        }

        private const int MNIST_MAGIC_IMAGES_NUMBER = 2051;
        private const int MNIST_MAGIC_LABELS_NUMBER = 2049;

        private const int MNIST_IMAGE_DATA_OFFSET = 16;
        private const int MNIST_LABELS_DATA_OFFSET = 8;

        public void Dispose()
        {
            _mnistImagesWriter.Close();
            _mnistLabelsWriter.Close();
        }
    }
}

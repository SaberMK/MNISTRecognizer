using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sfu.MNISTRecognizer.MNISTWorker;

namespace Sfu.MNISTRecognizer.UnitTests
{
    [TestClass]
    public class MNISTDataReaderTests
    {
        [TestMethod]
        public void LoadTests()
        {
            var mnistReader = new MNISTDataReader();
            mnistReader.Load("t10k-images.idx3-ubyte", "t10k-labels.idx1-ubyte");
        }

        //[TestMethod]
        //public void ReadImageTest()
        //{
        //    var mnistReader = new MNISTDataReader();
        //    mnistReader.Load("t10k-images.idx3-ubyte", "t10k-labels.idx1-ubyte");
        //    var (image, label) = mnistReader.GetImage(1);
        //    File.WriteAllText("label.txt", label.ToString());

        //    var arr = new List<string>();
        //    for(int i = 0; i < 28; ++i)
        //    {
        //        var a = "";
        //        for(int j = 0; j < 28;  ++j)
        //        {
        //            a += image[i, j];
        //        }
        //        arr.Add(a);
        //    }
        //    File.WriteAllLines("image.txt", arr);
        //}
    }
}

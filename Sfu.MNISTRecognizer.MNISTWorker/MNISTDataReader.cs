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
        private FileStream _mnistStream;
        
        public void Load(string filepath)
        {
            if (!File.Exists(filepath))
                throw new FileNotFoundException($"File {filepath} not found!");

            _mnistStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
        }

        

    }
}

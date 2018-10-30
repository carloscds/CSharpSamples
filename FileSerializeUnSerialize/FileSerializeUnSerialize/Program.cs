using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSerializeUnSerialize
{
    class Program
    {
        static void Main(string[] args)
        {
            // read from file
            var fsRead = new FileStream("LogoCDS.png", FileMode.Open);
            int tamanho = (int)fsRead.Length;
            byte[] buffer = new byte[tamanho];
            fsRead.Read(buffer, 0, tamanho);

            // create a temp file name and change extension
            var tempFile = Path.GetFileName(Path.GetTempFileName());
            tempFile = Path.ChangeExtension(tempFile, "png");

            // write serialized file
            var fsWrite = new FileStream(tempFile, FileMode.Create);
            fsWrite.Write(buffer, 0, tamanho);
            fsWrite.Close();
        }
    }
}

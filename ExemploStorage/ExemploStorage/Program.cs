using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExemploStorage
{
    class Program
    {

        static void Main(string[] args)
        {
            var accountName = "<STORAGENAME>";
            var accountKey = "<STORAGE_KEY>";
            var storageCredentials = new StorageCredentials(accountName, accountKey);

            CloudBlobClient client = new CloudBlobClient(new Uri($"https://{accountName}.blob.core.windows.net/"), storageCredentials);

            var storage = new AzureStorageHelper(accountName, accountKey, "arquivos");
            storage.CheckContainerExists();

            var arquivoStorage = Path.GetFileName("FotoExemplo.jpg");
            storage.SendFile("FotoExemplo.jpg");

            storage.DownloadFile("FotoExemplo.jpg",@"c:\temp\test.jpg");

            var lista = storage.ListFiles(); ;
            foreach (var a in lista)
            {
                Console.WriteLine($"URL: {a}" );
            }

            storage.DeleteFile("FotoExemplo.jpg");


        }
    }
}

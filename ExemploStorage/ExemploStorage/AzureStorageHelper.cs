using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploStorage
{
    public class AzureStorageHelper
    {
        CloudBlobClient blobClient;
        CloudBlobContainer container;

        public AzureStorageHelper(string accountName, string accountKey, string containerName)
        {
            var storageCredentials = new StorageCredentials(accountName, accountKey);
            blobClient = new CloudBlobClient(new Uri($"https://{accountName}.blob.core.windows.net/"), storageCredentials);
            container = blobClient.GetContainerReference(containerName);
        }

        public void CheckContainerExists()
        {
            container.CreateIfNotExists();
        }

        public void SendFile(string fileName)
        {
            var arquivoStorage = Path.GetFileName(fileName);
            var arquivo = container.GetBlockBlobReference(arquivoStorage);
            arquivo.UploadFromFile(fileName);
        }

        public void DownloadFile(string fileName, string destinationFileName)
        {
            var arquivo = container.GetBlockBlobReference(fileName);
            if(File.Exists(destinationFileName))
            {
                File.Delete(destinationFileName);
            }
            arquivo.DownloadToFile(destinationFileName, FileMode.Create);
        }

        public void DeleteFile(string fileName)
        {
            var arquivo = container.GetBlockBlobReference(fileName);
            arquivo.Delete();
        }

        public List<string> ListFiles() => container.ListBlobs().Select(s => s.StorageUri.PrimaryUri.ToString()).ToList();
    }
}

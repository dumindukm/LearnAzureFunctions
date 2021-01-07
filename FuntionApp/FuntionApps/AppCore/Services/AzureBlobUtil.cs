using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Services
{
    public static class AzureBlobUtil
    {
        private static BlobContainerClient blobContainerClient = null;
        static string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");

        static AzureBlobUtil()
        {
            // Create a BlobServiceClient object which will be used to create a container client
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            //Create a unique name for the container
            string containerName = "albumblobs";

            // Create the container and return a container client object
            blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
            var result = blobContainerClient.CreateIfNotExists();
        }

        public static async Task<bool> UploadToBlob(Stream stream, string filename)
        {
            BlobClient blobClient = blobContainerClient.GetBlobClient(filename);
            stream.Position = 0;
            await blobClient.UploadAsync(stream, true);
            return true;
        }

    }
}

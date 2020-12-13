using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Services
{
    /// <summary>
    /// Manages saving images to blob storage
    /// </summary>
    public class AzureBlobService : IBlobService
    {
        IConfiguration config;
        string containerName;

        public AzureBlobService(IConfiguration configuration)
        {
            config = configuration;
            containerName = config[Constants.KEY_BLOB];
        }

        public async Task<string> UploadBlobAsync(string blobName, Stream imageStream)
        {
            var containerClient = new BlobContainerClient(
                config[Constants.KEY_STORAGE_CNN],
                containerName);
            var blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.UploadAsync(imageStream, new BlobHttpHeaders
            {
                ContentType = "image/jpeg",
                CacheControl = "public"
            });
            return blobClient.Uri.ToString();
        }
    }
}

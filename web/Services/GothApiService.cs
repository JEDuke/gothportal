using System.IO;
using System.Net.Http;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

namespace gothportal.Services
{
    public class GothApiService : IGothApiService
    {
        private readonly IConfiguration configuration;

        public GothApiService(IConfiguration _configuration){
            configuration = _configuration;
        }
        public byte[] GetImage(string name)
        {
            string connString = configuration.GetConnectionString("blobStorageConnectionString");
            string blobContainerName = configuration["blobStorageContainerName"];
            Azure.Storage.Blobs.BlobClient blobClient = new BlobClient(
                connectionString: connString,
                blobContainerName: blobContainerName,
                blobName: name
            );

            using (MemoryStream ms = new MemoryStream())
            {
                blobClient.DownloadTo(ms);
                return ms.ToArray();
            }
        }
    }
}

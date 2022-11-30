using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

namespace gothapi
{
    public static class imageUploader
    {
        [FunctionName("imageUploader")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var blobConfig = new blobStorageConfig();
            config.Bind(nameof(blobStorageConfig),blobConfig);
            
            log.LogInformation("C# imageUploader function processed a request.");

            string name = req.Query["name"];
            var blobName = name ?? blobConfig.defaultBlobName;

            Azure.Storage.Blobs.BlobClient blobClient = new BlobClient(
                blobConfig.connectionString, 
                blobConfig.container,
                blobName
            );

            using (MemoryStream ms = new MemoryStream())
            {
                blobClient.DownloadTo(ms);
                return new OkObjectResult(ms.ToArray());
            }
        }
    }
}

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

namespace gothapi
{
    public static class imageUploader
    {
        [FunctionName("imageUploader")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "Message from imageUploader: This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Message from imageUploader: Hello, sup {name}.";

            //return new OkObjectResult(responseMessage);

            string connString = "DefaultEndpointsProtocol=https;AccountName=gothstorage;AccountKey=2PVMTSyp1N3W98eGAGnp5D/5dRXlfrq8raJsPCSIoulHD+gA5nGAgrgvekriW2tcKAMnend4kS0n+AStaOmIpQ==;EndpointSuffix=core.windows.net";
            Azure.Storage.Blobs.BlobClient blobClient = new BlobClient(
                connString, 
                "gothportal",
                name
            );

            using (MemoryStream ms = new MemoryStream())
            {
                blobClient.DownloadTo(ms);
                return new OkObjectResult(ms.ToArray());
            }
        }
    }
}

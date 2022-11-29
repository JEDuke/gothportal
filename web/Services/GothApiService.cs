using System.IO;
using System.Net.Http;
using Azure.Storage.Blobs;

namespace gothportal.Services
{
    public class GothApiService : IGothApiService
    {
        public byte[] GetImage(string key)
        {
            var message = Run(key);
            return message;
        }

        HttpClient client = new HttpClient();

        private byte[] Run(string keyId)
        {
            string connString = "DefaultEndpointsProtocol=https;AccountName=gothstorage;AccountKey=2PVMTSyp1N3W98eGAGnp5D/5dRXlfrq8raJsPCSIoulHD+gA5nGAgrgvekriW2tcKAMnend4kS0n+AStaOmIpQ==;EndpointSuffix=core.windows.net";
            Azure.Storage.Blobs.BlobClient blobClient = new BlobClient(
                connString,
                "gothportal",
                keyId
            );

            using (MemoryStream ms = new MemoryStream())
            {
                blobClient.DownloadTo(ms);
                return ms.ToArray();
            }

            // //http://localhost:7071/api/imageUploader?name=hardtimesbefallensoulsurvivors
            // // Update port # in the following line.
            // client.BaseAddress = new Uri("http://localhost:7071/");
            // client.DefaultRequestHeaders.Accept.Clear();
            // client.DefaultRequestHeaders.Accept.Add(
            //     new MediaTypeWithQualityHeaderValue("application/json"));

            // try
            // {
            //     HttpResponseMessage response = await client.GetAsync("api/imageUploader?name=" + keyId);
            //     return await response.Content.ReadAsAsync<string>();
            // }
            // catch (Exception e)
            // {
            //     return e.Message;
            // }
        }
    }
}

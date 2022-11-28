using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using gothPortal.Models;

namespace gothportal.Services
{
    public class GothApiService : IGothApiService
    {
        public string GetMessage(string key)
        {
            var message = RunAsync(key);
            return message.Result;
        }

        HttpClient client = new HttpClient();
        
        private async Task<string> RunAsync(string keyId)
        {
            //http://localhost:7071/api/imageUploader?name=hardtimesbefallensoulsurvivors
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:7071/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.GetAsync("api/imageUploader?name=" + keyId);
                return await response.Content.ReadAsAsync<string>();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}

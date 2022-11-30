using System.IO;
using System.Net.Http;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.WebUtilities;
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
            HttpClient _client = new HttpClient();
            var gothApiUrl = configuration["gothApiUrl"];
            var requestUri = QueryHelpers.AddQueryString(
                uri: gothApiUrl,
                name: "name",
                value: name
            );
            HttpRequestMessage newRequest = new HttpRequestMessage(HttpMethod.Get, requestUri);
            HttpResponseMessage response = _client.SendAsync(newRequest).Result;
            return response.Content.ReadAsAsync<byte[]>().Result;
        }
    }
}

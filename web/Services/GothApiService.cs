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

                // var url = await CreateProductAsync(product);
                // Console.WriteLine($"Created at {url}");

                // // Get the product
                // product = await GetProductAsync(id);
                // ShowProduct(product);

                // // Update the product
                // Console.WriteLine("Updating price...");
                // product.Price = 80;
                // await UpdateProductAsync(product);

                // // Get the updated product
                // product = await GetProductAsync(url.PathAndQuery);
                // ShowProduct(product);

                // // Delete the product
                // var statusCode = await DeleteProductAsync(product.Id);
                // Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        // static async Task<dailyModel> GetProductAsync(string path)
        // {
        //     dailyModel dailyModel = null;
        //     HttpResponseMessage response = await client.GetAsync(path);
        //     if (response.IsSuccessStatusCode)
        //     {
        //         dailyModel = await response.Content.ReadAsAsync<dailyModel>();
        //     }
        //     return dailyModel;
        // }

        // static void ShowProduct(dailyModel product)
        // {
        //     Console.WriteLine($"Name: {product.Name}\tPrice: " +
        //         $"{product.Price}\tCategory: {product.Category}");
        // }

        // static async Task<Uri> CreateProductAsync(Product product)
        // {
        //     HttpResponseMessage response = await client.PostAsJsonAsync(
        //         "api/products", product);
        //     response.EnsureSuccessStatusCode();

        //     // return URI of the created resource.
        //     return response.Headers.Location;
        // }

        // static async Task<Product> UpdateProductAsync(Product product)
        // {
        //     HttpResponseMessage response = await client.PutAsJsonAsync(
        //         $"api/products/{product.Id}", product);
        //     response.EnsureSuccessStatusCode();

        //     // Deserialize the updated product from the response body.
        //     product = await response.Content.ReadAsAsync<Product>();
        //     return product;
        // }

        // static async Task<HttpStatusCode> DeleteProductAsync(string id)
        // {
        //     HttpResponseMessage response = await client.DeleteAsync(
        //         $"api/products/{id}");
        //     return response.StatusCode;
        // }
    }
}

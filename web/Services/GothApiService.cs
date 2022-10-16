namespace gothportal.Services
{
    public class GothApiService : IGothApiService
    {
        public string GetMessage(string key)
        {
            return "Success! Key ID: " + key + ". ";
        }
    }
}
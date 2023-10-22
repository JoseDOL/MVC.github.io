using CrudPro.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CrudPro.Servicios
{
    public class GiphyService
    {
        private readonly string apiKey;
        private readonly HttpClient httpClient;

        public GiphyService(string apiKey)
        {
            this.apiKey = apiKey;
            httpClient = new HttpClient();
        }

        public async Task<GiphyData> GetGiphyDataAsync(string query)
        {
            string url = $"https://api.giphy.com/v1/gifs/search?q={query}&api_key={apiKey}";
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var giphyData = JsonConvert.DeserializeObject<GiphyData>(json);
                return giphyData;
            }

            return null;
        }
    }
}

using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Net.Http.Json;
using FreeTimeSpenderWeb.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FreeTimeSpenderWeb.Sevices
{
    public class NewsService
    {
        private readonly IHttpClientFactory _clientFactory;

        public NewsService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> GetNewsAsync(string apiKey)
        {
            var client = _clientFactory.CreateClient();
            var country = "hu";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            client.DefaultRequestHeaders.Add("User-Agent", "Free-Time-Spender");

            var response = await client.GetAsync($"https://newsapi.org/v2/top-headlines?country={country}&apiKey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                return null;
            }
        }
    }
}

using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Net.Http.Json;
using FreeTimeSpenderWeb.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using FreeTimeSpenderWeb.Services.Interfaces;

namespace FreeTimeSpenderWeb.Services
{
    public class NewsService : INewsService
    {
        private readonly HttpClient _httpClient;

        public NewsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetNewsAsync(string apiKey)
        {
            var country = "hu";
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://newsapi.org/v2/top-headlines?country={country}&apiKey={apiKey}");

            request.Headers.Add("User-Agent", "Free-Time-Spender");

            var response = await _httpClient.SendAsync(request);

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

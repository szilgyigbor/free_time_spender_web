using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace FreeTimeSpenderWeb.Sevices
{
    public class BotService
    {
        private readonly HttpClient _httpClient;

        public BotService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<string> SendPostRequestAsync(string apiKey, string newMessage)
        {
            var uri = new Uri("https://api.openai.com/v1/completions");

            var request = new HttpRequestMessage(HttpMethod.Post, uri);

            request.Headers.Add("Authorization", "Bearer " + apiKey);
            request.Content = new StringContent(JsonConvert.SerializeObject(new
            {
                model = "text-davinci-003",
                prompt = newMessage,
                temperature = 0.5,
                max_tokens = 256,
                top_p = 1,
                n = 1
            }), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var answer = await response.Content.ReadAsStringAsync();

            return answer;
        }

    }
}

namespace FreeTimeSpenderWeb.Sevices
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetWeatherAsync(string apiKey, string location)
        {
            /*var request = new HttpRequestMessage(HttpMethod.Get, $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={location}&aqi=no");
            
            request.Headers.Add("Authorization", "Bearer " + apiKey);
            request.Headers.Add("User-Agent", "Free-Time-Spender");

            var response = await _httpClient.SendAsync(request);*/

            var response = await _httpClient.GetAsync($"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={location}&aqi=no");

            return await response.Content.ReadAsStringAsync();
            
        }
    }
}

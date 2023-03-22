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
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={location}&aqi=no");

            request.Headers.Add("Authorization", "Bearer " + apiKey);
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

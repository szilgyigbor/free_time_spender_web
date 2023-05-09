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

            var response = await _httpClient.GetAsync($"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={location}&aqi=no");

            return await response.Content.ReadAsStringAsync();
            
        }
    }
}

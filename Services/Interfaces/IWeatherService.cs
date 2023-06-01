namespace FreeTimeSpenderWeb.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<string> GetWeatherAsync(string apiKey, string location);
    }
}

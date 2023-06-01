namespace FreeTimeSpenderWeb.Services.Interfaces
{
    public interface IBotService
    {
        Task<string> SendPostRequestAsync(string apiKey, string newMessage);
    }
}

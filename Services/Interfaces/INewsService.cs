using FreeTimeSpenderWeb.Models;

namespace FreeTimeSpenderWeb.Services.Interfaces
{
    public interface INewsService
    {
        Task<string> GetNewsAsync(string apiKey);

        Task<ArticleData> GetOneNewsAsync(string apiKey);
    }
}

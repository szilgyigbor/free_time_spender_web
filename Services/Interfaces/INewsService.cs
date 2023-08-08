using FreeTimeSpenderWeb.Models;

namespace FreeTimeSpenderWeb.Services.Interfaces
{
    public interface INewsService
    {
        Task<string> GetNewsAsync(string apiKey);

        Task<ArticleModel> GetOneNewsAsync(string apiKey);
    }
}

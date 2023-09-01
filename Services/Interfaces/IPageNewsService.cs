using FreeTimeSpenderWeb.Models;

namespace FreeTimeSpenderWeb.Services.Interfaces
{
    public interface IPageNewsService
    {
        Task<IEnumerable<PageNewsData>> GetPageNews();

        Task AddPageNews(PageNewsData pageNews);
    }
}

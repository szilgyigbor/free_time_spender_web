using FreeTimeSpenderWeb.Models;

namespace FreeTimeSpenderWeb.Services.Interfaces
{
    public interface ISortingGameService
    {
        Task<IEnumerable<SortingGameData>> GetTop10Results();

        Task AddResult(SortingGameData sortingGameData);
    }
}

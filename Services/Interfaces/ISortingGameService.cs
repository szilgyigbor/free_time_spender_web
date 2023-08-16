using FreeTimeSpenderWeb.Models;

namespace FreeTimeSpenderWeb.Services.Interfaces
{
    public interface ISortingGameService
    {
        Task<IEnumerable<SortingGameData>> GetSortingGameDatas();

        Task AddResult(SortingGameData sortingGameData);
    }
}

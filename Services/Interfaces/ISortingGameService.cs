using FreeTimeSpenderWeb.Models;

namespace FreeTimeSpenderWeb.Services.Interfaces
{
    public interface ISortingGameService
    {
        Task<IEnumerable<SortingGameData>> GetResults();

        Task AddResult(SortingGameData sortingGameData);
    }
}

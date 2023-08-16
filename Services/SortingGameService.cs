using FreeTimeSpenderWeb.Data;
using FreeTimeSpenderWeb.Models;
using FreeTimeSpenderWeb.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FreeTimeSpenderWeb.Services
{
    public class SortingGameService : ISortingGameService
    {
        private readonly FreeTimeSpenderContext _context;

        public SortingGameService(FreeTimeSpenderContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SortingGameData>> GetResults()
        {
            return await _context.SortingGameDatas.ToListAsync();
        }

        public async Task AddResult(SortingGameData sortingGameData)
        {
            await _context.SortingGameDatas.AddAsync(sortingGameData);
            await _context.SaveChangesAsync();
        }
    }
}

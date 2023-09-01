using FreeTimeSpenderWeb.Data;
using FreeTimeSpenderWeb.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using FreeTimeSpenderWeb.Models;

namespace FreeTimeSpenderWeb.Services
{
    public class PageNewsService : IPageNewsService
    {
        private readonly FreeTimeSpenderContext _context;

        public PageNewsService(FreeTimeSpenderContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PageNewsData>> GetPageNews()
        {
            return await _context.PageNewsDatas.ToListAsync();
        }

        public async Task AddPageNews(PageNewsData pageNews)
        {
            await _context.PageNewsDatas.AddAsync(pageNews);
            await _context.SaveChangesAsync();
        }
    }
}

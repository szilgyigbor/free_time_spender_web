using FreeTimeSpenderWeb.Data;
using FreeTimeSpenderWeb.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using FreeTimeSpenderWeb.Models;

namespace FreeTimeSpenderWeb.Services
{
    public class OpinionService : IOpinionService
    {
        private readonly FreeTimeSpenderContext _context;

        public OpinionService(FreeTimeSpenderContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OpinionData>> GetOpinions()
        {
            return await _context.OpinionDatas.ToListAsync();
        }

        public async Task AddOpinion(OpinionData opinion)
        {
            await _context.OpinionDatas.AddAsync(opinion);
            await _context.SaveChangesAsync();
        }

    }
}

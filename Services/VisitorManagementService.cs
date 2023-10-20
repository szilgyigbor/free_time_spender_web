using FreeTimeSpenderWeb.Data;
using FreeTimeSpenderWeb.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using FreeTimeSpenderWeb.Models;

namespace FreeTimeSpenderWeb.Services
{
    public class VisitorManagementService : IVisitorManagementService
    {
        private readonly FreeTimeSpenderContext _context;

        public VisitorManagementService(FreeTimeSpenderContext context)
        {
            _context = context;
        }

        public async Task<VisitData> GetVisits()
        {
            return await _context.VisitDatas.FirstOrDefaultAsync();
        }

        public async Task<VisitData> RaiseVisitNumber()
        {
            VisitData visitData = await _context.VisitDatas.FirstOrDefaultAsync();

            if (visitData == null)
            {
                visitData = new VisitData { AllVisits = 0, LastVisit = DateTime.UtcNow };
                _context.VisitDatas.Add(visitData);
            }

            visitData.AllVisits++;
            visitData.LastVisit = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return visitData;
        }

    }
}

using FreeTimeSpenderWeb.Models;


namespace FreeTimeSpenderWeb.Services.Interfaces
{
    public interface IVisitorManagementService
    {
        Task<VisitData> GetVisits();

        Task<VisitData> RaiseVisitNumber();
    }
}

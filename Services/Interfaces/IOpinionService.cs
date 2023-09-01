using FreeTimeSpenderWeb.Models;

namespace FreeTimeSpenderWeb.Services.Interfaces
{
    public interface IOpinionService
    {
        Task<IEnumerable<OpinionData>> GetOpinions();

        Task AddOpinion(OpinionData opinion);
    }
}

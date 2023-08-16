using FreeTimeSpenderWeb.Models;

namespace FreeTimeSpenderWeb.Services.Interfaces
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageData>> GetMessages();

        Task AddMessage(MessageData message);
    }
}

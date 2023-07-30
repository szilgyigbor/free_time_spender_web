using FreeTimeSpenderWeb.Models;

namespace FreeTimeSpenderWeb.Services.Interfaces
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageDataModel>> GetMessages();

        Task AddMessage(MessageDataModel message);
    }
}

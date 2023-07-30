using FreeTimeSpenderWeb.Data;
using FreeTimeSpenderWeb.Services.Interfaces;

namespace FreeTimeSpenderWeb.Services
{
    public class MessageService : IMessageService
    {
        private readonly FreeTimeSpenderContext _context;

        public MessageService(FreeTimeSpenderContext context)
        {
            _context = context;
        }


    }
}

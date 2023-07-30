using FreeTimeSpenderWeb.Data;
using FreeTimeSpenderWeb.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using FreeTimeSpenderWeb.Models;

namespace FreeTimeSpenderWeb.Services
{
    public class MessageService : IMessageService
    {
        private readonly FreeTimeSpenderContext _context;

        public MessageService(FreeTimeSpenderContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MessageDataModel>> GetMessages()
        {
            return await _context.MessageDatas.ToListAsync();
        }

        public async Task AddMessage(MessageDataModel message)
        {
            await _context.MessageDatas.AddAsync(message);
            await _context.SaveChangesAsync();
        }

    }
}

using Microsoft.EntityFrameworkCore;
using FreeTimeSpenderWeb.Models;

namespace FreeTimeSpenderWeb.Data
{
    public class FreeTimeSpenderContext : DbContext
    {
        public DbSet<UserDataModel> SignUpDatas { get; set; }
        public DbSet<MessageDataModel> MessageDatas { get; set; }

        public FreeTimeSpenderContext(DbContextOptions<FreeTimeSpenderContext> options) : base(options)
        {
        }
    }
}

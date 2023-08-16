using Microsoft.EntityFrameworkCore;
using FreeTimeSpenderWeb.Models;

namespace FreeTimeSpenderWeb.Data
{
    public class FreeTimeSpenderContext : DbContext
    {
        public DbSet<UserData> SignUpDatas { get; set; }
        public DbSet<MessageData> MessageDatas { get; set; }
        public DbSet<SortingGameData> SortingGameDatas { get; set; }

        public FreeTimeSpenderContext(DbContextOptions<FreeTimeSpenderContext> options) : base(options)
        {
        }
    }
}

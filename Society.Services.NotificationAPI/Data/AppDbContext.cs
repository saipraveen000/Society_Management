using Microsoft.EntityFrameworkCore;
using Society.Services.NotificationAPI.Models;

namespace Society.Services.NotificationAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EmergencyAlert> EmergencyAlerts { get; set; }


    }
}

using Microsoft.EntityFrameworkCore;
using Society.Services.MaintenanceAPI.Models;

namespace Society.Services.MaintenanceAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }
    }
}

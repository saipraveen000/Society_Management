using Microsoft.EntityFrameworkCore;
using Society.Services.MaintenanceAPI.Data;
using Society.Services.MaintenanceAPI.Models;

namespace Society.Services.MaintenanceAPI.Repository
{
    public class MaintenanceRepository : IMaintenanceRepository
    {
        private readonly AppDbContext _context;

        public MaintenanceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateRequestAsync(MaintenanceRequest request)
        {
            _context.MaintenanceRequests.Add(request);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MaintenanceRequest>> GetAllRequestsAsync()
        {
            return await _context.MaintenanceRequests.ToListAsync();
        }

        public async Task<MaintenanceRequest?> GetRequestByIdAsync(Guid id)
        {
            return await _context.MaintenanceRequests.FindAsync(id);
        }

        public async Task UpdateStatusAsync(Guid id, string status, string? assignedTo = null)
        {
            var req = await _context.MaintenanceRequests.FindAsync(id);
            if (req == null) return;

            req.Status = status;
            req.AssignedTo = assignedTo;
            await _context.SaveChangesAsync();
        }
    }
}

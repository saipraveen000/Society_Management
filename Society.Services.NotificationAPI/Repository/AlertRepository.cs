using Microsoft.EntityFrameworkCore;
using Society.Services.NotificationAPI.Data;
using Society.Services.NotificationAPI.Models;

namespace Society.Services.NotificationAPI.Repository
{
    public class AlertRepository : IAlertRepository
    {
        private readonly AppDbContext _context;

        public AlertRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmergencyAlert>> GetLatestAlertsAsync()
        {
            return await _context.EmergencyAlerts
                                 .OrderByDescending(a => a.Timestamp)
                                 .ToListAsync();
        }

        public async Task CreateAlertAsync(EmergencyAlert alert)
        {
            await _context.EmergencyAlerts.AddAsync(alert);
            await _context.SaveChangesAsync();
        }
        public async Task<EmergencyAlert?> GetAlertByIdAsync(Guid id)
        {
            return await _context.EmergencyAlerts.FindAsync(id);
        }

        public async Task DeleteAlertAsync(EmergencyAlert alert)
        {
            _context.EmergencyAlerts.Remove(alert);
            await _context.SaveChangesAsync();
        }
    }
}

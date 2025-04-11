using Society.Services.NotificationAPI.Models.Dto;
using Society.Services.NotificationAPI.Models;
using Society.Services.NotificationAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace Society.Services.NotificationAPI.Services
{
    public class AlertService : IAlertService
    {
        private readonly IAlertRepository _repo;
        public AlertService(IAlertRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<EmergencyAlert>> GetLatestAlertsAsync()
        {
            return await _repo.GetLatestAlertsAsync();
        }

        public async Task CreateAlertAsync(EmergencyAlertDto alertDto)
        {
            var alert = new EmergencyAlert
            {
                AlertId = Guid.NewGuid(),
                Message = alertDto.Message,
                CreatedBy = alertDto.CreatedBy,
                Timestamp = DateTime.UtcNow
            };

            await _repo.CreateAlertAsync(alert);
            // Optional: trigger notification system here
        }

        public async Task DeleteAlertAsync(Guid id)
        {
            var alert = await _repo.GetAlertByIdAsync(id);
            if (alert == null)
            {
                throw new Exception("Alert not found");
            }

            await _repo.DeleteAlertAsync(alert);
        }

    }
}

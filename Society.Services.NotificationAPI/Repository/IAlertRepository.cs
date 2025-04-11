using Society.Services.NotificationAPI.Models;

namespace Society.Services.NotificationAPI.Repository
{
    public interface IAlertRepository
    {
        Task<IEnumerable<EmergencyAlert>> GetLatestAlertsAsync();
        Task CreateAlertAsync(EmergencyAlert alert);
        Task<EmergencyAlert?> GetAlertByIdAsync(Guid id);
        Task DeleteAlertAsync(EmergencyAlert alert);
    }
}

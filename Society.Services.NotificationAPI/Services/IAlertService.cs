using Society.Services.NotificationAPI.Models.Dto;
using Society.Services.NotificationAPI.Models;

namespace Society.Services.NotificationAPI.Services
{
    public interface IAlertService
    {
        Task<IEnumerable<EmergencyAlert>> GetLatestAlertsAsync();
        Task CreateAlertAsync(EmergencyAlertDto alertDto);
        Task DeleteAlertAsync(Guid id);

    }
}

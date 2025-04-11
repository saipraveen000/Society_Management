using Society.Services.MaintenanceAPI.Models;

namespace Society.Services.MaintenanceAPI.Services
{
    public interface IMaintenanceService
    {
        Task CreateRequestAsync(MaintenanceRequest request);
        Task<IEnumerable<MaintenanceRequest>> GetAllRequestsAsync();
        Task UpdateStatusAsync(Guid requestId, string status, string? assignedTo);
    }
}

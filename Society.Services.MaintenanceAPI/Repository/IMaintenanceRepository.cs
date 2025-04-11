using Society.Services.MaintenanceAPI.Models;

namespace Society.Services.MaintenanceAPI.Repository
{
    public interface IMaintenanceRepository
    {
        Task CreateRequestAsync(MaintenanceRequest request);
        Task<IEnumerable<MaintenanceRequest>> GetAllRequestsAsync();
        Task<MaintenanceRequest?> GetRequestByIdAsync(Guid id);
        Task UpdateStatusAsync(Guid id, string status, string? assignedTo = null);
    }
}

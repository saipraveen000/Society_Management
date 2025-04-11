using Society.Services.MaintenanceAPI.Models;
using Society.Services.MaintenanceAPI.Repository;

namespace Society.Services.MaintenanceAPI.Services
{
    public class MaintenanceService : IMaintenanceService
    {
        private readonly IMaintenanceRepository _repository;

        public MaintenanceService(IMaintenanceRepository repository)
        {
            _repository = repository;
        }

        public Task CreateRequestAsync(MaintenanceRequest request) => _repository.CreateRequestAsync(request);
        public Task<IEnumerable<MaintenanceRequest>> GetAllRequestsAsync() => _repository.GetAllRequestsAsync();
        public Task UpdateStatusAsync(Guid requestId, string status, string? assignedTo) =>
            _repository.UpdateStatusAsync(requestId, status, assignedTo);
    }
}

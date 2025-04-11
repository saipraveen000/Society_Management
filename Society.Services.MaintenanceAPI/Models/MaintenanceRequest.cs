using System.ComponentModel.DataAnnotations;

namespace Society.Services.MaintenanceAPI.Models
{
    public class MaintenanceRequest
    {
        [Key]
        public Guid RequestId { get; set; }

        public string Issue { get; set; }

        public string CreatedBy { get; set; }

        public string? AssignedTo { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? AttachmentUrl { get; set; }
    }
}

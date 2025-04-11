using System.ComponentModel.DataAnnotations;

namespace Society.Services.NotificationAPI.Models
{
    public class EmergencyAlert
    {
        [Key]
        public Guid AlertId { get; set; }
        public string Message { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

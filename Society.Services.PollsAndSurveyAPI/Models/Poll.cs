using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Society.Services.PollsAndSurveyAPI.Models
{
    public class Poll
    {
        [Key]
        public Guid PollId { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public List<string> Options { get; set; } = new List<string>();

        public string CreatedBy { get; set; }

        public bool IsAnonymous { get; set; }

        [NotMapped]
        public Dictionary<string, List<string>> Votes
        {
            get => string.IsNullOrEmpty(VotesJson)
                ? new Dictionary<string, List<string>>()
                : JsonSerializer.Deserialize<Dictionary<string, List<string>>>(VotesJson);
            set => VotesJson = JsonSerializer.Serialize(value);
        }

        public string? VotesJson { get; set; }
    }
}

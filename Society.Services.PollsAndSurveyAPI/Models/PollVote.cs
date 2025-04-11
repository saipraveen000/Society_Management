using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Society.Services.PollsAndSurveyAPI.Models
{
    public class PollVote
    {
        [Key]
        public Guid Id { get; set; }

        public string UserId { get; set; } // Leave null for anonymous

        public Guid PollId { get; set; }

        public string SelectedOption { get; set; }

        [ForeignKey("PollId")]
        public Poll Poll { get; set; }
    }
}

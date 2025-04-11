using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Society.Services.PollsAndSurveyAPI.Models
{
    public class PollOption
    {
        [Key]
        public Guid Id { get; set; }
        public string OptionText { get; set; }
        public Guid PollId { get; set; }
        [ForeignKey("PollId")]
        public Poll Poll { get; set; }
    }
}

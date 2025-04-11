using System.ComponentModel.DataAnnotations;

namespace Society.Services.PollsAndSurveyAPI.Models.Dto
{
    public class VoteDto
    {
        public Guid PollId { get; set; }

        public string Option { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Society.Services.PollsAndSurveyAPI.Models.Dto
{
    public class CreatePollDto
    {
        public string Question { get; set; }

        public List<string> Options { get; set; }

        public bool IsAnonymous { get; set; }
    }
}

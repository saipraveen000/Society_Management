namespace Society.Services.PollsAndSurveyAPI.Models.Dto
{
    public class PollDto
    {
        public string Question { get; set; }
        public List<string> Options { get; set; }
        public bool IsAnonymous { get; set; }
    }

}

using Society.Services.PollsAndSurveyAPI.Models.Dto;
using Society.Services.PollsAndSurveyAPI.Models;

namespace Society.Services.PollsAndSurveyAPI.Services
{
    public interface IPollService
    {
        Task<Poll> CreatePollAsync(string creator, CreatePollDto dto);
        Task VoteAsync(string userId, VoteDto dto);
        Task<Poll> GetPollResultsAsync(Guid pollId);
        Task<IEnumerable<Poll>> GetAllPollsAsync();
    }
}

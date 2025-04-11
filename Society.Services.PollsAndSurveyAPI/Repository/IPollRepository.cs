using Society.Services.PollsAndSurveyAPI.Models;

namespace Society.Services.PollsAndSurveyAPI.Repository
{
    public interface IPollRepository
    {
        Task<Poll> CreatePollAsync(Poll poll);
        Task<Poll> GetPollByIdAsync(Guid pollId);
        Task<IEnumerable<Poll>> GetAllPollsAsync();
        Task UpdatePollAsync(Poll poll);
    }
}

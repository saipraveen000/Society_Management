using Society.Services.PollsAndSurveyAPI.Models.Dto;
using Society.Services.PollsAndSurveyAPI.Models;
using Society.Services.PollsAndSurveyAPI.Repository;

namespace Society.Services.PollsAndSurveyAPI.Services
{
    public class PollService : IPollService
    {
        private readonly IPollRepository _repository;

        public PollService(IPollRepository repository)
        {
            _repository = repository;
        }

        public async Task<Poll> CreatePollAsync(string creator, CreatePollDto dto)
        {
            var poll = new Poll
            {
                PollId = Guid.NewGuid(),
                Question = dto.Question,
                Options = dto.Options,
                IsAnonymous = dto.IsAnonymous,
                CreatedBy = creator,
                Votes = new Dictionary<string, List<string>>() // 👈 This ensures VotesJson is not null
            };

            return await _repository.CreatePollAsync(poll);
        }

        public async Task VoteAsync(string userId, VoteDto dto)
        {
            var poll = await _repository.GetPollByIdAsync(dto.PollId);
            if (!poll.Options.Contains(dto.Option)) throw new Exception("Invalid option");

            if (!poll.IsAnonymous)
            {
                foreach (var entry in poll.Votes)
                    entry.Value.Remove(userId); // remove previous votes
            }

            if (!poll.Votes.ContainsKey(dto.Option))
                poll.Votes[dto.Option] = new List<string>();

            poll.Votes[dto.Option].Add(poll.IsAnonymous ? Guid.NewGuid().ToString() : userId);

            await _repository.UpdatePollAsync(poll);
        }

        public async Task<Poll> GetPollResultsAsync(Guid pollId)
        {
            return await _repository.GetPollByIdAsync(pollId);
        }

        public async Task<IEnumerable<Poll>> GetAllPollsAsync() => await _repository.GetAllPollsAsync();
    }
}

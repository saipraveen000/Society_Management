using Microsoft.EntityFrameworkCore;
using Society.Services.PollsAndSurveyAPI.Data;
using Society.Services.PollsAndSurveyAPI.Models;

namespace Society.Services.PollsAndSurveyAPI.Repository
{
    public class PollRepository : IPollRepository
    {
        private readonly AppDbContext _context;

        public PollRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Poll> CreatePollAsync(Poll poll)
        {
            _context.Polls.Add(poll);
            await _context.SaveChangesAsync();
            return poll;
        }

        public async Task<IEnumerable<Poll>> GetAllPollsAsync() => await _context.Polls.ToListAsync();

        public async Task<Poll> GetPollByIdAsync(Guid pollId) => await _context.Polls.FindAsync(pollId);

        public async Task UpdatePollAsync(Poll poll)
        {
            _context.Polls.Update(poll);
            await _context.SaveChangesAsync();
        }
    }
}

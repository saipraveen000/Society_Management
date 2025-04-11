using Microsoft.EntityFrameworkCore;
using Society.Services.PollsAndSurveyAPI.Models;

namespace Society.Services.PollsAndSurveyAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollOption> PollOptions { get; set; }
        public DbSet<PollVote> PollVotes { get; set; }
    }
}

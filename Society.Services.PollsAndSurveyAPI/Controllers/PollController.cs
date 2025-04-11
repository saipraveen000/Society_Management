using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Society.Services.PollsAndSurveyAPI.Models.Dto;
using Society.Services.PollsAndSurveyAPI.Services;

namespace Society.Services.PollsAndSurveyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollController : ControllerBase
    {
        private readonly IPollService _service;

        public PollController(IPollService service)
        {
            _service = service;
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreatePoll([FromBody] CreatePollDto dto)
        {
            var user = User.Identity?.Name ?? "Admin";
            var result = await _service.CreatePollAsync(user, dto);
            return Ok(result);
        }

        //[Authorize(Roles = "Resident")]
        [HttpPost("vote")]
        public async Task<IActionResult> Vote([FromBody] VoteDto dto)
        {
            var user = User.Identity?.Name ?? "anonymous";
            await _service.VoteAsync(user, dto);
            return Ok(new { message = "Vote submitted." });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResults(Guid id)
        {
            var result = await _service.GetPollResultsAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPolls()
        {
            var polls = await _service.GetAllPollsAsync();
            return Ok(polls);
        }
    }
}

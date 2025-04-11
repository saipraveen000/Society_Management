using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Society.Services.MaintenanceAPI.Models.Dto;
using Society.Services.MaintenanceAPI.Models;
using Society.Services.MaintenanceAPI.Services;
using Society.Services.MaintenanceAPI.ExceptionHandling;

namespace Society.Services.MaintenanceAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        private readonly IMaintenanceService _service;

        public MaintenanceController(IMaintenanceService service)
        {
            _service = service;
        }

        //[Authorize(Roles = "Resident")]
        [HttpPost]
        public async Task<IActionResult> CreateRequest([FromBody] MaintenanceRequestDto dto)
        {
            var user = User.Identity?.Name ?? "Unknown";

            var req = new MaintenanceRequest
            {
                RequestId = Guid.NewGuid(),
                Issue = dto.Issue,
                CreatedBy = user,
                AttachmentUrl = dto.AttachmentUrl
            };

            await _service.CreateRequestAsync(req);
            return Ok(req);
        }

        //[Authorize(Roles = "Admin,Resident")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllRequestsAsync());
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] string status)
        {
            await _service.UpdateStatusAsync(id, status, User.Identity?.Name);
            return NoContent();
        }

        //[Authorize(Roles = "Resident")]
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ApiException("No file uploaded", 400);

            // 🔧 This ensures the folder exists
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Generate unique file name and save it
            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Build file URL to return
            var fileUrl = $"{Request.Scheme}://{Request.Host}/uploads/{uniqueFileName}";
            return Ok(new { url = fileUrl });
        }
    }
}

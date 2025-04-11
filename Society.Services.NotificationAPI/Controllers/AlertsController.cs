using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Society.Services.NotificationAPI.Models.Dto;
using Society.Services.NotificationAPI.Services;

namespace Society.Services.NotificationAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlertsController : ControllerBase
    {
        private readonly IAlertService _alertService;

        public AlertsController(IAlertService alertService)
        {
            _alertService = alertService;
        }

        //[Authorize(Roles = "Resident,Admin")]
        [HttpGet]
        public async Task<IActionResult> GetLatestAlerts()
        {
            var alerts = await _alertService.GetLatestAlertsAsync();
            return Ok(alerts);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateAlert([FromBody] EmergencyAlertDto dto)
        {
            await _alertService.CreateAlertAsync(dto);
            return StatusCode(201);
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlert(Guid id)
        {
            try
            {
                await _alertService.DeleteAlertAsync(id);
                return NoContent(); // 204
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}

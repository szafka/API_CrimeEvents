using LawEnforcement.DTO;
using LawEnforcement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LawEnforcement.Controllers
{
    [Route("api/LawEnforcementController")]
    [ApiController]
    public class LawEnforcementController : ControllerBase
    {
        public readonly ILogger<LawEnforcementController> _logger;
        public readonly ILawEnforcementService _service;
        public LawEnforcementController(ILogger<LawEnforcementController> logger, ILawEnforcementService service)
        {
            _logger = logger;
            _service = service;
        }
        [SwaggerOperation(Summary = "Get all enforcement")]
        [HttpGet]
        public async Task<IActionResult> GetAllEnforcementsAsync()
        {
            var events = await _service.GetAllAsync();
            if (events == null)
            {
                _logger.LogInformation(NotFound().StatusCode.ToString());
                return NotFound();
            }
            _logger.LogInformation(Ok().StatusCode.ToString());
            return Ok(events);
        }

        [HttpPut("assignEvent")]
        public async Task<IActionResult> AssignEventToOfficerAsync(LawEnforcementUpdateDTO updateDTO)
        {
            await _service.AssignEventAsync(updateDTO);
            return Ok();
        }

        [SwaggerOperation(Summary = "Add new law enforcement")]
        [HttpPost]
        public async Task<IActionResult> AddNewEnforcementAsync(LawEnforcementCreateDTO createDTO)
        {
            await _service.AddNewEnforcement(createDTO);
            _logger.LogInformation(Ok().StatusCode.ToString());
            return Ok(createDTO);
        }
        [SwaggerOperation(Summary = "Delete all data")]
        [HttpDelete]
        public async Task<IActionResult> RemoveAllAsync(string password)
        {
            if (password.Equals("delete"))
            {
                await _service.DeleteAllAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}

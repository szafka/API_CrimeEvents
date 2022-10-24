using LawEnforcement.DTO;
using LawEnforcement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LawEnforcement.Controllers
{
    [Route("api/LawEnforcementControllers")]
    [ApiController]
    public class LawEnforcementControllers : ControllerBase
    {
        public readonly ILogger<LawEnforcementControllers> _logger;
        public readonly ILawEnforcementService _service;
        public LawEnforcementControllers(ILogger<LawEnforcementControllers> logger, ILawEnforcementService service)
        {
            _logger = logger;
            _service = service;
        }
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

        [SwaggerOperation(Summary = "Add new law enforcement")]
        [HttpPost]
        public async Task<IActionResult> AddNewEnforcementAsync(LawEnforcementCreateDTO createDTO)
        {
            await _service.AddNewEnforcement(createDTO);
            _logger.LogInformation(Ok().StatusCode.ToString());
            return Ok(createDTO);
        }
    }
}

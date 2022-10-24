﻿using CrimeEvent.DTO;
using CrimeEvent.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CrimeEvent.Controllers
{
    [Route("api/CrimeControllers")]
    [ApiController]
    public class CrimeControllers : ControllerBase
    {
        public readonly ILogger<CrimeControllers> _logger;
        public readonly ICrimeEventsService _service;
        public CrimeControllers(ILogger<CrimeControllers> logger, ICrimeEventsService service)
        {
            _logger = logger;
            _service = service;
        }
        [SwaggerOperation(Summary = "Get all crime events")]
        [HttpGet]
        public async Task<IActionResult> GetAllCrimeEventsAsync()
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

        [SwaggerOperation(Summary = "Set new crime event")]
        [HttpPost]
        public async Task<IActionResult> SetNewCrimeEvent(CrimeEventCreateDTO createDTO)
        {
            await _service.AddNewEvent(createDTO);
            _logger.LogInformation(Ok().StatusCode.ToString());
            return Ok(createDTO);
        }
    }
}
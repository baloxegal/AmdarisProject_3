using AmdarisProject_3.API.Services;
using AmdarisProject_3.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisProject_3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventService _service;

        public EventController(EventService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<EventDto>> GetEntities()
        {
            var result = await _service.GetEntities();
            return result.Value;
        }

        [HttpGet("{id}")]
        public async Task<EventDto> GetEntity(long identityKey)
        {
            var result = await _service.GetEntity(identityKey);
            return result.Value;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEntity(EventDto entity, long identityKey)
        {
            return await _service.UpdateEntity(entity, identityKey);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntity(EventDto entity)
        {
            return await _service.CreateEntity(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntity(long identityKey)
        {
            return await _service.DeleteEntity(identityKey);
        }
    }
}

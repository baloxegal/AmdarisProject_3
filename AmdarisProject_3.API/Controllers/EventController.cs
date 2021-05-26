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
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEntities()
        {
            return await _service.GetEntities();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetEntity(long identityKey)
        {
            return await _service.GetEntity(identityKey);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Event>> UpdateEntity(EventDto entity, long identityKey)
        {
            return await _service.UpdateEntity(entity, identityKey);
        }

        [HttpPost]
        public async Task<ActionResult<Event>> CreateEntity(EventDto entity)
        {
            return await _service.CreateEntity(entity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Event>> DeleteEntity(long identityKey)
        {
            return await _service.DeleteEntity(identityKey);
        }
    }
}

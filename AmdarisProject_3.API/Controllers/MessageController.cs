using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AmdarisProject_3.API;
using AmdarisProject_3.Domain.Models;
using AmdarisProject_3.API.Services;

namespace AmdarisProject_3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MessageService _service;

        public MessageController(MessageService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetEntities()
        {
            return await _service.GetEntities();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MessageDto>> GetEntity(long identityKey)
        {
            return await _service.GetEntity(identityKey);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEntity(MessageDto entity, long identityKey)
        {
            return await _service.UpdateEntity(entity, identityKey);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntity(MessageDto entity)
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

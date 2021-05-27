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
    public class CommentReactionController : ControllerBase
    {
        private readonly CommentReactionService _service;

        public CommentReactionController(CommentReactionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentReactionDto>>> GetEntities()
        {
            return await _service.GetEntities();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentReactionDto>> GetEntity(long identityKey)
        {
            return await _service.GetEntity(identityKey);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEntity(CommentReactionDto entity, long identityKey)
        {
            return await _service.UpdateEntity(entity, identityKey);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntity(CommentReactionDto entity)
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

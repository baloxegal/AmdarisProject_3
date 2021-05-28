using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IEnumerable<CommentReactionDto>> GetEntities()
        {
            var result = await _service.GetEntities();            
            return result.Value;
        }

        [HttpGet("{id}")]
        public async Task<CommentReactionDto> GetEntity(long identityKey)
        {
            var result = await _service.GetEntity(identityKey);
            return result.Value;
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

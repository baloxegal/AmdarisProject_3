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
    public class VideoPostController : ControllerBase
    {
        private readonly VideoPostService _service;

        public VideoPostController(VideoPostService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoPostDto>>> GetEntities()
        {
            return await _service.GetEntities();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VideoPostDto>> GetEntity(long identityKey)
        {
            return await _service.GetEntity(identityKey);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEntity(VideoPostDto entity, long identityKey)
        {
            return await _service.UpdateEntity(entity, identityKey);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntity(VideoPostDto entity)
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
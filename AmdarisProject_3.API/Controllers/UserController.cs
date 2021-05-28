using AmdarisProject_3.API.Services;
using AmdarisProject_3.Domain.Models;
using AmdarisProject_3.Domain.Models.Dtos;
using AutoMapper;
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
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetEntities()
        {
            var result = await _service.GetEntities();
            return result.Value;
        }

        [HttpGet("{id}")]
        public async Task<UserDto> GetEntity(string identityKey)
        {
            var result = await _service.GetEntity(identityKey);
            return result.Value;
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<UserDto>> GetEntityByUserName(string userNameKey)
        {
            var result = await _service.GetEntityByUserName(userNameKey);
            return result.Value;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEntity(UserDto entity, string identityKey)
        {
            return await _service.UpdateEntity(entity, identityKey);
        }

        [HttpPut("{userName}")]
        public async Task<IActionResult> UpdateEntityByUserName(UserDto entity, string userNameKey)
        {
            return await _service.UpdateEntityByUserName(entity, userNameKey);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntity(UserDto entity)
        {
            return await _service.CreateEntity(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntity(string identityKey)
        {
            return await _service.DeleteEntity(identityKey);
        }

        [HttpDelete("{userName}")]
        public async Task<IActionResult> DeleteEntityByUserName(string userNameKey)
        {
            return await _service.DeleteEntityByUserName(userNameKey);
        }
    }
}

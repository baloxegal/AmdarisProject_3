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
        private readonly IMapper _mapper;

        public UserController(UserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetEntities()
        {
            return await _service.GetEntities();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetEntity(string identityKey)
        {
            return await _service.GetEntity(identityKey);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateEntity(UserDto entity, string identityKey)
        {
            return await _service.UpdateEntity(entity, identityKey);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateEntity(UserDto entity)
        {
            var baseEntity =_mapper.Map(entity, new User());
            return await _service.CreateEntity(baseEntity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteEntity(string identityKey)
        {
            return await _service.DeleteEntity(identityKey);
        }
    }
}

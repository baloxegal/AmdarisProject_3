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
    public class RelationshipController : ControllerBase
    {
        //private readonly IService<Relationship, long> _service;

        //public RelationshipController(IService<Relationship, long> service)
        //{
        //    _service = service;
        //}

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Relationship>>> GetEntities()
        //{
        //    return await _service.GetEntities();
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Relationship>> GetEntity(long identityKey)
        //{
        //    return await _service.GetEntity(identityKey);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult<Relationship>> UpdateEntity(Relationship entity, long identityKey)
        //{
        //    return await _service.UpdateEntity(entity, identityKey);
        //}

        //[HttpPost]
        //public async Task<ActionResult<Relationship>> CreateEntity(Relationship entity)
        //{
        //    return await _service.CreateEntity(entity);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Relationship>> DeleteEntity(long identityKey)
        //{
        //    return await _service.DeleteEntity(identityKey);
        //}
    }
}

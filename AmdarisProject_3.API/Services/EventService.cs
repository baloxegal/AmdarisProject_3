using AmdarisProject_3.API.Repositories;
using AmdarisProject_3.Domain.Models;
using AmdarisProject_3.Domain.Models.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisProject_3.API.Services
{
    public class EventService
    {
        private readonly IRepository<Event, long> _repository;
        private readonly IMapper _mapper;

        public EventService(IRepository<Event, long> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<EventDto>>> GetEntities()
        {
            var result = await _repository.GetEntities();

            return result.Value.Select(res => _mapper.Map(res, new EventDto())).ToList();             
        }

        public async Task<ActionResult<EventDto>> GetEntity(long identityKey)
        {
            var result = await _repository.GetEntity(identityKey);

            return _mapper.Map(result.Value, new EventDto());
        }

        public async Task<ActionResult<Event>> UpdateEntity(EventDto entity, long identityKey)
        {
            var baseEntity = await _repository.GetEntity(identityKey);
            if (baseEntity.Value == null)
            {
                return new BadRequestObjectResult(new { message = $"Entity with identity key {identityKey} doesn't exist" });
            }

            _mapper.Map(entity, baseEntity.Value);            

            return await _repository.Save();
        }

        public async Task<ActionResult<Event>> CreateEntity(EventDto entity)
        {
            var baseEntity = _mapper.Map(entity, new Event());
            return await _repository.CreateEntity(baseEntity);
        }

        public async Task<ActionResult<Event>> DeleteEntity(long identityKey)
        {
            var baseEntity = await _repository.GetEntity(identityKey);
            if (baseEntity.Value == null)
            {
                return new BadRequestObjectResult(new { message = $"Entity with identity key {identityKey} doesn't exist" });
            }

            try
            {
                return await _repository.Remove(baseEntity.Value);
            }
            catch (Exception)
            {
                return new BadRequestObjectResult(new { message = $"Entity with identity key {identityKey} doesn't deleted. Error in database." });
            }
        }
    }
}

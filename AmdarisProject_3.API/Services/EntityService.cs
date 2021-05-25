using AmdarisProject_3.API.Repositories;
using AmdarisProject_3.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisProject_3.API.Services
{
    public class EntityService<IEntity, T> : ControllerBase, IService<IEntity, T> where IEntity : class
    {
        private readonly EntityRepository<IEntity, T> _repository;
        public readonly IMapper _mapper;
        public EntityService(EntityRepository<IEntity, T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<IEntity>>> GetEntities()
        {
            return await _repository.GetEntities();
        }

        public async Task<ActionResult<IEntity>> GetEntity(T identityKey)
        {
            return await _repository.GetEntity(identityKey);
        }       

        public async Task<ActionResult<IEntity>> UpdateEntity(IEntity entity, T identityKey)
        {

            var baseEntity = await _repository.GetEntity(identityKey);
            if (baseEntity.Value == null)
            {
                return new BadRequestObjectResult(new { message = $"Entity with identity key {identityKey} doesn't exist" });
            }

            _mapper.Map(entity, baseEntity);

            return await _repository.Save();
        }

        public async Task<ActionResult<IEntity>> CreateEntity(IEntity entity)
        {
            return await _repository.CreateEntity(entity);
        }       

        public async Task<ActionResult<IEntity>> DeleteEntity(T identityKey)
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

        //public async Task<ActionResult<IEntity>> UpdateEntity(IEntity entity, T identityKey)
        //{
        //    return await _repository.UpdateEntity(entity, identityKey);
        //}

        //public async Task<ActionResult<IEntity>> DeleteEntity(T identityKey)
        //{
        //    return await _repository.DeleteEntity(identityKey);
        //}
    }
}

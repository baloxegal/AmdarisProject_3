using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmdarisProject_3.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmdarisProject_3.API.Repositories
{
    public class EntityRepository<IEntity, T> : IRepository<IEntity, T> where IEntity : class
    {
        public readonly DbContext _context;
        public readonly DbSet<IEntity> _entity;
        public readonly IMapper _mapper;

        public EntityRepository(SocialMediaDbContext context, IMapper mapper)
        {
            _context = context;
            _entity = _context.Set<IEntity>();
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<IEntity>>> GetEntities()
        {
            return await _entity.ToListAsync();
        }

        public async Task<ActionResult<IEntity>> GetEntity(T identityKey)
        {
            return await _entity.FindAsync(identityKey);            
        }

        public async Task<ActionResult<IEntity>> CreateEntity(IEntity entity)            
        {
            try
            {
                _entity.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }

            return new OkObjectResult(new { entity = entity, message = $"Entity was created" });
        }

        public async Task<ActionResult<IEntity>> Save()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }

            return new OkResult();
        }

        public async Task<ActionResult<IEntity>> Remove(IEntity entity)
        {
            try
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }

            return new OkResult();
        }

        //public async Task<ActionResult<IEntity>> DeleteEntity(T identityKey)
        //{
        //    var baseEntity = await _entity.FindAsync(identityKey);
        //    if (baseEntity == null)
        //    {
        //        return new BadRequestObjectResult(new { message = $"Entity with identity key {identityKey} doesn't exist" });
        //    }

        //    try
        //    {
        //        _entity.Remove(baseEntity);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException ex)
        //    {
        //        throw new DbUpdateException(ex.Message);
        //    }

        //    return new OkObjectResult(new { entity = baseEntity, message = $"Entity was deleted" });
        //}

        //public async Task<ActionResult<IEntity>> UpdateEntity(IEntity entity, T identityKey)
        //{
        //    var baseEntity = await _entity.FindAsync(identityKey);
        //    if (baseEntity == null)
        //    {
        //        return new BadRequestObjectResult( new { message = $"Entity with identity key {identityKey} doesn't exist" });
        //    }

        //    _mapper.Map(entity, baseEntity);

        //    try
        //    {                
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException ex)
        //    {
        //        throw new DbUpdateException(ex.Message);
        //    }

        //    return new OkObjectResult(new {entity = baseEntity, message = $"Entity with identity key {identityKey} was modified" });
        //}               
    }
}

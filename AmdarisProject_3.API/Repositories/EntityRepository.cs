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
        private readonly DbContext _context;
        private readonly DbSet<IEntity> _entity;

        public EntityRepository(SocialMediaDbContext context)
        {
            _context = context;
            _entity = _context.Set<IEntity>();
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

        public async Task<ActionResult<bool>> IsExist(IEntity entity)
        {
            var result = await _entity.ToListAsync();
            if (result.Contains(entity))
                return true;
            else
                return false;            
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmdarisProject_3.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmdarisProject_3.Infrastucture.Repositories
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

        public async Task<IActionResult> CreateEntity(IEntity entity)            
        {
            int result;
            try
            {
                _entity.Add(entity);
                result = await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException();
            }

            return new OkObjectResult(new { message = $"Entities in number of {result} was created" });
        }

        public async Task<IActionResult> Save()
        {
            int result;
            try
            {
                result = await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                //throw new DbUpdateException(ex.Message);
                return new BadRequestObjectResult(new { message = $"Entity wasn't saved. " + ex.Message });
            }

            return new OkObjectResult(new { message = $"Entities in number of {result} was saved" });
        }

        public async Task<IActionResult> Remove(IEntity entity)
        {
            int result;
            try
            {
                _context.Remove(entity);
                result = await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }

            return new OkObjectResult(new { message = $"Entities in number of {result} was removed" });
        }
    }
}

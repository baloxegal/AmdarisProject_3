using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmdarisProject_3.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmdarisProject_3.API.Repositories
{
    public class EntityRepository<IEntity, T> : IRepository<IEntity, T>
    {  
        public Task<ActionResult<IEntity>> CreateEntity(IEntity entity);
        public Task<ActionResult<IEntity>> DeleteEntity(T identityKey);
        public Task<ActionResult<IEntity>> DeleteEntity(IEntity entity);

        public DbContext _context;
        public DbSet<IEntity> _entity;

        public EntityRepository(SocialMediaDbContext context)
        {
            _context = context;
            _entity = _context.Set<IEntity>();
        }

        // GET: api/Entities
        public async Task<ActionResult<IEnumerable<IEntity>>> ReadEntities()
        {
            return await _entity.ToListAsync();
        }

        // GET: api/Entity/5
        public async Task<ActionResult<IEntity>> ReadEntity(T identityKey)
        {
            return await _entity.FindAsync(identityKey);            
        }

        // PUT: api/Entity/5
        public async Task<ActionResult<IEntity>> UpdateEntity(T identityKey, T user)
        {
            var entity = await _entity.FindAsync(identityKey);
            if (entity == null)
            {
                return BadRequestObjectResult();
            }

            ModifyUser(userBase, user);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!UserExists(id))
            {
                throw;
            }

            return userBase;
        }

        // PATCH: api/Entity/5
        public async Task<ActionResult<IEntity>> UpdateEntity(long id, IEntity)
        {
            var user = await _table.FindAsync(id);
            if (user == null)
            {
                return user;
            }

            ModifyUserDTO(user, IEntity);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!UserExists(id))
            {
                throw;
            }

            return IEntity;
        }

        // POST: api/Entity
        public async Task<ActionResult<IEntity>> CreateEntity(IEntity userDTO)
        {
            T user = UserDTOToUser(userDTO);
            try
            {
                _table.Add(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("Same Id exist!");
            }

            return user;
        }

        // DELETE: api/Entity/5
        public async Task<ActionResult<IEntity>> DeleteEntity(long id)
        {
            var user = await _table.FindAsync(id);
            if (user == null)
            {
                return user;
            }

            _table.Remove(user);
            await _context.SaveChangesAsync();

            return UserToUserDTO(user);
        }

        private bool UserExists(long id)
        {
            if (_table.Find(id) != null)
                return true;

            return false;
        }
        

        //public Task<ActionResult<IEntity>> CreateEntity(IEntity entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ActionResult<IEntity>> DeleteEntity(T identityKey)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ActionResult<IEntity>> DeleteEntity(IEntity entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ActionResult<IEnumerable<IEntity>>> ReadEntities()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ActionResult<IEntity>> ReadEntity(T identityKey)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ActionResult<IEntity>> UpdateEntity(T identityKey, IEntity entity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

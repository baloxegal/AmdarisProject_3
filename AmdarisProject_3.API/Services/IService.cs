using AmdarisProject_3.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisProject_3.API.Services
{
    public interface IService<IEntity, T> where IEntity : class
    {
        public Task<ActionResult<IEnumerable<IEntity>>> GetEntities();
        public Task<ActionResult<IEntity>> GetEntity(T identityKey);
        public Task<ActionResult<IEntity>> UpdateEntity(IEntity entity, T identityKey);
        public Task<ActionResult<IEntity>> CreateEntity(IEntity entity);
        public Task<ActionResult<IEntity>> DeleteEntity(T identityKey);
    }
}

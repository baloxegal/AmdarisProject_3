using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisProject_3.API.Repositories
{
    public interface IRepository<IEntity, T>
    {
        public Task<ActionResult<IEnumerable<IEntity>>> GetEntities();
        public Task<ActionResult<IEntity>> GetEntity(T identityKey);        
        public Task<ActionResult<IEntity>> CreateEntity(IEntity entity);
        
    }
}

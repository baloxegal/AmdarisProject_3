using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisProject_3.API.Repositories
{
    interface IRepository<IEntity, T>
    {
        public Task<ActionResult<IEnumerable<IEntity>>> ReadEntities();
        public Task<ActionResult<IEntity>> ReadEntity(T identityKey);
        public Task<ActionResult<IEntity>> UpdateEntity(T identityKey, IEntity entity);
        public Task<ActionResult<IEntity>> CreateEntity(IEntity entity);
        public Task<ActionResult<IEntity>> DeleteEntity(T identityKey);
        public Task<ActionResult<IEntity>> DeleteEntity(IEntity entity);
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisProject_3.Infrastucture.Repositories
{
    public interface IRepository<IEntity, T>
    {
        public Task<ActionResult<IEnumerable<IEntity>>> GetEntities();
        public Task<ActionResult<IEntity>> GetEntity(T identityKey);
        public Task<IActionResult> CreateEntity(IEntity entity);
        public Task<IActionResult> Save();
        public Task<IActionResult> Remove(IEntity entity);
    }
}

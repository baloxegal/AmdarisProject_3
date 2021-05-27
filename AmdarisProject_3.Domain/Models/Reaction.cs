using System;

namespace AmdarisProject_3.Domain.Models
{
    public abstract class Reaction : IEntity
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public User Author { get; set; }
    }
}
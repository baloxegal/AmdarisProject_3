using System;
using System.Collections.Generic;

namespace AmdarisProject_3.Domain.Models
{
    public class Event : IEntity
    {
        public long Id { get; set; }        
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public virtual ICollection<User> Authors { get; set; }
        public virtual ICollection<User> Participants { get; set; }
    }
}

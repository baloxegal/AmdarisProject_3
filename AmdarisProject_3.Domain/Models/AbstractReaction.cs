using System;
using AmdarisProject_3.Domain.Models.Auth;

namespace AmdarisProject_3.Domain.Models
{
    public class AbstractReaction
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public ApplicationUser Author { get; set; }
    }
}
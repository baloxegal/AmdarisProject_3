using AmdarisProject_3.Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmdarisProject_3.Domain.Models
{
    public class Event
    {
        public long Id { get; set; }        
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        [NotMapped]
        public ApplicationUser AuthorId { get; set; }
        public virtual ICollection<ApplicationUser> Authors { get; set; }
        [NotMapped]
        public ApplicationUser ParticipantId { get; set; }
        public virtual ICollection<ApplicationUser> Participant { get; set; }
    }
}

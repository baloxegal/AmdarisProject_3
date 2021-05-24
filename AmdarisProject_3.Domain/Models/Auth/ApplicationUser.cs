using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmdarisProject_3.Domain.Models.Auth
{
    public class ApplicationUser : IdentityUser, IEntity
    {        
        [Column(TypeName = "nvarchar(150)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public virtual ICollection<Event> EventsAuthor { get; set; }
        public virtual ICollection<Event> EventsParticipants { get; set; }
        public virtual ICollection<AbstractPost> AbstractPosts { get; set; }
        public virtual ICollection<AbstractReaction> AbstractReactions { get; set; }
        public virtual ICollection<Message> Messages { get; set; }

    }
}

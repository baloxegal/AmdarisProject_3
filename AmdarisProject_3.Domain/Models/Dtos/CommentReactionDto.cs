using AmdarisProject_3.Domain.Models.Dtos;
using System;

namespace AmdarisProject_3.Domain.Models
{
    public class CommentReactionDto
    {        
        public UserDto Author { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}

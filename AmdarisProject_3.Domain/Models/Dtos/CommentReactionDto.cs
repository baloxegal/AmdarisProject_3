using System;

namespace AmdarisProject_3.Domain.Models
{
    public class CommentReactionDto
    {        
        public string AuthorId { get; set; }
        public string LikeImageUrl { get; set; }
        public string LoveImageUrl { get; set; }
        public string CareImageUrl { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}

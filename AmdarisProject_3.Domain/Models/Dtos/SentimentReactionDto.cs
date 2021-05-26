using System;

namespace AmdarisProject_3.Domain.Models
{
    public class SentimentReactionDto
    {        
        public string AuthorId { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}

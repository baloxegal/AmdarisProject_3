using System;

namespace AmdarisProject_3.Domain.Models
{
    public class VideoPostDto
    {
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string AuthorId { get; set; }
        public string VideoUrl { get; set; }
    }
}
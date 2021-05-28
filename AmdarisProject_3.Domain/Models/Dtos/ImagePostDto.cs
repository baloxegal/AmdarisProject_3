using AmdarisProject_3.Domain.Models.Dtos;
using System;

namespace AmdarisProject_3.Domain.Models
{
    public class ImagePostDto
    {
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
    }
}
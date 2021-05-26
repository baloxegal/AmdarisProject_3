﻿using System;

namespace AmdarisProject_3.Domain.Models
{
    public class TextPostDto
    {
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string AuthorId { get; set; }
        public string Content { get; set; }
    }
}
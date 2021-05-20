﻿using System;
using AmdarisProject_3.Domain.Models.Auth;

namespace AmdarisProject_3.Domain.Models
{
    public abstract class AbstractPost
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public ApplicationUser Author { get; set; }
    }
}

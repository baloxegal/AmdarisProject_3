using System;

namespace AmdarisProject_3.Domain.Models
{
    public class EventDto
    {      
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
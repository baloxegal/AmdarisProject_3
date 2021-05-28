using System;

namespace AmdarisProject_3.Domain.Models
{
    public class RelationshipDto
    {
        public string Initiator { get; set; }
        public string Respondent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public RelationshipStatus Status { get; set; }        
    }
}

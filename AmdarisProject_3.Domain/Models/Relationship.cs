using System;

namespace AmdarisProject_3.Domain.Models
{
    public class Relationship : IEntity
    {
        public long Id { get; set; }
        public User Initiator { get; set; }
        public User Respondent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public RelationshipStatus Status { get; set; }
       
    }

    public enum RelationshipStatus
    {
        Friendship,
        Folow,
        Ban
    }
}

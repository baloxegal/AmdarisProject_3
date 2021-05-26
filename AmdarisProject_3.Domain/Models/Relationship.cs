using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmdarisProject_3.Domain.Models
{
    public class Relationship : IEntity
    {
        public long Id { get; set; }
        public User Initiator { get; set; }
        public User Respondent { get; set; }
        public DateTime Start { get; set; }        
        public RelationshipStatuses Status { get; set; }
        public DateTime ModificationData { get; set; }

        //public RelationshipSides ModificationUser { get; set; }
    }

    public enum RelationshipStatuses
    {
        Friendship,
        Folow,
        Ban
    }

    //enum RelationshipSides
    //{
    //    InitiatorSide,
    //    RespondentSide
    //}
}

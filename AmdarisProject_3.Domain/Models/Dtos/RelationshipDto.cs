using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmdarisProject_3.Domain.Models
{
    public class RelationshipDto
    {
        public string InitiatorId { get; set; }
        public string RespondentId { get; set; }
        public DateTime Start { get; set; }        
        public RelationshipStatuses Status { get; set; }
        public DateTime ModificationData { get; set; }
    }
}

using AmdarisProject_3.Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmdarisProject_3.Domain.Models
{
    public class RelationshipDto
    {
        public UserDto Initiator { get; set; }
        public UserDto Respondent { get; set; }
        public DateTime Start { get; set; }        
        public RelationshipStatuses Status { get; set; }
        public DateTime ModificationData { get; set; }
    }
}

using AmdarisProject_3.Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmdarisProject_3.Domain.Models
{
    public class Message
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }       
        public ApplicationUser Sender { get; set; }
        public ApplicationUser Receiver { get; set; }
        public string Body { get; set; }
        public StatusType Status { get; set; }
    }
    public enum StatusType
    {
        SENDED,
        DELIVERED,
        VIEWED        
    }
}

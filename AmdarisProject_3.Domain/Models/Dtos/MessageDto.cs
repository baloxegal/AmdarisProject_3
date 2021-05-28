using System;

namespace AmdarisProject_3.Domain.Models
{
    public class MessageDto
    {
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }       
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Body { get; set; }
        public StatusType Status { get; set; }
    }
}

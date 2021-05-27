﻿using AmdarisProject_3.Domain.Models.Auth;
using AmdarisProject_3.Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmdarisProject_3.Domain.Models
{
    public class MessageDto
    {
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }       
        public UserDto Sender { get; set; }
        public UserDto Receiver { get; set; }
        public string Body { get; set; }
        public StatusType Status { get; set; }
    }
}

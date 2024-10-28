﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Dto
{
    public class RegisterDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }       
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }        
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset RegisterDate { get; set; }
    }
}
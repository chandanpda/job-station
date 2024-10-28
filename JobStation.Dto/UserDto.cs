﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Dto
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
      
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset RegisterDate { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string TimezoneId { get; set; }
        public RoleDto Role { get; set; }
        public string Token { get; set; }


        //public bool EmailConfirmed { get; set; }
        //public string FullName { get; set; }
        //public string CompanyName { get; set; }
        //public string ProfilePicture { get; set; }
        //public bool IsActive { get; set; }
    }
}

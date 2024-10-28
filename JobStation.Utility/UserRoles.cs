using System;
using System.Collections.Generic;

namespace JobStation.Utility
{
    public class UserRoles
    {
        //public const string Administrator = "Administrator";        
        public const string SuperAdmin = "SuperAdmin";
        public const string Employer = "Employer";
        public const string User = "User";

        public static List<UserRolesTypeRepeater> GetUserRolesType()
        {
            var result = new List<UserRolesTypeRepeater>
            {
                new UserRolesTypeRepeater{ Key = SuperAdmin, Value = SuperAdmin},
                new UserRolesTypeRepeater{ Key = Employer, Value = Employer},
                new UserRolesTypeRepeater{ Key = User, Value = User}
               
            };
            return result;
        }
    }

    public class UserRolesTypeRepeater
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
   


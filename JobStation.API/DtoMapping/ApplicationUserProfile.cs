using AutoMapper;
using JobStation.Core.Domain;
using JobStation.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobStation.API.DtoMapping
{
    public class ApplicationUserProfile: Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dependency_injection_sample.Models;
using Dependency_injection_sample.Dtos;
using AutoMapper;
namespace Dependency_injection_sample
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile(){
            CreateMap<User, GetUserDto>();
            CreateMap<AddUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<AddRoleDto, Role>();
        }
        
    }
}
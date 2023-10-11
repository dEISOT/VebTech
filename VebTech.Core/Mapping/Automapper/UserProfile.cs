﻿using AutoMapper;
using VebTech.Core.DTO;
using VebTech.Data.Entities;
using VebTech.Model.Response;

namespace VebTech.Core.Mapping.Automapper
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Role, RoleResponseModel>();
            CreateMap<Role, UserResponseModel>();
            CreateMap<RoleResponseModel, UserResponseModel>();
            CreateMap<User, UserResponseModel>();

        }
    }
}

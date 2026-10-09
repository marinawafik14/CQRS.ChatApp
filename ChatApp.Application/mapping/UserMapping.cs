using AutoMapper;
using ChatApp.Application.Dtos.Users;
using ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
        }

    }
}

using AutoMapper;
using Lagalt.DTOs;
using Lagalt.Models;
using System;

namespace Lagalt.Profiles
{
    public class UserProfil : Profile
    {
        public UserProfil()
        {
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}

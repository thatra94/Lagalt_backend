using AutoMapper;
using Lagalt.DTOs;
using Lagalt.DTOs.Users;
using Lagalt.Models;
using System;

namespace Lagalt.Profiles
{
    public class UserProfil : Profile
    {
        public UserProfil()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserCreateDto, User>().ReverseMap();
            CreateMap<UserUpdateDto, User>().ReverseMap();
            CreateMap<UserShortDto, User>().ReverseMap();
            CreateMap<UserProfilDto, User>().ReverseMap();
        }
    }
}

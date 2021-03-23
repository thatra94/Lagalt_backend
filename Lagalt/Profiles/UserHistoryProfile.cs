using AutoMapper;
using Lagalt.DTOs.UserHistories;
using Lagalt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.Profiles
{
    public class UserHistoryProfile : Profile
    {
        public UserHistoryProfile()
        {
            CreateMap<UserHistoryDto, UserHistory>().ReverseMap();
            CreateMap<UserHistoryCreateDto, UserHistory>().ReverseMap();
        }
   
    }
}

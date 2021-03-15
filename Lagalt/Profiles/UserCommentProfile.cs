using AutoMapper;
using Lagalt.DTOs.UserComments;
using Lagalt.Models;

namespace Lagalt.Profiles
{
    public class UserCommentProfile : Profile
    {
        public UserCommentProfile()
        {
            CreateMap<UserCommentDto, UserComment>().ReverseMap();
            CreateMap<UserCommentCreateDto, UserComment>().ReverseMap();
        }
    }
}

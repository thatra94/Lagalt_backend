using AutoMapper;
using Lagalt.DTOs.Links;
using Lagalt.Models;

namespace Lagalt.Profiles
{
    public class LinkProfile : Profile
    {
        public LinkProfile()
        {
            CreateMap<LinkDto, Link>().ReverseMap();
            CreateMap<LinkCreateDto, Link>().ReverseMap();
        }
    }
}

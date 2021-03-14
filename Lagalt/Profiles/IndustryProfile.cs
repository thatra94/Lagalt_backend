using AutoMapper;
using Lagalt.DTOs.Industries;
using Lagalt.Models;

namespace Lagalt.Profiles
{
    public class IndustryProfile : Profile
    {
        public IndustryProfile()
        {
            CreateMap<IndustryDto, Industry>().ReverseMap();
            CreateMap<IndustryCreateDto, Industry>().ReverseMap();
        }
    }
}

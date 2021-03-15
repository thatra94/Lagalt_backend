using AutoMapper;
using Lagalt.DTOs.Themes;
using Lagalt.Models;

namespace Lagalt.Profiles
{
    public class ThemeProfile : Profile
    {
        public ThemeProfile()
        {
            CreateMap<ThemeDto, Theme>().ReverseMap();
            CreateMap<ThemeCreateDto, Theme>().ReverseMap();
        }
    }
}

using AutoMapper;
using Lagalt.DTOs.Portfolio;
using Lagalt.Models;

namespace Lagalt.Profiles
{
    public class PortfolioProfile : Profile
    {
        public PortfolioProfile()
        {
            CreateMap<PortfolioDto, Portfolio>().ReverseMap();
            CreateMap<PortfolioCreateDto, Portfolio>().ReverseMap();
        }
    }
}

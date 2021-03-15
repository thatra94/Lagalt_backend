using AutoMapper;
using Lagalt.DTOs;
using Lagalt.Models;

namespace Lagalt.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectDto, Project>().ReverseMap();
            CreateMap<ProjectCreateDto, Project>().ReverseMap();
            CreateMap<ProjectMainDto, Project>().ReverseMap();
        }
    }
}

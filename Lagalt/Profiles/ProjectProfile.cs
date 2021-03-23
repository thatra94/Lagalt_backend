using AutoMapper;
using Lagalt.DTOs;
using Lagalt.DTOs.Projects;
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
            CreateMap<ProjectViewDto, Project>().ReverseMap();
            CreateMap<ProjectSkillsDto, Project>().ReverseMap();
            CreateMap<ProjectUpdateDto, Project>().ReverseMap();
            //For mapping user comments from a specific project
            CreateMap<ProjectCommentsDto, UserComment>().ReverseMap();
        }
    }
}

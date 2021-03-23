using AutoMapper;
using Lagalt.DTOs.ProjectApplications;
using Lagalt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.Profiles
{
    public class ProjectApplicationProfil : Profile
    {
        public ProjectApplicationProfil()
        {
            CreateMap<ProjectApplicationDto, ProjectApplication>().ReverseMap();
            CreateMap<ProjectApplicationCreateDto, ProjectApplication>().ReverseMap();

        }
    }
}

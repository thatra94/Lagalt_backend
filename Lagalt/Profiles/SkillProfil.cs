using AutoMapper;
using Lagalt.DTOs;
using Lagalt.Models;

namespace Lagalt.Profiles
{
    public class SkillProfil: Profile
    {
        public SkillProfil()
        {
            CreateMap<SkillDto, Skill>().ReverseMap();
        }
    }
}

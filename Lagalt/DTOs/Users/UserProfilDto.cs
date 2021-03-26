using Lagalt.DTOs.Portfolio;
using Lagalt.DTOs.Projects;
using Lagalt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.DTOs.Users
{
    public class UserProfilDto { 

        public string Name { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public bool Hidden { get; set; }
        //Relationship
        public ICollection<SkillCreateDto>? Skills { get; set; }
        public ICollection<ProjectSkillsDto> Projects { get; set; }
       
        public ICollection<PortfolioUser> Portofolios { get; set; }
    }
}

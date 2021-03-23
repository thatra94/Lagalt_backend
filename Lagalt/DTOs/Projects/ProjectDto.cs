using Lagalt.DTOs.Links;
using Lagalt.DTOs.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.DTOs
{
    public class ProjectDto
    {
        // Primary key
        public int Id { get; set; }
        // Fields
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }
        public int IndustryId { get; set; }

        public ICollection<SkillDto> Skills { get; set; }
        public ICollection<ThemeDto> Themes { get; set; }
        public ICollection<LinkDto> Links { get; set; }
    }
}

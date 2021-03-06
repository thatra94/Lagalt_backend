using Lagalt.DTOs.Themes;
using System.Collections.Generic;

namespace Lagalt.DTOs.Projects
{
    public class ProjectSkillsDto
    {
        // Primary key
        public int Id { get; set; }
        // Fields
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }
        // Industry field
        public string IndustryName { get; set; }
        public ICollection<SkillDto> Skills { get; set; }
        public ICollection<ThemeDto> Themes { get; set; }
    }
}

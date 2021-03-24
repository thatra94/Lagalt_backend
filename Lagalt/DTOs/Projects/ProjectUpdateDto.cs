using Lagalt.DTOs.Links;
using Lagalt.DTOs.Themes;
using System.Collections.Generic;

namespace Lagalt.DTOs.Projects
{
    public class ProjectUpdateDto
    {
        // Primary key
        public int Id { get; set; }
        // Fields
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }
        public int IndustryId { get; set; }
        // public int UserId { get; set; } Probably not needed
        public ICollection<LinkCreateDto> Links { get; set; }
        public ICollection<ThemeCreateDto> Themes { get; set; }
        public ICollection<SkillCreateDto> Skills { get; set; }
    }
}

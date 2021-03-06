using Lagalt.DTOs.Industries;
using Lagalt.DTOs.Links;
using Lagalt.DTOs.Themes;
using Lagalt.DTOs.Users;
using Lagalt.Models;
using System.Collections.Generic;

namespace Lagalt.DTOs.Projects
{
    public class ProjectViewDto
    {
        // Primary Key
        public int Id { get; set; }
        // Fields
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }  // ("Opprettet", "Under utvikling", "På vent", "Ferdig")
        public string IndustryName { get; set; }
        public int IndustryId { get; set; }

        public string UserName { get; set; }
        // Foreign keys
        public int UserId { get; set; } // Creator <-> Admin
        // Relationships
        public ICollection<LinkDto> Links { get; set; }
        public ICollection<UserNameDto> Users { get; set; }
        public ICollection<ThemeDto> Themes { get; set; }
        public ICollection<SkillDto> Skills { get; set; }
    }
}

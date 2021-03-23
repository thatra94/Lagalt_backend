using Lagalt.DTOs.Links;
using Lagalt.DTOs.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.DTOs
{
    public class ProjectCreateDto
    {
        // Fields
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [DataType(DataType.ImageUrl)]
        [MaxLength(2083)]
        public string ImageUrl { get; set; }
        [MaxLength(20)]
        public string Status { get; set; }
        // Foreign key
        public int IndustryId { get; set; }
        public int UserId { get; set; }
        // For adding skills, themes and links when creating project
        public ICollection<SkillCreateDto> Skills { get; set; }
        public ICollection<ThemeCreateDto> Themes { get; set; }
        public ICollection<LinkCreateDto> Links { get; set; }
    }
}

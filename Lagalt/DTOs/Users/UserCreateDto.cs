using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.DTOs.Users
{
    public class UserCreateDto
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public ICollection<SkillPostDto>? Skills { get; set; }
    }
}

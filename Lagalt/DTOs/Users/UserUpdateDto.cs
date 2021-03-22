using Lagalt.DTOs.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.DTOs.Users
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public ICollection<SkillCreateDto>? Skills { get; set; }
        public ICollection<PortfolioUser>? Portofolios { get; set; }

    }
}

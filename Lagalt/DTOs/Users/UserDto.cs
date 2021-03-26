using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string ?ImageUrl { get; set; }
        public string ?Description { get; set; }
        public bool Hidden { get; set; }
        public ICollection<SkillCreateDto> ?Skills { get; set; }
}
}

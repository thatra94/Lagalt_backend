using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.Models
{
    public class Skill
    {
        public int Id { get; set; }
        //Fields
        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        // Relationships
        public ICollection<User> Users { get; set; }
        public ICollection<Project> Projects { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        //Fields
        [MaxLength(200)]
        [Required]
        public string Name { get; set; }
        public string Link { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        //Relationship
        public int UserId { get; set; }
        public User User { get; set; }

    }
}

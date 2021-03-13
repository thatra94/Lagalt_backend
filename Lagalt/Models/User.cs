using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lagalt.Models
{
    public class User
    {
        public int Id { get; set; }
        //Fields
        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        // Reference for keycloak
        public string UserToken { get; set; }

        [DataType(DataType.ImageUrl)]
        [MaxLength(2083)]
        public string ImageUrl { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }

        //Relationship
        public ICollection<Skill> Skills { get; set; }
        public ICollection<Project> Projects { get; set; }

    }
}

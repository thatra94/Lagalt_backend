using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lagalt.Models
{
    public class Industry
    {
        // Primary Key
        public int Id { get; set; }
        // Fields
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        // Relationships
        public ICollection<Project> Projects { get; set; }
    }
}

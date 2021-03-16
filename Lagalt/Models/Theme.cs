using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Lagalt.Models
{
    public class Theme
    {
        // Primary key
        public int Id { get; set; }
        // Fields
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        // Relationships
        public ICollection<Project> Projects { get; set; }
    }
}

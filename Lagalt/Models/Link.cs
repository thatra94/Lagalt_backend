using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lagalt.Models
{
    public class Link
    {
        // Primary Key
        public int Id { get; set; }
        // Fields
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Url)]
        [MaxLength(2083)]
        public string Url { get; set; }
        // Foreign Key
        public int ProjectId { get; set; }
        // Relationships
        public Project Project { get; set; }
    }
}

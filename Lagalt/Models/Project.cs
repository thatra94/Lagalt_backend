using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.Models
{
    public class Project
    {
        // Primary key
        public int Id { get; set; }
        // Fields
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [DataType(DataType.ImageUrl)]
        [MaxLength(2083)]
        public string ImageUrl { get; set; }
        [MaxLength(20)]
        public string  Status { get; set; }  // ("Founding", "In progress", "Stalled", and "Completed")
        // Relationships
        public int IndustryId { get; set; }
    }
}

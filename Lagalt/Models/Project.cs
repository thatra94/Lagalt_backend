using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.Models
{
    public class Project
    {
        // Primary key
        public int Id { get; set; }
        // Fields
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string  Status { get; set; }
        // Relationships
        public int IndustryId { get; set; }
    }
}

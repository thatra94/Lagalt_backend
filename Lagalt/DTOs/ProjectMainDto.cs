using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.DTOs
{
    public class ProjectMainDto
    {
        // Primary key
        public int Id { get; set; }
        // Fields
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }
        // Industry name
        public int IndustryId { get; set; }
    }
}

using Lagalt.DTOs.Industries;
using System.Collections.Generic;


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
        // Industry field
        public string IndustryName { get; set; }
 
    }
}

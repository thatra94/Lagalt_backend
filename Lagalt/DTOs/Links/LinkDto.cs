using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.DTOs.Links
{
    public class LinkDto
    {
        // Primary Key
        public int Id { get; set; }
        // Fields
        public string Name { get; set; }
        public string Url { get; set; }
        // Foreign Key
        public int ProjectId { get; set; }
    }
}

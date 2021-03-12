using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
    }
}

using System.ComponentModel.DataAnnotations;

namespace Lagalt.DTOs.Industries
{
    public class IndustryCreateDto
    {
        // Fields
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}

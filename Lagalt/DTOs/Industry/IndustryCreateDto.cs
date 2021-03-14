using System.ComponentModel.DataAnnotations;

namespace Lagalt.DTOs.Industry
{
    public class IndustryCreateDto
    {
        // Fields
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Lagalt.DTOs.Links
{
    public class LinkCreateDto
    {
        // Fields
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Url)]
        [MaxLength(2083)]
        public string Url { get; set; }
    }
}

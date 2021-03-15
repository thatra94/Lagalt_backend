using System;
using System.ComponentModel.DataAnnotations;

namespace Lagalt.DTOs.UserComments
{
    public class UserCommentCreateDto
    {
        // Fields
        [Required]
        [MaxLength(500)]
        public string Message { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        // Relationships
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
}

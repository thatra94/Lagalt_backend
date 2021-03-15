using System;
using System.ComponentModel.DataAnnotations;

namespace Lagalt.Models
{
    public class UserComment
    {
        // Primary Key
        public int Id { get; set; }
        // Fields
        [Required]
        [MaxLength(500)]
        public string Message { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        // Foreign Keys
        public int UserId { get; set; }
        public int ProjectId { get; set; }

        // Relationships
        public User User { get; set; }
        public Project Project { get; set; }
    }
}

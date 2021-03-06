using Lagalt.Models;
using System;

namespace Lagalt.DTOs.Projects
{
    public class ProjectCommentsDto
    {
        // Primary key
        public int Id { get; set; }
        // Fields
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
 
        // Foreign keys
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.DTOs.UserComments
{
    public class UserCommentDto
    {
        // Primary key
        public int Id { get; set; }
        // Fields
        public string Message { get; set; }
        public DateTime Date { get; set; }
        // Foreign keys
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
}

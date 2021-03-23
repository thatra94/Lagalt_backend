using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.DTOs.UserHistories
{
    public class UserHistoryCreateDto
    {
        public string HistoryType { get; set; } //user-project-click, user-project-seen, user-project-applied

        // Foreign Keys
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
}

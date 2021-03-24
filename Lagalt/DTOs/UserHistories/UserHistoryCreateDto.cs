using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.DTOs.UserHistories
{
    public class UserHistoryCreateDto
    {
        public HistoryType Type { get; set; }
        // Foreign Keys
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
}

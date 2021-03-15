using Lagalt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.DTOs.ProjectApplications
{
    public class ProjectApplicationUserDto
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string MotivationText { get; set; }
    }
}

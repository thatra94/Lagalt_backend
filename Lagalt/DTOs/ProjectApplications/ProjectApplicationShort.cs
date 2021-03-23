using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.DTOs.ProjectApplications
{
    public class ProjectApplicationShort
    {
        public int UserId { get; set; }
        public string MotivationText { get; set; }
        public string Status { get; set; }  //Pending, accepted / declined 
    }
}

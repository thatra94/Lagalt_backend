using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.DTOs.ProjectApplications
{
    public class ProjectApplicationDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }        //Adminstrator / User 
        public string MotivationText { get; set; }
        public string Status { get; set; }  //Pending, accepted / declined 
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.Models
{
    public class ProjectApplication
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        // Navigation property to Project class
        public Project Project { get; set; }
        public int UserId { get; set; }
        // Navigation property to Project class
        public User User { get; set; }
        public string MotivationText { get; set; }
        public string Status { get; set; }  //Pending, accepted / declined 

    }
}

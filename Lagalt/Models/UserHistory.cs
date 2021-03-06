using Lagalt.DTOs.UserHistories;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.Models
{
    public class UserHistory
    {
        // Primary Key
        public int Id { get; set; }
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public  HistoryType TypeHistory{ get; set; } //user-project-click, user-project-seen, user-project-applied
        // Foreign Keys
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        //Relationship 
        public User User { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.Models
{
    public class User
    {
        public int Id { get; set; }
        //Fields
        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        [DataType(DataType.ImageUrl)]
        [MaxLength(2083)]
        public string ImageUrl { get; set; }
    }
}

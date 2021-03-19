using Lagalt.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.DTOs.Portfolio
{
    public class PortfolioCreateDto
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}

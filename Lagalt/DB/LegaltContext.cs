using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.DB
{
    public class LegaltContext : DbContext
    {
        public LegaltContext(DbContextOptions<LegaltContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}

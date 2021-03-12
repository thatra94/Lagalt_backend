using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lagalt.Models;

namespace Lagalt.DB
{
    public class LegaltContext : DbContext
    {
        public LegaltContext(DbContextOptions<LegaltContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
        public DbSet<Lagalt.Models.User> User { get; set; }
    }
}

using Lagalt.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.DB
{
    public class LagaltContext : DbContext
    {
        public LagaltContext(DbContextOptions<LagaltContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserComment> UserComments { get; set; }
        public DbSet<ProjectApplication> ProjectApplications { get; set; }
        public DbSet<Theme> Themes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            // Seed
            modelBuilder.Entity<User>().HasData(Seeder.SeedUsers());
            modelBuilder.Entity<Skill>().HasData(Seeder.SeedSkills());
            modelBuilder.Entity<Project>().HasData(SeederHelper.SeedProjects());
            modelBuilder.Entity<Industry>().HasData(SeederHelper.SeedIndustries());
            modelBuilder.Entity<ProjectApplication>().HasData(Seeder.SeedProjectApplication());

            //Relationship
            modelBuilder.Entity("SkillUser").HasData(new { SkillsId = 1, UsersId = 1 });
            modelBuilder.Entity("SkillUser").HasData(new { SkillsId = 2, UsersId = 1 });
            modelBuilder.Entity("SkillUser").HasData(new { SkillsId = 4, UsersId = 1 });
            modelBuilder.Entity("SkillUser").HasData(new { SkillsId = 5, UsersId = 2 });
            modelBuilder.Entity("SkillUser").HasData(new { SkillsId = 6, UsersId = 2 });
            modelBuilder.Entity("SkillUser").HasData(new { SkillsId = 1, UsersId = 2 });

        }
    }
}

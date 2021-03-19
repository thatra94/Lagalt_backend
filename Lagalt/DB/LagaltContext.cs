﻿using Lagalt.Models;
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
        public DbSet<Link> Links { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            // Seed
            modelBuilder.Entity<User>().HasData(Seeder.SeedUsers());
            modelBuilder.Entity<Skill>().HasData(Seeder.SeedSkills());
            modelBuilder.Entity<Project>().HasData(SeederHelper.SeedProjects());
            modelBuilder.Entity<Industry>().HasData(SeederHelper.SeedIndustries());
            modelBuilder.Entity<ProjectApplication>().HasData(Seeder.SeedProjectApplication());
            modelBuilder.Entity<Theme>().HasData(SeederHelper.SeedThemes());
            modelBuilder.Entity<Portfolio>().HasData(Seeder.SeedPortfolio());
            modelBuilder.Entity<Link>().HasData(SeederHelper.SeedLinks());

            //Relationship
            modelBuilder.Entity("SkillUser").HasData(new { SkillsId = 1, UsersId = 1 });
            modelBuilder.Entity("SkillUser").HasData(new { SkillsId = 2, UsersId = 1 });
            modelBuilder.Entity("SkillUser").HasData(new { SkillsId = 4, UsersId = 1 });
            modelBuilder.Entity("SkillUser").HasData(new { SkillsId = 5, UsersId = 2 });
            modelBuilder.Entity("SkillUser").HasData(new { SkillsId = 6, UsersId = 2 });
            modelBuilder.Entity("SkillUser").HasData(new { SkillsId = 1, UsersId = 2 });

            // Relationships for ProjectUser
            modelBuilder.Entity("ProjectUser").HasData(new { ProjectsId = 1, UsersId = 1 });
            modelBuilder.Entity("ProjectUser").HasData(new { ProjectsId = 1, UsersId = 10 });
            modelBuilder.Entity("ProjectUser").HasData(new { ProjectsId = 1, UsersId = 12 });
            modelBuilder.Entity("ProjectUser").HasData(new { ProjectsId = 2, UsersId = 2 });
            modelBuilder.Entity("ProjectUser").HasData(new { ProjectsId = 2, UsersId = 5 });
            modelBuilder.Entity("ProjectUser").HasData(new { ProjectsId = 2, UsersId = 7 });
            modelBuilder.Entity("ProjectUser").HasData(new { ProjectsId = 3, UsersId = 2 });
            modelBuilder.Entity("ProjectUser").HasData(new { ProjectsId = 4, UsersId = 2 });
            modelBuilder.Entity("ProjectUser").HasData(new { ProjectsId = 5, UsersId = 2 });
            modelBuilder.Entity("ProjectUser").HasData(new { ProjectsId = 6, UsersId = 3 });
            modelBuilder.Entity("ProjectUser").HasData(new { ProjectsId = 7, UsersId = 16 });
            modelBuilder.Entity("ProjectUser").HasData(new { ProjectsId = 7, UsersId = 29 });
            modelBuilder.Entity("ProjectUser").HasData(new { ProjectsId = 8, UsersId = 1 });
            modelBuilder.Entity("ProjectUser").HasData(new { ProjectsId = 9, UsersId = 29 });
            modelBuilder.Entity("ProjectUser").HasData(new { ProjectsId = 9, UsersId = 13 });

            // Relationships for ProjectSkill
            modelBuilder.Entity("ProjectSkill").HasData(new { ProjectsId = 1, SkillsId = 8 });
            modelBuilder.Entity("ProjectSkill").HasData(new { ProjectsId = 1, SkillsId = 11 });
            modelBuilder.Entity("ProjectSkill").HasData(new { ProjectsId = 1, SkillsId = 13 });
            modelBuilder.Entity("ProjectSkill").HasData(new { ProjectsId = 2, SkillsId = 8 });
            modelBuilder.Entity("ProjectSkill").HasData(new { ProjectsId = 2, SkillsId = 18 });
            modelBuilder.Entity("ProjectSkill").HasData(new { ProjectsId = 3, SkillsId = 10 });
            modelBuilder.Entity("ProjectSkill").HasData(new { ProjectsId = 3, SkillsId = 16 });
            modelBuilder.Entity("ProjectSkill").HasData(new { ProjectsId = 4, SkillsId = 1 });
            modelBuilder.Entity("ProjectSkill").HasData(new { ProjectsId = 4, SkillsId = 14 });
            modelBuilder.Entity("ProjectSkill").HasData(new { ProjectsId = 5, SkillsId = 10 });
            modelBuilder.Entity("ProjectSkill").HasData(new { ProjectsId = 5, SkillsId = 11 });
            modelBuilder.Entity("ProjectSkill").HasData(new { ProjectsId = 5, SkillsId = 14 });
            modelBuilder.Entity("ProjectSkill").HasData(new { ProjectsId = 6, SkillsId = 5 });
            modelBuilder.Entity("ProjectSkill").HasData(new { ProjectsId = 6, SkillsId = 19 });
            modelBuilder.Entity("ProjectSkill").HasData(new { ProjectsId = 7, SkillsId = 12 });
            modelBuilder.Entity("ProjectSkill").HasData(new { ProjectsId = 7, SkillsId = 18 });
            modelBuilder.Entity("ProjectSkill").HasData(new { ProjectsId = 8, SkillsId = 20 });
            modelBuilder.Entity("ProjectSkill").HasData(new { ProjectsId = 9, SkillsId = 11 });
            modelBuilder.Entity("ProjectSkill").HasData(new { ProjectsId = 9, SkillsId = 14 });
            modelBuilder.Entity("ProjectSkill").HasData(new { ProjectsId = 10, SkillsId = 21 });

            // Relationships for ProjectThemes
            modelBuilder.Entity("ProjectTheme").HasData(new { ProjectsId = 1, ThemesId = 14 });
            modelBuilder.Entity("ProjectTheme").HasData(new { ProjectsId = 1, ThemesId = 5 });
            modelBuilder.Entity("ProjectTheme").HasData(new { ProjectsId = 2, ThemesId = 15 });
            modelBuilder.Entity("ProjectTheme").HasData(new { ProjectsId = 2, ThemesId = 16 });
            modelBuilder.Entity("ProjectTheme").HasData(new { ProjectsId = 2, ThemesId = 17 });
            modelBuilder.Entity("ProjectTheme").HasData(new { ProjectsId = 3, ThemesId = 7 });
            modelBuilder.Entity("ProjectTheme").HasData(new { ProjectsId = 3, ThemesId = 17 });
            modelBuilder.Entity("ProjectTheme").HasData(new { ProjectsId = 4, ThemesId = 18 });
            modelBuilder.Entity("ProjectTheme").HasData(new { ProjectsId = 4, ThemesId = 19 });
            modelBuilder.Entity("ProjectTheme").HasData(new { ProjectsId = 5, ThemesId = 8 });
            modelBuilder.Entity("ProjectTheme").HasData(new { ProjectsId = 5, ThemesId = 9 });
            modelBuilder.Entity("ProjectTheme").HasData(new { ProjectsId = 5, ThemesId = 13 });
            modelBuilder.Entity("ProjectTheme").HasData(new { ProjectsId = 6, ThemesId = 7});
            modelBuilder.Entity("ProjectTheme").HasData(new { ProjectsId = 6, ThemesId = 20 });
            modelBuilder.Entity("ProjectTheme").HasData(new { ProjectsId = 7, ThemesId = 10 });
            modelBuilder.Entity("ProjectTheme").HasData(new { ProjectsId = 7, ThemesId = 17 });
            modelBuilder.Entity("ProjectTheme").HasData(new { ProjectsId = 8, ThemesId = 1 });
            modelBuilder.Entity("ProjectTheme").HasData(new { ProjectsId = 8, ThemesId = 3 });
            modelBuilder.Entity("ProjectTheme").HasData(new { ProjectsId = 9, ThemesId = 14 });
            modelBuilder.Entity("ProjectTheme").HasData(new { ProjectsId = 9, ThemesId = 21 });
            modelBuilder.Entity("ProjectTheme").HasData(new { ProjectsId = 9, ThemesId = 22 });
            modelBuilder.Entity("ProjectTheme").HasData(new { ProjectsId = 10, ThemesId = 23 });
            modelBuilder.Entity("ProjectTheme").HasData(new { ProjectsId = 10, ThemesId = 14 });
        }
    }
}
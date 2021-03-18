using Lagalt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagalt.DB
{
    public class Seeder
    {
        public static ICollection<Skill> SeedSkills()
        {
            ICollection<Skill> skills = new List<Skill>()
            {
                new Skill{ Id = 1, Name = "WebDeveloper" } ,
                new Skill{ Id = 2,  Name = "Disco Jokey" },
                new Skill{ Id = 3,  Name = "Kommunikator"},
                new Skill {Id = 4, Name = "Problemløser"},
                new Skill {Id = 5, Name = "MovieExpert"},
                new Skill {Id = 6, Name = "AI Tech"},
                new Skill {Id = 7, Name= "Unity"},
                new Skill {Id = 8, Name= "C#"},
                new Skill {Id = 9, Name= "Blender"},
                new Skill {Id = 10, Name= "HTML"},
                new Skill {Id = 11, Name= "CSS"},
                new Skill {Id = 12, Name= "Javascript"},
                new Skill {Id = 13, Name= "React"},
                new Skill {Id = 14, Name= "Angular"},
                new Skill {Id = 15, Name= "Ableton"},
                new Skill {Id = 16, Name= "Java"},
                new Skill {Id = 17, Name= "PHP"},
                new Skill {Id = 18, Name= "Animation"},
            };
            return skills;
        }

        public static ICollection<User> SeedUsers()
        {
            ICollection<User> users = new List<User>()
            {
                new User{ Id = 1,  Name = "Example User", UserId = "example-token", ImageUrl = "https://www.shankarainfra.com/img/avatar.png", 
                Description = "Hei, jeg heter Alias. Jeg liker Bøker "},
                new User{ Id = 2, Name = "Another User", UserId = "another-token", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Gamer til tusen"
                },
                new User{ Id = 3, Name = "Marius Jansen", UserId = "another-token", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Gått på skole i mange år, liker å dra på konsert noen ganger"
                },
                new User{ Id = 4, Name = "Karl Karlsen", UserId = "12ab12ab", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Jeg har en hund og liker å gå på tur"
                }
            };
            return users;
        }

        public static ICollection<Portfolio> SeedPortfolio()
        {
            ICollection<Portfolio> portfolios = new List<Portfolio>()
            {
                new Portfolio
                {
                    Id = 1,
                    Name = "Skole-prosjekt",
                    Link = "https://github.com/thatra94/Lagalt_backend/tree/main/Lagalt",
                    Description = "Når jeg gikk på skolen",
                    UserId = 1
                },
                new Portfolio
                {
                    Id = 2,
                    Name = "Film-prosjekt",
                    Link = "https://www.youtube.com/watch?v=dkZvM1Kq-0s&ab_channel=D4Darious",
                    UserId = 1
                },
                new Portfolio
                {
                    Id = 3,
                    Name = "Hobby prosjekt",
                    Link = "https://github.com/ellerish/FileSystemManager",
                    UserId = 1
                },
                new Portfolio
                {
                    Id = 4,
                    Name = "Musikk prosjekt",
                    Link = "https://www.youtube.com/watch?v=SRcnnId15BA&ab_channel=50CentVEVOr",
                    UserId = 2
                },
                new Portfolio
                {
                    Id = 5,
                    Name = "Musikkvideo",
                    Link = "https://www.youtube.com/watch?v=SRcnnId15BA&ab_channel=50CentVEVOr",
                    UserId = 2
                }
            };
            return portfolios;
        }

        public static ICollection<ProjectApplication> SeedProjectApplication()
        {
            ICollection<ProjectApplication> proApplication = new List<ProjectApplication>()
            {
                new ProjectApplication
                {
                    Id = 1,
                    ProjectId = 1,
                    UserId = 1,
                    MotivationText = "Jeg vil gjerne være med på prosjektet fordi jeg er god",
                    Status = "Pending"
                },
                new ProjectApplication
                {
                    Id = 2,
                    ProjectId = 4,
                    UserId = 3,
                    MotivationText = "Dette er noe for meg, jeg liker sporingssystemer",
                    Status = "Approved"
                },
                new ProjectApplication
                {
                    Id = 3,
                    ProjectId = 2,
                    UserId = 3,
                    MotivationText = "Har lyst til å være med",
                    Status = "Declined"
                }
            };
            return proApplication;
        }
    }
}

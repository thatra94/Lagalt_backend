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
                new Skill {Id = 6, Name = "AI Tech"}

            };
            return skills;
        }

        public static ICollection<User> SeedUsers()
        {
            ICollection<User> users = new List<User>()
            {
                new User{ Id = 1,  Name = "Example User", UserToken = "example-token", ImageUrl = "https://www.shankarainfra.com/img/avatar.png", 
                Description = "Hei, jeg heter Alias. Jeg liker Bøker "},
                new User{ Id = 2, Name = "Another User", UserToken = "another-token", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Gamer til tusen"
                }
            };
            return users;
        }
    }
}

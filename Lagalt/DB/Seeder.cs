using Lagalt.DTOs.UserHistories;
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
                new Skill {Id = 19, Name= "Klipper"},
                new Skill {Id = 20, Name= "Python"},
                new Skill {Id = 21, Name= "Vue"},
            };
            return skills;
        }

        public static ICollection<User> SeedUsers()
        {
            ICollection<User> users = new List<User>()
            {
                new User{ Id = 1,  Name = "Example User", UserId = "example-token", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Hei, jeg heter Alias. Jeg liker Bøker "
                },
                new User{ Id = 2, Name = "Another User", UserId = "another-token", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Gamer til tusen"
                },
                new User{ Id = 3, Name = "Marius Jansen", UserId = "another-token2", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Gått på skole i mange år, liker å dra på konsert noen ganger"
                },
                new User{ Id = 4, Name = "Karl Karlsen", UserId = "12ab12ab", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Jeg har en hund og liker å gå på tur"
                },
                new User{ Id = 5, Name = "Nils", UserId = "another-to", ImageUrl = "https://static.wikia.nocookie.net/motibrostet/images/2/2b/Nils_Svendsen.png/revision/latest?cb=20151231015619",
                    Description = "Jeg liker bannan og laban"
                },
                new User{ Id = 6, Name = "Karl Reverud", UserId = "anotheb", ImageUrl = "https://static.wikia.nocookie.net/motibrostet/images/8/87/Karl_Reverud.png/revision/latest/scale-to-width-down/340?cb=20200223142852",
                    Description = "Jeg er sjef i C-konsult og liker å pusle med kreative prosjekter på fritiden"
                },
                new User{ Id = 7, Name = "Henry", UserId = "another-token3", ImageUrl = "https://1.bp.blogspot.com/-9qzG44d0m30/XfO_Fu_b8NI/AAAAAAAAmu4/OUNLse_hN2sUkeHzxoRWYWmUvn6OqnWWQCLcBGAsYHQ/s1600/48992181_2368337909903300_2220834138863173632_o.jpg",
                    Description = "Jeg er en pensjonist som er glad i likkør"
                },
                new User{ Id = 8, Name = "John", UserId = "another-token4", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Har master innen IT"
                },
                new User{ Id = 9, Name = "Bjarte", UserId = "another-token5", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Jeg er en ux-designer med 5 års erfaring"
                },
                new User{ Id = 10, Name = "Anne", UserId = "another-token6", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Har IT-utdannelse og erfaring innenfor spillutvikling"
                },
                new User{ Id = 11, Name = "Oda", UserId = "another-token7", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Har IT-utdannelse og erfaring 5 års erfaring innenfor webutvikling"
                },
                new User{ Id = 12, Name = "Tom", UserId = "another-token8", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Liker å gå fjelltur. Har to katter"
                },
                new User{ Id = 13, Name = "Madeleine Olaussen", UserId = "another-token9", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Liker å lese og programmere"
                },
                new User{ Id = 14, Name = "Kaare Nordvik", UserId = "another-token10", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Har utdannelse innenfor IT og liker å gå fjelltur"
                },
                new User{ Id = 15, Name = "Anna Bjørgum", UserId = "another-token11", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Er youtuber og liker å gå tur"
                },
                new User{ Id = 16, Name = "Christine Haaland", UserId = "another-token12", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Har erfaring innenfor spillutvikling"
                },
                new User{ Id = 17, Name = "Daniel Engen", UserId = "another-token13", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Epic gamer og elsker programmering"
                },
                new User{ Id = 18, Name = "Odin Karlsen", UserId = "another-token14", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Driver med programmering som hobby. Liker å gå tur"
                },
                new User{ Id = 19, Name = "Merete Olsen", UserId = "another-token15", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Liker å bade"
                },
                new User{ Id = 20, Name = "Astrid Larsen", UserId = "another-token16", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Liker å jobbe med blender og animasjon"
                },
                new User{ Id = 21, Name = "Thomas Bjørdal", UserId = "another-token17", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Er soundcloud-artist og har jobbet mye med ableton"
                },
                new User{ Id = 22, Name = "Jan Johansen", UserId = "another-token18", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Har gått filmskole i lillehammer og har jobbet må mindre produksjoner"
                },
                new User{ Id = 23, Name = "Susanne Rønne", UserId = "another-token19", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Har utdannelse innen foto. Liker å gå i skogen"
                },
                new User{ Id = 24, Name = "Dorthe Kristensen", UserId = "another-token20", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Elsker å jobbe med unity og 3d-spill. Epic gamer på fritiden"
                },
                new User{ Id = 25, Name = "Henrik Jørgensen", UserId = "another-token21", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "l33t gamer og har 2 katter"
                },
                new User{ Id = 26, Name = "Hanne Nilsen", UserId = "another-token22", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Liker å jobbe med react"
                },
                new User{ Id = 27, Name = "Maja Øvrebø", UserId = "another-token23", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Liker å jobbe med .NET og databaser"
                },
                new User{ Id = 28, Name = "Hedda", UserId = "another-token24", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Har 20 års erfaring i filmbransjen"
                },
                new User{ Id = 29, Name = "Martin Fosshaug", UserId = "another-token25", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Liker å jobbe med spillutvikling"
                },
                new User{ Id = 30, Name = "Geir Torvik", UserId = "another-token26", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Jobber til daglig med musikkproduksjon. Liker også å programmere"
                },
                new User{ Id = 31, Name = "Eivind Magnussen", UserId = "another-token28", ImageUrl = "https://www.shankarainfra.com/img/avatar.png",
                    Description = "Har bachelorgrad i IT fra OsloMet"
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
                    UserId = 2
                },
                new Portfolio
                {
                    Id = 4,
                    Name = "Musikk prosjekt",
                    Link = "https://www.youtube.com/watch?v=SRcnnId15BA&ab_channel=50CentVEVOr",
                    UserId = 3

                },
                new Portfolio
                {
                    Id = 5,
                    Name = "Musikkvideo",
                    Link = "https://www.youtube.com/watch?v=SRcnnId15BA&ab_channel=50CentVEVOr",
                    UserId = 4
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
                },
                new ProjectApplication
                {
                    Id = 4,
                    ProjectId = 1,
                    UserId = 4,
                    MotivationText = "Jeg har passende skills",
                    Status = "Pending"
                }
            };
            return proApplication;
        }

        public static ICollection<UserHistory> SeedUserHistory()
        {
            ICollection<UserHistory> uh = new List<UserHistory>()
            {//user-project-click, user-project-seen, user-project-applied
                new UserHistory
                {
                    Id = 1,
                    TypeHistory = HistoryType.ProjectClickedOn,
                    UserId = 1,
                    ProjectId = 1
                },
                   new UserHistory
                {
                    Id = 2,
                    TypeHistory = HistoryType.ProjectContributed,
                    UserId = 1,
                    ProjectId = 1
                },
                   new UserHistory
                {
                    Id = 3,
                    TypeHistory =  HistoryType.ProjectClickedOn,
                    UserId = 1,
                    ProjectId = 2
                },
                   new UserHistory
                {
                    Id = 4,
                    TypeHistory = HistoryType.ProjectAppliedTo,
                    UserId = 1,
                    ProjectId = 3
                },
                   new UserHistory
                {
                    Id = 5,
                    TypeHistory = HistoryType.ProjectSeenFromMain,
                    UserId = 1,
                    ProjectId = 2
                },
                   new UserHistory
                {
                    Id = 6,
                    TypeHistory =  HistoryType.ProjectSeenFromMain,
                    UserId = 1,
                    ProjectId = 7
                }
            };
            return uh;
        }
    }
}

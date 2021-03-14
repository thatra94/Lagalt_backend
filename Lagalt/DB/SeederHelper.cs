using Lagalt.Models;
using System.Collections.Generic;

namespace Lagalt.DB
{
    public class SeederHelper
    {
        public static ICollection<Project> SeedProjects()
        {
            ICollection<Project> projects = new List<Project>()
            {
                new Project
                {
                    Id = 1,
                    Name = "Lagalt",
                    Description = "Webapplikasjon hvor man opprette prosjekter og finne prosjektmedlemmer",
                    ImageUrl = "https://external-preview.redd.it/iDdntscPf-nfWKqzHRGFmhVxZm4hZgaKe5oyFws-yzA.png?auto=webp&s=38648ef0dc2c3fce76d5e1d8639234d8da0152b2",
                    Status = "Under utvikling",
                    IndustryId = 1

                },
                new Project
                {
                    Id = 2,
                    Name = "Valheim",
                    Description = "Sandkassespill satt til vikingtiden. Litt som minecraft",
                    ImageUrl = "https://img.gfx.no/2652/2652343/ss_758a730d41536d195249fe87b81ea26400c6b56e.956x539.png",
                    Status = "Opprettet",
                    IndustryId = 3
                },
                new Project
                {
                    Id = 3,
                    Name = "The Sentinel",
                    Description = "Er et space exploration spill satt i nær fremtid",
                    ImageUrl = "https://res.cloudinary.com/jerrick/image/upload/fl_progressive,q_auto,w_1024/d4mmmwmkthezbqmwtvxy.jpg",
                    Status = "Opprettet",
                    IndustryId = 3
                },
                new Project
                {
                    Id = 4,
                    Name = "Buggy",
                    Description = "Et sporingssystem for programvarefeil. Holder orden på rapporte programvarefeil i et uviklingsprosjekt.",
                    ImageUrl = "https://res.cloudinary.com/jerrick/image/upload/fl_progressive,q_auto,w_1024/d4mmmwmkthezbqmwtvxy.jpg",
                    Status = "På vent",
                    IndustryId = 1
                },
                new Project
                {
                    Id = 5,
                    Name = "Fronter 2.0",
                    Description = "Alles favorittplattform skal pusses opp!",
                    ImageUrl = "https://wiki.usn.no/ewiki/images/a/a8/Fronter.jpg",
                    Status = "Under utvikling",
                    IndustryId = 1
                },
                new Project
                {
                    Id = 6,
                    Name = "2061",
                    Description = "Spillefilm satt til 2061. Sjangeren er sci-fi. Trenger fotografer, set-designere, og kostymedesignere",
                    ImageUrl = "https://cdn.pixabay.com/photo/2019/10/08/14/24/futuristic-4535174_960_720.jpg",
                    Status = "Ferdig",
                    IndustryId = 4
                },
                new Project
                {
                    Id = 7,
                    Name = "UnderRail",
                    Description = "Turbasert rollespill satt i en dystopisk fremtid",
                    ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/250520/header.jpg?t=1588072489",
                    Status = "Under utvikling",
                    IndustryId = 3
                },
                new Project
                {
                    Id = 8,
                    Name = "Deep Sky Derelicts",
                    Description = "Turbasert strategispill og RPG",
                    ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/698640/header.jpg?t=1613491211",
                    Status = "Under utvikling",
                    IndustryId = 3

                }
            };
            return projects;
        }

        public static ICollection<Industry> SeedIndustries()
        {
            ICollection<Industry> industries = new List<Industry>()
            {
                new Industry
                {
                    Id = 1,
                    Name = "Webutvikling"
                },
                new Industry
                {
                    Id = 2,
                    Name = "Musikk"
                },
                new Industry
                {
                    Id = 3,
                    Name = "Spillutvikling"
                },
                new Industry
                {
                    Id = 4,
                    Name = "Film"
                },
                new Industry
                {
                    Id = 5,
                    Name = "Animasjon"
                },
                new Industry
                {
                    Id = 6,
                    Name = "Foto"
                }
            };
            return industries;
        }
 
    }
}


/*
Id, Name, Description, ImageUrl, Status  // ("Founding", "In progress", "Stalled", and "Completed"), IndustryId 
                                             "Opprettet", "Under utvikling", "Stoppet", "Ferdig"
*/


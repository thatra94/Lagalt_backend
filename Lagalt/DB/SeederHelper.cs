using Lagalt.Models;
using System;
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
                    Name = "Kreativt Forum",
                    Description = "Webapplikasjon hvor man opprette prosjekter og finne prosjektmedlemmer",
                    ImageUrl = "https://external-preview.redd.it/iDdntscPf-nfWKqzHRGFmhVxZm4hZgaKe5oyFws-yzA.png?auto=webp&s=38648ef0dc2c3fce76d5e1d8639234d8da0152b2",
                    Status = "Under utvikling",
                    IndustryId = 1,
                    UserId = 2
                },
                new Project
                {
                    Id = 2,
                    Name = "Valheim",
                    Description = "Sandkassespill satt til vikingtiden. Litt som minecraft",
                    ImageUrl = "https://img.gfx.no/2652/2652343/ss_758a730d41536d195249fe87b81ea26400c6b56e.956x539.png",
                    Status = "Opprettet",
                    IndustryId = 3,
                    UserId = 6
                },
                new Project
                {
                    Id = 3,
                    Name = "The Sentinel",
                    Description = "Er et space exploration spill satt i nær fremtid",
                    ImageUrl = "https://res.cloudinary.com/jerrick/image/upload/fl_progressive,q_auto,w_1024/d4mmmwmkthezbqmwtvxy.jpg",
                    Status = "Opprettet",
                    IndustryId = 3,
                    UserId = 10
                },
                new Project
                {
                    Id = 4,
                    Name = "Buggy",
                    Description = "Et sporingssystem for programvarefeil. Holder orden på rapporte programvarefeil i et uviklingsprosjekt.",
                    ImageUrl = "https://thumbs.dreamstime.com/b/cartoon-bug-29199888.jpg",
                    Status = "På vent",
                    IndustryId = 1,
                    UserId = 3
                },
                new Project
                {
                    Id = 5,
                    Name = "Fronter 2.0",
                    Description = "Alles favorittplattform skal pusses opp!",
                    ImageUrl = "https://wiki.usn.no/ewiki/images/a/a8/Fronter.jpg",
                    Status = "Under utvikling",
                    IndustryId = 1,
                    UserId = 20
                },
                new Project
                {
                    Id = 6,
                    Name = "2061",
                    Description = "Spillefilm satt til 2061. Sjangeren er sci-fi. Trenger fotografer, set-designere, og kostymedesignere",
                    ImageUrl = "https://cdn.pixabay.com/photo/2019/10/08/14/24/futuristic-4535174_960_720.jpg",
                    Status = "Ferdig",
                    IndustryId = 4,
                    UserId = 11
                },
                new Project
                {
                    Id = 7,
                    Name = "UnderRail",
                    Description = "Turbasert rollespill satt i en dystopisk fremtid",
                    ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/250520/header.jpg?t=1588072489",
                    Status = "Under utvikling",
                    IndustryId = 3,
                    UserId = 5
                },
                new Project
                {
                    Id = 8,
                    Name = "Deep Sky Derelicts",
                    Description = "Turbasert strategispill og RPG",
                    ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/698640/header.jpg?t=1613491211",
                    Status = "Under utvikling",
                    IndustryId = 3,
                    UserId = 6
                },
                new Project
                {
                    Id = 9,
                    Name = "Ebaums Verden",
                    Description = "Nettside som skal inneholde morsomme videoer og bilder",
                    ImageUrl = "https://pbs.twimg.com/profile_images/3467586385/2d15c551d729114e3646434ea7a09a46_400x400.png",
                    Status = "Opprettet",
                    IndustryId = 1,
                    UserId = 15

                },
                new Project
                {
                    Id = 10,
                    Name = "Bokklubben",
                    Description = "Nettside for bokinteresserte. For diskusjon og anbefalinger av bøker",
                    ImageUrl = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/old-books-arranged-on-shelf-royalty-free-image-1572384534.jpg",
                    Status = "Under utvikling",
                    IndustryId = 1,
                    UserId = 4
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

        public static ICollection<Theme> SeedThemes()
        {
            ICollection<Theme> themes = new List<Theme>()
            {
                new Theme
                {
                    Id = 1,
                    Name = "RPG"
                },
                new Theme
                {
                    Id = 2,
                    Name = "Action"
                },
                new Theme
                {
                    Id = 3,
                    Name = "Strategy"
                },
                new Theme
                {
                    Id = 4,
                    Name = "Roguelike"
                },
                new Theme
                {
                    Id = 5,
                    Name = "Creativity"
                },
                new Theme
                {
                    Id = 6,
                    Name = "3D"
                },
                new Theme
                {
                    Id = 7,
                    Name = "Sci-fi"
                },
                new Theme
                {
                    Id = 8,
                    Name = "Læringsplattform"
                },
                new Theme
                {
                    Id = 9,
                    Name = "LMS"
                },
                new Theme
                {
                    Id = 10,
                    Name = "Dystopisk"
                },
                new Theme
                {
                    Id = 11,
                    Name = "kostymedesign"
                },
                new Theme
                {
                    Id = 12,
                    Name = "Eventyr"
                },
                new Theme
                {
                    Id = 13,
                    Name = "Utdanning"
                },
                new Theme
                {
                    Id = 14,
                    Name = "Web"
                },
                new Theme
                {
                    Id = 15,
                    Name = "Sandkassespill"
                },
                new Theme
                {
                    Id = 16,
                    Name = "Vikingtid"
                },
                new Theme
                {
                    Id = 17,
                    Name = "Overlevelsesspill"
                },
                new Theme
                {
                    Id = 18,
                    Name = "Utvikling"
                },
                new Theme
                {
                    Id = 19,
                    Name = "PMS"
                },
                new Theme
                {
                    Id = 20,
                    Name = "Filmproduksjon"
                },
                new Theme
                {
                    Id = 21,
                    Name = "Humor"
                },
                new Theme
                {
                    Id = 22,
                    Name = "Memes"
                },
                new Theme
                {
                    Id = 23,
                    Name = "Bøker"
                }

            };

            return themes;
        }

        public static ICollection<Link> SeedLinks()
        {
            ICollection<Link> links = new List<Link>()
            {
                new Link
                {
                    Id = 1,
                    Name = "Kreativt forum",
                    Url = "https://www.github.com/kreativt-forum",
                    ProjectId = 1
                },
                new Link
                {
                    Id = 2,
                    Name = "Github",
                    Url = "https://www.github.com/valheim",
                    ProjectId = 2
                },
                new Link
                {
                    Id = 3,
                    Name = "Hjemmeside",
                    Url = "https://www.valheim.no",
                    ProjectId = 2
                },
                new Link
                {
                    Id = 4,
                    Name = "Sentinel hjemmeside",
                    Url = "https://www.sentinel.net",
                    ProjectId = 3
                },
                new Link
                {
                    Id = 5,
                    Name = "Githubside",
                    Url = "https://www.github.com/buggy",
                    ProjectId = 4
                },
                new Link
                {
                    Id = 6,
                    Name = "Hjemmeside",
                    Url = "https://www.Fronter.no",
                    ProjectId = 5
                },
                new Link
                {
                    Id = 7,
                    Name = "Vår hjemmeside",
                    Url = "https://www.twentysixtone.no",
                    ProjectId = 6
                },
                new Link
                {
                    Id = 8,
                    Name = "Projektside",
                    Url = "https://www.github.com/underrail",
                    ProjectId = 7
                },
                new Link
                {
                    Id = 9,
                    Name = "Hjemmeside",
                    Url = "https://www.deepderelict.com",
                    ProjectId = 8
                },
                new Link
                {
                    Id = 10,
                    Name = "Hjemmeside",
                    Url = "https://www.ebaumbsverden.no",
                    ProjectId = 9
                },
                new Link
                {
                    Id = 11,
                    Name = "Prosjekctside",
                    Url = "https://www.github.com/bokklubben",
                    ProjectId = 10
                },
            };

            return links;
        }

        public static ICollection<UserComment> SeedUserComments()
        {
            ICollection<UserComment> comments = new List<UserComment>()
            {
                new UserComment
                {
                    Id = 1,
                    Message = "Heyy!! Dette er en testmelding :))))",
                    Date = new DateTime(2021, 03, 22, 15, 40, 0),
                    UserId = 10,
                    ProjectId = 1
                },
                new UserComment
                {
                    Id = 2,
                    Message = "Jeg er ikke helt sikker på hva dette kommentarfeltet skal brukes til hehe",
                    Date = new DateTime(2021, 03, 22, 16, 10, 0),
                    UserId = 1,
                    ProjectId = 1
                },
                new UserComment
                {
                    Id = 3,
                    Message = "Ikke jeg heller",
                    UserId = 12,
                    Date = new DateTime(2021, 03, 22, 16, 15, 0),
                    ProjectId = 1
                },
                new UserComment
                {
                    Id = 4,
                    Message = "Når er oppstarten?",
                    UserId = 5,
                    Date = new DateTime(2021, 02, 14, 10, 00, 0),
                    ProjectId = 2
                },
                new UserComment
                {
                    Id = 5,
                    Message = "Dunno!",
                    Date = new DateTime(2021, 02, 14, 10, 20, 0),
                    UserId = 7,
                    ProjectId = 2
                }
            };

            return comments;
        }
    }
}
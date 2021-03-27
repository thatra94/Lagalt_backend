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
                },
                new Project
                {
                    Id = 11,
                    Name = "After hours: Remix album",
                    Description = "Projektet går ut på å lage et remix album av After Hours",
                    ImageUrl = "https://dbdzm869oupei.cloudfront.net/img/vinylrugs/preview/18784.png",
                    Status = "Under utvikling",
                    IndustryId = 2,
                    UserId = 30
                },
                new Project
                {
                    Id = 12,
                    Name = "Samlealbum elektronisk musikk",
                    Description = "Ønsker å samle artister til å lage et album",
                    ImageUrl = "https://dt7v1i9vyp3mf.cloudfront.net/styles/news_large/s3/imagelibrary/m/moog_one_sound-P087eHzg49waKAA2MV2WqvZgTkf_dZkN.jpg",
                    Status = "Opprettet",
                    IndustryId = 2,
                    UserId = 4
                },
                new Project
                {
                    Id = 13,
                    Name = "Gutten og snømannen",
                    Description = "Tegnefilm om en liten gutt og snømannen hans",
                    ImageUrl = "https://filmklubb.no/wp/wp-content/uploads/2012/11/guttenogsnomannen-630x340.jpg",
                    Status = "Opprettet",
                    IndustryId = 5,
                    UserId = 4
                },
                new Project
                {
                    Id = 14,
                    Name = "Woodys magiske jul",
                    Description = "Animasjonsfilm om woody i jula",
                    ImageUrl = "https://lumiere-a.akamaihd.net/v1/images/open-uri20150422-20810-10n7ovy_9b42e613.jpeg?region=0,0,450,450",
                    Status = "På Vent",
                    IndustryId = 5,
                    UserId = 4
                },
                new Project
                {
                    Id = 15,
                    Name = "Livet på bøgda",
                    Description = "Samler bilder fra utkant-norge for å lage fotobok",
                    ImageUrl = "https://p3.no/wp-content/uploads/2020/03/15_stor_16x9.jpg",
                    Status = "Opprettet",
                    IndustryId = 6,
                    UserId = 4
                },
                new Project
                {
                    Id = 16,
                    Name = "Fuglefoto",
                    Description = "Fotoprojekt for fuglefoto",
                    ImageUrl = "https://www.adressa.no/incoming/article14114726.ece/a3zoi/BINARY/w980/tba3b37a.jpg",
                    Status = "Ferdig",
                    IndustryId = 6,
                    UserId = 4
                },
                new Project
                {
                    Id = 17,
                    Name = "Kortfilm",
                    Description = "Projektet går ut på å lage en kortfilm",
                    ImageUrl = "http://www.filmfront.no/gfx/kortfilm.jpg",
                    Status = "Opprettet",
                    IndustryId = 4,
                    UserId = 4
                },
                new Project
                {
                    Id = 18,
                    Name = "Mattespill",
                    Description = "Projektet lage en webapplikasjon som er et mattespill",
                    ImageUrl = "https://thumbs-prod.si-cdn.com/dE1WGJFS_iPeyEEHa5bf2bWc1hg=/fit-in/1600x0/filters:focal(1295x777:1296x778)/https://public-media.si-cdn.com/filer/87/ee/87ee6918-7808-4e18-b3f9-d3c3db54e873/gettyimages-157686793_web.jpg",
                    Status = "Opprettet",
                    IndustryId = 3,
                    UserId = 6
                },
                new Project
                {
                    Id = 19,
                    Name = "Nettbutikk klær",
                    Description = "Projektet lage en webapplikasjon som skal fungere som en nettbutikk for ulike merker",
                    ImageUrl = "https://cdn.sanity.io/images/pq0o4uqt/production/ce9bb0f62dc4197ee239a2ce64174038a6125537-4032x3024.jpg?rect=0,378,4032,2268&w=1200&h=675&fit=crop",
                    Status = "På Vent",
                    IndustryId = 1,
                    UserId = 10
                },
                new Project
                {
                    Id = 20,
                    Name = "Cities Skylines",
                    Description = "Simslignende spill",
                    ImageUrl = "https://store-images.s-microsoft.com/image/apps.41325.14005705415125511.f2721de4-9cb5-4d00-9323-bd9afe457b1f.5c04c69a-a73b-486d-9a91-06980efc972b?mode=scale&q=90&h=1080&w=1920&format=jpg",
                    Status = "Opprettet",
                    IndustryId = 3,
                    UserId = 15
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
                },
                new Theme
                {
                    Id = 24,
                    Name = "Musikkproduksjon"
                },
                new Theme
                {
                    Id = 25,
                    Name = "Synth"
                },
                new Theme
                {
                    Id = 26,
                    Name = "Animasjon"
                },
                new Theme
                {
                    Id = 27,
                    Name = "Tegnefilm"
                },
                new Theme
                {
                    Id = 28,
                    Name = "Jul"
                },
                new Theme
                {
                    Id = 29,
                    Name = "Utkant-Norge"
                },
                new Theme
                {
                    Id = 30,
                    Name = "Råning"
                },
                new Theme
                {
                    Id = 31,
                    Name = "Foto"
                },
                new Theme
                {
                    Id = 32,
                    Name = "Fugler"
                },
                new Theme
                {
                    Id = 33,
                    Name = "Kortfilm"
                },
                new Theme
                {
                    Id = 34,
                    Name = "Matte"
                },
                new Theme
                {
                    Id = 35,
                    Name = "Nettbutikk"
                },
                new Theme
                {
                    Id = 36,
                    Name = "Klær"
                },
                new Theme
                {
                    Id = 37,
                    Name = "City builder"
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
using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lagalt.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IndustryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portfolios_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillUser",
                columns: table => new
                {
                    SkillsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillUser", x => new { x.SkillsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_SkillUser_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MotivationText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectApplications_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectApplications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSkill",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSkill", x => new { x.ProjectsId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_ProjectSkill_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTheme",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(type: "int", nullable: false),
                    ThemesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTheme", x => new { x.ProjectsId, x.ThemesId });
                    table.ForeignKey(
                        name: "FK_ProjectTheme_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTheme_Themes_ThemesId",
                        column: x => x.ThemesId,
                        principalTable: "Themes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectUser",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUser", x => new { x.ProjectsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ProjectUser_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserComments_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserComments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Webutvikling" },
                    { 2, "Musikk" },
                    { 3, "Spillutvikling" },
                    { 4, "Film" },
                    { 5, "Animasjon" },
                    { 6, "Foto" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 21, "Vue" },
                    { 20, "Python" },
                    { 19, "Klipper" },
                    { 18, "Animation" },
                    { 17, "PHP" },
                    { 16, "Java" },
                    { 15, "Ableton" },
                    { 14, "Angular" },
                    { 12, "Javascript" },
                    { 11, "CSS" },
                    { 13, "React" },
                    { 9, "Blender" },
                    { 8, "C#" },
                    { 7, "Unity" },
                    { 6, "AI Tech" },
                    { 5, "MovieExpert" },
                    { 4, "Problemløser" },
                    { 3, "Kommunikator" },
                    { 2, "Disco Jokey" },
                    { 1, "WebDeveloper" },
                    { 10, "HTML" }
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 15, "Sandkassespill" },
                    { 16, "Vikingtid" },
                    { 17, "Overlevelsesspill" },
                    { 18, "Utvikling" },
                    { 23, "Bøker" },
                    { 20, "Filmproduksjon" },
                    { 21, "Humor" },
                    { 22, "Memes" },
                    { 13, "Utdanning" },
                    { 19, "PMS" },
                    { 12, "Eventyr" },
                    { 14, "Web" },
                    { 10, "Dystopisk" },
                    { 9, "LMS" },
                    { 8, "Læringsplattform" }
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "Sci-fi" },
                    { 6, "3D" },
                    { 5, "Creativity" },
                    { 4, "Roguelike" },
                    { 3, "Strategy" },
                    { 2, "Action" },
                    { 1, "RPG" },
                    { 11, "kostymedesign" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "UserId" },
                values: new object[,]
                {
                    { 18, "Driver med programmering som hobby. Liker å gå tur", "https://www.shankarainfra.com/img/avatar.png", "Odin Karlsen", "another-token14" },
                    { 19, "Liker å bade", "https://www.shankarainfra.com/img/avatar.png", "Merete Olsen", "another-token15" },
                    { 20, "Liker å jobbe med blender og animasjon", "https://www.shankarainfra.com/img/avatar.png", "Astrid Larsen", "another-token16" },
                    { 21, "Er soundcloud-artist og har jobbet mye med ableton", "https://www.shankarainfra.com/img/avatar.png", "Thomas Bjørdal", "another-token17" },
                    { 22, "Har gått filmskole i lillehammer og har jobbet må mindre produksjoner", "https://www.shankarainfra.com/img/avatar.png", "Jan Johansen", "another-token18" },
                    { 27, "Liker å jobbe med .NET og databaser", "https://www.shankarainfra.com/img/avatar.png", "Maja Øvrebø", "another-token23" },
                    { 24, "Elsker å jobbe med unity og 3d-spill. Epic gamer på fritiden", "https://www.shankarainfra.com/img/avatar.png", "Dorthe Kristensen", "another-token20" },
                    { 25, "l33t gamer og har 2 katter", "https://www.shankarainfra.com/img/avatar.png", "Henrik Jørgensen", "another-token21" },
                    { 26, "Liker å jobbe med react", "https://www.shankarainfra.com/img/avatar.png", "Hanne Nilsen", "another-token22" },
                    { 17, "Epic gamer og elsker programmering", "https://www.shankarainfra.com/img/avatar.png", "Daniel Engen", "another-token13" },
                    { 28, "Har 20 års erfaring i filmbransjen", "https://www.shankarainfra.com/img/avatar.png", "Hedda", "another-token24" },
                    { 29, "Liker å jobbe med spillutvikling", "https://www.shankarainfra.com/img/avatar.png", "Martin Fosshaug", "another-token25" },
                    { 23, "Har utdannelse innen foto. Liker å gå i skogen", "https://www.shankarainfra.com/img/avatar.png", "Susanne Rønne", "another-token19" },
                    { 16, "Har erfaring innenfor spillutvikling", "https://www.shankarainfra.com/img/avatar.png", "Christine Haaland", "another-token12" },
                    { 10, "Har IT-utdannelse og erfaring innenfor spillutvikling", "https://www.shankarainfra.com/img/avatar.png", "Anne", "another-token6" },
                    { 14, "Har utdannelse innenfor IT og liker å gå fjelltur", "https://www.shankarainfra.com/img/avatar.png", "Kaare Nordvik", "another-token10" },
                    { 13, "Liker å lese og programmere", "https://www.shankarainfra.com/img/avatar.png", "Madeleine Olaussen", "another-token9" },
                    { 12, "Liker å gå fjelltur. Har to katter", "https://www.shankarainfra.com/img/avatar.png", "Tom", "another-token8" },
                    { 11, "Har IT-utdannelse og erfaring 5 års erfaring innenfor webutvikling", "https://www.shankarainfra.com/img/avatar.png", "Oda", "another-token7" },
                    { 9, "Jeg er en ux-designer med 5 års erfaring", "https://www.shankarainfra.com/img/avatar.png", "Bjarte", "another-token5" },
                    { 8, "Har master innen IT", "https://www.shankarainfra.com/img/avatar.png", "John", "another-token4" },
                    { 7, "Jeg er en pensjonist som er glad i likkør", "https://1.bp.blogspot.com/-9qzG44d0m30/XfO_Fu_b8NI/AAAAAAAAmu4/OUNLse_hN2sUkeHzxoRWYWmUvn6OqnWWQCLcBGAsYHQ/s1600/48992181_2368337909903300_2220834138863173632_o.jpg", "Henry", "another-token3" },
                    { 6, "Jeg er sjef i C-konsult og liker å pusle med kreative prosjekter på fritiden", "https://static.wikia.nocookie.net/motibrostet/images/8/87/Karl_Reverud.png/revision/latest/scale-to-width-down/340?cb=20200223142852", "Karl Reverud", "another-token2" },
                    { 5, "Jeg liker bannan og laban", "https://static.wikia.nocookie.net/motibrostet/images/2/2b/Nils_Svendsen.png/revision/latest?cb=20151231015619", "Nils", "another-token1" },
                    { 4, "Jeg har en hund og liker å gå på tur", "https://www.shankarainfra.com/img/avatar.png", "Karl Karlsen", "12ab12ab" },
                    { 3, "Gått på skole i mange år, liker å dra på konsert noen ganger", "https://www.shankarainfra.com/img/avatar.png", "Marius Jansen", "another-token" },
                    { 2, "Gamer til tusen", "https://www.shankarainfra.com/img/avatar.png", "Another User", "another-token" },
                    { 1, "Hei, jeg heter Alias. Jeg liker Bøker ", "https://www.shankarainfra.com/img/avatar.png", "Example User", "example-token" },
                    { 30, "Jobber til daglig med musikkproduksjon. Liker også å programmere", "https://www.shankarainfra.com/img/avatar.png", "Geir Torvik", "another-token26" },
                    { 15, "Er youtuber og liker å gå tur", "https://www.shankarainfra.com/img/avatar.png", "Anna Bjørgum", "another-token11" },
                    { 31, "Har bachelorgrad i IT fra OsloMet", "https://www.shankarainfra.com/img/avatar.png", "Eivind Magnussen", "another-token28" }
                });

            migrationBuilder.InsertData(
                table: "Portfolios",
                columns: new[] { "Id", "Description", "Link", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Når jeg gikk på skolen", "https://github.com/thatra94/Lagalt_backend/tree/main/Lagalt", "Skole-prosjekt", 1 },
                    { 5, null, "https://www.youtube.com/watch?v=SRcnnId15BA&ab_channel=50CentVEVOr", "Musikkvideo", 2 },
                    { 4, null, "https://www.youtube.com/watch?v=SRcnnId15BA&ab_channel=50CentVEVOr", "Musikk prosjekt", 2 },
                    { 3, null, "https://github.com/ellerish/FileSystemManager", "Hobby prosjekt", 1 },
                    { 2, null, "https://www.youtube.com/watch?v=dkZvM1Kq-0s&ab_channel=D4Darious", "Film-prosjekt", 1 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "ImageUrl", "IndustryId", "Name", "Status", "UserId" },
                values: new object[,]
                {
                    { 6, "Spillefilm satt til 2061. Sjangeren er sci-fi. Trenger fotografer, set-designere, og kostymedesignere", "https://cdn.pixabay.com/photo/2019/10/08/14/24/futuristic-4535174_960_720.jpg", 4, "2061", "Ferdig", 11 },
                    { 8, "Turbasert strategispill og RPG", "https://cdn.akamai.steamstatic.com/steam/apps/698640/header.jpg?t=1613491211", 3, "Deep Sky Derelicts", "Under utvikling", 6 },
                    { 1, "Webapplikasjon hvor man opprette prosjekter og finne prosjektmedlemmer", "https://external-preview.redd.it/iDdntscPf-nfWKqzHRGFmhVxZm4hZgaKe5oyFws-yzA.png?auto=webp&s=38648ef0dc2c3fce76d5e1d8639234d8da0152b2", 1, "Kreativt Forum", "Under utvikling", 2 },
                    { 3, "Er et space exploration spill satt i nær fremtid", "https://res.cloudinary.com/jerrick/image/upload/fl_progressive,q_auto,w_1024/d4mmmwmkthezbqmwtvxy.jpg", 3, "The Sentinel", "Opprettet", 10 },
                    { 2, "Sandkassespill satt til vikingtiden. Litt som minecraft", "https://img.gfx.no/2652/2652343/ss_758a730d41536d195249fe87b81ea26400c6b56e.956x539.png", 3, "Valheim", "Opprettet", 6 },
                    { 10, "Nettside for bokinteresserte. For diskusjon og anbefalinger av bøker", "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/old-books-arranged-on-shelf-royalty-free-image-1572384534.jpg", 1, "Bokklubben", "Under utvikling", 4 },
                    { 9, "Nettside som skal inneholde morsomme videoer og bilder", "https://pbs.twimg.com/profile_images/3467586385/2d15c551d729114e3646434ea7a09a46_400x400.png", 1, "Ebaums Verden", "Opprettet", 15 },
                    { 5, "Alles favorittplattform skal pusses opp!", "https://wiki.usn.no/ewiki/images/a/a8/Fronter.jpg", 1, "Fronter 2.0", "Under utvikling", 20 },
                    { 4, "Et sporingssystem for programvarefeil. Holder orden på rapporte programvarefeil i et uviklingsprosjekt.", "https://thumbs.dreamstime.com/b/cartoon-bug-29199888.jpg", 1, "Buggy", "På vent", 3 },
                    { 7, "Turbasert rollespill satt i en dystopisk fremtid", "https://cdn.akamai.steamstatic.com/steam/apps/250520/header.jpg?t=1588072489", 3, "UnderRail", "Under utvikling", 5 }
                });

            migrationBuilder.InsertData(
                table: "SkillUser",
                columns: new[] { "SkillsId", "UsersId" },
                values: new object[,]
                {
                    { 6, 2 },
                    { 1, 1 },
                    { 2, 1 },
                    { 4, 1 },
                    { 5, 2 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "Name", "ProjectId", "Url" },
                values: new object[,]
                {
                    { 1, "Kreativt forum", 1, "https://www.github.com/kreativt-forum" },
                    { 8, "Projektside", 7, "https://www.github.com/underrail" },
                    { 3, "Hjemmeside", 2, "https://www.valheim.no" },
                    { 2, "Github", 2, "https://www.github.com/valheim" },
                    { 10, "Hjemmeside", 9, "https://www.ebaumbsverden.no" },
                    { 11, "Prosjekctside", 10, "https://www.github.com/bokklubben" },
                    { 4, "Sentinel hjemmeside", 3, "https://www.sentinel.net" },
                    { 7, "Vår hjemmeside", 6, "https://www.twentysixtone.no" },
                    { 5, "Githubside", 4, "https://www.github.com/buggy" },
                    { 6, "Hjemmeside", 5, "https://www.Fronter.no" },
                    { 9, "Hjemmeside", 8, "https://www.deepderelict.com" }
                });

            migrationBuilder.InsertData(
                table: "ProjectApplications",
                columns: new[] { "Id", "MotivationText", "ProjectId", "Status", "UserId" },
                values: new object[,]
                {
                    { 2, "Dette er noe for meg, jeg liker sporingssystemer", 4, "Approved", 3 },
                    { 3, "Har lyst til å være med", 2, "Declined", 3 },
                    { 1, "Jeg vil gjerne være med på prosjektet fordi jeg er god", 1, "Pending", 1 }
                });

            migrationBuilder.InsertData(
                table: "ProjectSkill",
                columns: new[] { "ProjectsId", "SkillsId" },
                values: new object[,]
                {
                    { 3, 10 },
                    { 10, 21 },
                    { 9, 11 },
                    { 2, 18 },
                    { 7, 12 },
                    { 5, 14 },
                    { 9, 14 },
                    { 3, 16 },
                    { 5, 10 },
                    { 7, 18 },
                    { 6, 19 },
                    { 6, 5 },
                    { 1, 8 },
                    { 1, 11 },
                    { 5, 11 },
                    { 8, 20 },
                    { 1, 13 },
                    { 4, 14 },
                    { 4, 1 },
                    { 2, 8 }
                });

            migrationBuilder.InsertData(
                table: "ProjectTheme",
                columns: new[] { "ProjectsId", "ThemesId" },
                values: new object[,]
                {
                    { 8, 1 },
                    { 8, 3 },
                    { 2, 17 },
                    { 2, 16 },
                    { 3, 7 },
                    { 3, 17 },
                    { 2, 15 },
                    { 7, 17 }
                });

            migrationBuilder.InsertData(
                table: "ProjectTheme",
                columns: new[] { "ProjectsId", "ThemesId" },
                values: new object[,]
                {
                    { 7, 10 },
                    { 6, 7 },
                    { 10, 23 },
                    { 5, 8 },
                    { 5, 9 },
                    { 5, 13 },
                    { 9, 14 },
                    { 9, 21 },
                    { 4, 18 },
                    { 9, 22 },
                    { 1, 5 },
                    { 1, 14 },
                    { 6, 20 },
                    { 10, 14 },
                    { 4, 19 }
                });

            migrationBuilder.InsertData(
                table: "ProjectUser",
                columns: new[] { "ProjectsId", "UsersId" },
                values: new object[,]
                {
                    { 1, 10 },
                    { 8, 1 },
                    { 1, 12 },
                    { 7, 29 },
                    { 7, 16 },
                    { 1, 1 },
                    { 6, 3 },
                    { 3, 2 },
                    { 5, 2 },
                    { 2, 7 },
                    { 2, 5 },
                    { 2, 2 },
                    { 9, 29 },
                    { 9, 13 },
                    { 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "UserComments",
                columns: new[] { "Id", "Date", "Message", "ProjectId", "UserId" },
                values: new object[,]
                {
                    { 5, new DateTime(2021, 2, 14, 10, 20, 0, 0, DateTimeKind.Unspecified), "Dunno!", 2, 7 },
                    { 3, new DateTime(2021, 3, 22, 16, 15, 0, 0, DateTimeKind.Unspecified), "Ikke jeg heller", 1, 12 },
                    { 2, new DateTime(2021, 3, 22, 16, 10, 0, 0, DateTimeKind.Unspecified), "Jeg er ikke helt sikker på hva dette kommentarfeltet skal brukes til hehe", 1, 1 },
                    { 1, new DateTime(2021, 3, 22, 15, 40, 0, 0, DateTimeKind.Unspecified), "Heyy!! Dette er en testmelding :))))", 1, 10 },
                    { 4, new DateTime(2021, 2, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), "Når er oppstarten?", 2, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_ProjectId",
                table: "Links",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_UserId",
                table: "Portfolios",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectApplications_ProjectId",
                table: "ProjectApplications",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectApplications_UserId",
                table: "ProjectApplications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_IndustryId",
                table: "Projects",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkill_SkillsId",
                table: "ProjectSkill",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTheme_ThemesId",
                table: "ProjectTheme",
                column: "ThemesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_UsersId",
                table: "ProjectUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillUser_UsersId",
                table: "SkillUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_ProjectId",
                table: "UserComments",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_UserId",
                table: "UserComments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "ProjectApplications");

            migrationBuilder.DropTable(
                name: "ProjectSkill");

            migrationBuilder.DropTable(
                name: "ProjectTheme");

            migrationBuilder.DropTable(
                name: "ProjectUser");

            migrationBuilder.DropTable(
                name: "SkillUser");

            migrationBuilder.DropTable(
                name: "UserComments");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Industries");
        }
    }
}

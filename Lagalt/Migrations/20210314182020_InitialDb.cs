using Microsoft.EntityFrameworkCore.Migrations;

namespace Lagalt.Migrations
{
    public partial class InitialDb : Migration
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: true)
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
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IndustryId = table.Column<int>(type: "int", nullable: false)
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
                table: "Projects",
                columns: new[] { "Id", "Description", "ImageUrl", "IndustryId", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "Webapplikasjon hvor man opprette prosjekter og finne prosjektmedlemmer", "https://external-preview.redd.it/iDdntscPf-nfWKqzHRGFmhVxZm4hZgaKe5oyFws-yzA.png?auto=webp&s=38648ef0dc2c3fce76d5e1d8639234d8da0152b2", 1, "Lagalt", "Under utvikling" },
                    { 4, "Et sporingssystem for programvarefeil. Holder orden på rapporte programvarefeil i et uviklingsprosjekt.", "https://res.cloudinary.com/jerrick/image/upload/fl_progressive,q_auto,w_1024/d4mmmwmkthezbqmwtvxy.jpg", 1, "Buggy", "På vent" },
                    { 5, "Alles favorittplattform skal pusses opp!", "https://wiki.usn.no/ewiki/images/a/a8/Fronter.jpg", 1, "Fronter 2.0", "Under utvikling" },
                    { 2, "Sandkassespill satt til vikingtiden. Litt som minecraft", "https://img.gfx.no/2652/2652343/ss_758a730d41536d195249fe87b81ea26400c6b56e.956x539.png", 3, "Valheim", "Opprettet" },
                    { 3, "Er et space exploration spill satt i nær fremtid", "https://res.cloudinary.com/jerrick/image/upload/fl_progressive,q_auto,w_1024/d4mmmwmkthezbqmwtvxy.jpg", 3, "The Sentinel", "Opprettet" },
                    { 7, "Turbasert rollespill satt i en dystopisk fremtid", "https://cdn.akamai.steamstatic.com/steam/apps/250520/header.jpg?t=1588072489", 3, "UnderRail", "Under utvikling" },
                    { 8, "Turbasert strategispill og RPG", "https://cdn.akamai.steamstatic.com/steam/apps/698640/header.jpg?t=1613491211", 3, "Deep Sky Derelicts", "Under utvikling" },
                    { 6, "Spillefilm satt til 2061. Sjangeren er sci-fi. Trenger fotografer, set-designere, og kostymedesignere", "https://cdn.pixabay.com/photo/2019/10/08/14/24/futuristic-4535174_960_720.jpg", 4, "2061", "Ferdig" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_IndustryId",
                table: "Projects",
                column: "IndustryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Industries");
        }
    }
}

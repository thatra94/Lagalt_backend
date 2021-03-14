﻿// <auto-generated />
using Lagalt.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lagalt.Migrations
{
    [DbContext(typeof(LagaltContext))]
    partial class LagaltContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lagalt.Models.Industry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Industries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Webutvikling"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Musikk"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Spillutvikling"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Film"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Animasjon"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Foto"
                        });
                });

            modelBuilder.Entity("Lagalt.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(2083)
                        .HasColumnType("nvarchar(2083)");

                    b.Property<int>("IndustryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("IndustryId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Webapplikasjon hvor man opprette prosjekter og finne prosjektmedlemmer",
                            ImageUrl = "https://external-preview.redd.it/iDdntscPf-nfWKqzHRGFmhVxZm4hZgaKe5oyFws-yzA.png?auto=webp&s=38648ef0dc2c3fce76d5e1d8639234d8da0152b2",
                            IndustryId = 1,
                            Name = "Lagalt",
                            Status = "Under utvikling"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Sandkassespill satt til vikingtiden. Litt som minecraft",
                            ImageUrl = "https://img.gfx.no/2652/2652343/ss_758a730d41536d195249fe87b81ea26400c6b56e.956x539.png",
                            IndustryId = 3,
                            Name = "Valheim",
                            Status = "Opprettet"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Er et space exploration spill satt i nær fremtid",
                            ImageUrl = "https://res.cloudinary.com/jerrick/image/upload/fl_progressive,q_auto,w_1024/d4mmmwmkthezbqmwtvxy.jpg",
                            IndustryId = 3,
                            Name = "The Sentinel",
                            Status = "Opprettet"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Et sporingssystem for programvarefeil. Holder orden på rapporte programvarefeil i et uviklingsprosjekt.",
                            ImageUrl = "https://res.cloudinary.com/jerrick/image/upload/fl_progressive,q_auto,w_1024/d4mmmwmkthezbqmwtvxy.jpg",
                            IndustryId = 1,
                            Name = "Buggy",
                            Status = "På vent"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Alles favorittplattform skal pusses opp!",
                            ImageUrl = "https://wiki.usn.no/ewiki/images/a/a8/Fronter.jpg",
                            IndustryId = 1,
                            Name = "Fronter 2.0",
                            Status = "Under utvikling"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Spillefilm satt til 2061. Sjangeren er sci-fi. Trenger fotografer, set-designere, og kostymedesignere",
                            ImageUrl = "https://cdn.pixabay.com/photo/2019/10/08/14/24/futuristic-4535174_960_720.jpg",
                            IndustryId = 4,
                            Name = "2061",
                            Status = "Ferdig"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Turbasert rollespill satt i en dystopisk fremtid",
                            ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/250520/header.jpg?t=1588072489",
                            IndustryId = 3,
                            Name = "UnderRail",
                            Status = "Under utvikling"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Turbasert strategispill og RPG",
                            ImageUrl = "https://cdn.akamai.steamstatic.com/steam/apps/698640/header.jpg?t=1613491211",
                            IndustryId = 3,
                            Name = "Deep Sky Derelicts",
                            Status = "Under utvikling"
                        });
                });

            modelBuilder.Entity("Lagalt.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(2083)
                        .HasColumnType("nvarchar(2083)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Lagalt.Models.Project", b =>
                {
                    b.HasOne("Lagalt.Models.Industry", "Industry")
                        .WithMany("Projects")
                        .HasForeignKey("IndustryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Industry");
                });

            modelBuilder.Entity("Lagalt.Models.Industry", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}

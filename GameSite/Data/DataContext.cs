using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameSite.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameSite.Data
{
    public class DataContext: IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ConsoleUnit> Consoles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            const string ADMIN_ID = "b4280b6a-0613-4cbd-a9e6-f1701e926e73";
            const string ROLE_ID = ADMIN_ID;
            const string password = "Admin123@";

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ROLE_ID,
                    Name = "admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "b4280b6a-0613-4cbd-a9e6-f1701e926e75",
                    Name = "guest",
                    NormalizedName = "GUEST"
                }
            );

            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "admin@gamestore.com",
                NormalizedUserName = "ADMIN@GAMESTORE.COM",
                Email = "admin@gamestore.com",
                NormalizedEmail = "ADMIN@GAMESTORE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, password),
                SecurityStamp = string.Empty,
                ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc58"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    GenreId = 1,
                    GenreName = "Action",
                    GenreDescription = "Action games emphasize physical challenges that require hand-eye coordination and motor skill to overcome. " +
                    "They center around the player, who is in control of most of the action. Most of the earliest video games were " +
                    "considered action games;" +
                    "today, it is still a vast genre covering all games that involve physical challenges. "
                },
                new Genre
                {
                    GenreId = 2,
                    GenreName = "Adventure",
                    GenreDescription = "Adventure games were some of the earliest games created, beginning with the text adventure " +
                    "Colossal Cave Adventure in the 1970s. " +
                    "That game was originally titled simply 'Adventure'," +
                    " and is the namesake of the genre. Over time, graphics have been introduced to the genre and the interface has evolved. "
                },
                new Genre
                {
                    GenreId = 3,
                    GenreName = "Role-playing",
                    GenreDescription = "Role-playing video games draw their gameplay from traditional tabletop role-playing games like " +
                    "Dungeons & Dragons." +
                    "Most of these games cast the player in the role of a weak character that grows in strength and experience over the course" +
                    " of the game."
                },
                new Genre
                {
                    GenreId = 4,
                    GenreName = "Simulation",
                    GenreDescription = "Simulation video games is a diverse super-category of games, " +
                    "generally designed to closely simulate aspects of a real or fictional reality."
                },
                new Genre
                {
                    GenreId = 5,
                    GenreName = "Strategy",
                    GenreDescription = "Strategy video games focus on gameplay requiring careful and skillful" +
                    "thinking and planning in order to achieve victory and the action scales from world domination to squad-based tactics. "
                },
                new Genre
                {
                    GenreId = 6,
                    GenreName = "Sports",
                    GenreDescription = "Sports are video games that simulate sports." +
                    "This opposing team(s) can be controlled by other real life people or artificial intelligence."
                },
                new Genre
                {
                    GenreId = 7,
                    GenreName = "Sandbox",
                    GenreDescription = "Sandbox and open-world games are not specifically video game genres," +
                    "as they generally describe gameplay features, but often games will be described as a sandbox or an open-world game as if it were a defining genre." +
                    "They are included here for such distinguishing purposes. "
                },
                new Genre
                {
                    GenreId = 8,
                    GenreName = "Horror",
                    GenreDescription = "IHorror games are games that incorporate elements of horror fiction into their narrative," +
                    "generally irrespective of the type of gameplay." +
                    "It is the only major video game genre that is recognized by narrative elements rather than by gameplay," +
                    "gameplay mode, or platform. Survival horror is a subgenre of horror games focused on action-adventure style of gameplay."
                },
                new Genre
                {
                    GenreId = 9,
                    GenreName = "MMO",
                    GenreDescription = "A massively multiplayer online game (also called MMO and MMOG) is a multiplayer online video game which is " +
                    "capable of supporting large numbers of players simultaneously. By necessity, they are played on the Internet."
                }
            );

            modelBuilder.Entity<ConsoleUnit>().HasData(
               new ConsoleUnit
               {
                   ConsoleId = 1,
                   ConsoleName = "Playstation",
                   Description = "PlayStation (Japanese: プレイステーション, Hepburn: Pureisutēshon, officially abbreviated as PS) is a " +
                   "Japanese video game brand that consists of five home video game consoles, as well as a media center, an online service, " +
                   "a line of controllers, two handhelds and a phone, as well as multiple magazines. The brand is produced by Sony Interactive Entertainment," +
                   "a division of Sony; the first PlayStation console was released in Japan in December 1994, and worldwide the following year.",
                   IsItOnPc = false
               },
               new ConsoleUnit
               {
                   ConsoleId = 2,
                   ConsoleName = "XBOX",
                   Description = "Xbox is a video gaming brand created and owned by Microsoft. The brand consists of five video game consoles," +
                   "as well as applications (games), streaming services, an online service by the name of Xbox Live," +
                   "and the development arm by the name of Xbox Game Studios. The brand was first introduced in the United States in November 2001," +
                   "with the launch of the original Xbox console. ",
                   IsItOnPc = false
               },
               new ConsoleUnit
               {
                   ConsoleId = 3,
                   ConsoleName = "Nintendo",
                   Description = "Nintendo Co., Ltd. is a Japanese multinational consumer electronics and video game company headquartered in Kyoto." +
                   "The company was founded in 1889 as Nintendo Karuta[c] by craftsman Fusajiro Yamauchi and originally produced handmade hanafuda playing" +
                   "cards. After venturing into various lines of business during the 1960s and acquiring a legal status as a public company under the current" +
                   "company name, Nintendo distributed its first video game console, the Color TV-Game, in 1977. It gained international recognition with the" +
                   "release of the Nintendo Entertainment System in 1985. ",
                   IsItOnPc = false
               },
               new ConsoleUnit
               {
                   ConsoleId = 4,
                   ConsoleName = "Personal Computer",
                   Description = "A personal computer (PC) is a multi-purpose computer whose size, capabilities, and price make it feasible for individual use." +
                   "Personal computers are intended to be operated directly by an end user, rather than by a computer expert or technician. Unlike large," +
                   " costly minicomputers and mainframes, time-sharing by many people at the same time is not used with personal computers. ",
                   IsItOnPc = true
               },
               new ConsoleUnit
               {
                   ConsoleId = 5,
                   ConsoleName = "Atari",
                   Description = "Atari (/əˈtɑːri/) is a brand name owned by several entities since its inception in 1972, currently by Atari Interactive," +
                   "a subsidiary of the French publisher Atari, SA. The original Atari, Inc., founded in Sunnyvale, California in 1972 by Nolan Bushnell and" +
                   "Ted Dabney, was a pioneer in arcade games, home video game consoles, and home computers. The company's products," +
                   "such as Pong and the Atari 2600, helped define the electronic entertainment industry from the 1970s to the mid-1980s.",
                   IsItOnPc = false
               },
               new ConsoleUnit
               {
                   ConsoleId = 6,
                   ConsoleName = "SEGA",
                   Description = "Sega Corporation[a] is a Japanese multinational video game developer and publisher headquartered in Shinagawa, Tokyo." +
                   "Its international branches, Sega of America and Sega Europe, are respectively headquartered in Irvine, California, and London." +
                   "Sega's arcade division existed as Sega Interactive Co., Ltd. from 2015 to 2020 before it merged with Sega Games to create" +
                   "Sega Corporation with Sega Games as the surviving entity. Sega is a subsidiary of Sega Group Corporation, which is, in turn," +
                   "a part of Sega Sammy Holdings. From 1983 until 2002, Sega also developed video game consoles. ",
                   IsItOnPc = false
               }
           );

            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    GameId = 1,
                    GameName = "Skyrim",
                    GameCreator = "Bethesda",
                    Description = "The Elder Scrolls V: Skyrim is an open world action role-playing video game developed by Bethesda Game Studios and published by" +
                    " Bethesda Softworks.",
                    GenreId = 3,
                    GenreName = "Role-playing",
                    ConsoleId = 4,
                    ConsoleName = "Personal Computer",
                    IsOnSale = true,
                    IsInStock = true,
                    Price = 9.99,
                    PhotoPath = "Skyrim.png"
                },
                new Game
                {
                    GameId = 2,
                    GameName = "Witcher 3: Game of The Year Edition",
                    GameCreator = "City Project Red",
                    Description = "The Witcher 3: Wild Hunt is a 2015 action role-playing game developed and published by Polish developer CD Projekt Red and is based" +
                    " on The Witcher series of fantasy novels written by Andrzej Sapkowski.",
                    GenreId = 3,
                    GenreName = "Role-playing",
                    ConsoleId = 4,
                    ConsoleName = "Personal Computer",
                    IsOnSale = true,
                    IsInStock = false,
                    Price = 19.99,
                    PhotoPath = "Witcher3.jpg"
                },
                new Game
                {
                    GameId = 3,
                    GameName = "Bloodborne",
                    GameCreator = "FromSoftware",
                    Description = "Bloodborne is an action role-playing game developed by FromSoftware and published by Sony Computer Entertainment," +
                    "which released for the PlayStation 4 in March 2015.",
                    GenreId = 1,
                    GenreName = "Action",
                    ConsoleId = 1,
                    ConsoleName = "Playstation",
                    IsOnSale = true,
                    IsInStock = true,
                    Price = 19.99,
                    PhotoPath = "Bloodborne.jpg"
                }
            );

            base.OnModelCreating(modelBuilder);


            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }
    }
}

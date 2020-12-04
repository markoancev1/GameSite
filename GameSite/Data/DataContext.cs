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
                },
                 new Genre
                 {
                     GenreId = 10,
                     GenreName = "Platforming",
                     GenreDescription = "Platform games (often simplified as platformer, or jump 'n' run) is a video game genre and subgenre of action games. " +
                     "Platformers are characterized by their heavy use of jumping and climbing to navigate the player's environment and reach their goal." +
                     " Levels and environments tend to feature uneven terrain and suspended platforms of varying height that requires use of the player " +
                     "character's abilities in order to traverse."
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
                    GameName = "Witcher 3: GOTY",
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
                    GameName = "Bloodborne: GOTY",
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
                },
                new Game
                {
                    GameId = 4,
                    GameName = "God of War 2018",
                    GameCreator = "SIE Santa Monica Studio",
                    Description = "God of War is an action-adventure game developed by Santa Monica Studio and published by Sony Interactive Entertainment (SIE)." +
                    "Released on April 20, 2018, for the PlayStation 4 (PS4), it is the eighth installment in the God of War series," +
                    "and the sequel to 2010's God of War III. Unlike previous games, which were loosely based on Greek mythology, " +
                    "this installment is rooted in Norse mythology, with the majority of it set in ancient Norway in the realm of Midgard." +
                    " For the first time in the series, there are two protagonists: Kratos, the former Greek God of War who remains the only playable character," +
                    " and his young son Atreus. Following the death of Kratos' second wife and Atreus' mother, " +
                    "they journey to fulfill her request that her ashes be spread at the highest peak of the nine realms. " +
                    "Kratos keeps his troubled past a secret from Atreus, who is unaware of his divine nature. Along their journey, " +
                    "they encounter monsters and gods of the Norse world. ",
                    GenreId = 2,
                    GenreName = "Adventure",
                    ConsoleId = 1,
                    ConsoleName = "Playstation",
                    IsOnSale = false,
                    IsInStock = false,
                    Price = 14.99,
                    PhotoPath = "GodOfWar.jpg"
                },
                new Game
                {
                    GameId = 5,
                    GameName = "Spider-Man: GOTY",
                    GameCreator = "Insomniac",
                    Description = "God of War is an action-adventure game developed by Santa Monica Studio and published by Sony Interactive Entertainment (SIE)." +
                    "Released on April 20, 2018, for the PlayStation 4 (PS4), it is the eighth installment in the God of War series," +
                    "and the sequel to 2010's God of War III. Unlike previous games, which were loosely based on Greek mythology, " +
                    "this installment is rooted in Norse mythology, with the majority of it set in ancient Norway in the realm of Midgard." +
                    " For the first time in the series, there are two protagonists: Kratos, the former Greek God of War who remains the only playable character," +
                    " and his young son Atreus. Following the death of Kratos' second wife and Atreus' mother, " +
                    "they journey to fulfill her request that her ashes be spread at the highest peak of the nine realms. " +
                    "Kratos keeps his troubled past a secret from Atreus, who is unaware of his divine nature. Along their journey, " +
                    "they encounter monsters and gods of the Norse world. ",
                    GenreId = 2,
                    GenreName = "Adventure",
                    ConsoleId = 1,
                    ConsoleName = "Playstation",
                    IsOnSale = true,
                    IsInStock = true,
                    Price = 24.99,
                    PhotoPath = "Spider-Man.jpg"
                },
                new Game
                {
                    GameId = 6,
                    GameName = "Ghost of Tsushima",
                    GameCreator = "Sucker Punch Productions",
                    Description = "Ghost of Tsushima is a 2020 action-adventure game developed by Sucker Punch Productions and published by" +
                    "Sony Interactive Entertainment. Featuring an open world, it follows Jin Sakai, a samurai on a quest to protect " +
                    "Tsushima Island during the first Mongol invasion of Japan. The game was released on July 17, 2020 for PlayStation 4." +
                    " Ghost of Tsushima received praise for its visuals and combat but was criticized for its open world activities. ",
                    GenreId = 3,
                    GenreName = "Role-playing",
                    ConsoleId = 1,
                    ConsoleName = "Playstation",
                    IsOnSale = true,
                    IsInStock = true,
                    Price = 34.99,
                    PhotoPath = "GhostOfTsushima.webp"
                },
                new Game
                {
                    GameId = 7,
                    GameName = "Cuphead",
                    GameCreator = "	Studio MDHR",
                    Description = "Cuphead is a 2017 run and gun video game developed and published by Studio MDHR. " +
                    "The game was inspired by the rubber hose style of animation used in cartoons of the 1930s, such as the work of" +
                    " Fleischer Studios and Walt Disney Animation Studios, and sought to emulate their subversive and surrealist qualities. ",
                    GenreId = 10,
                    GenreName = "Platforming",
                    ConsoleId = 2,
                    ConsoleName = "XBOX",
                    IsOnSale = true,
                    IsInStock = true,
                    Price = 4.99,
                    PhotoPath = "Cuphead.jpg"
                },
                new Game
                {
                    GameId = 8,
                    GameName = "Forza Horizon 4",
                    GameCreator = "Playground Games",
                    Description = "Forza Horizon 4 is a 2018 racing video game developed by Playground Games and published by Microsoft Studios." +
                    " It was released on 2 October 2018 on Xbox One and Microsoft Windows after being announced at Xbox's E3 2018 conference." +
                    "An enhanced version of the game was released on Xbox Series X/S on 10 November 2020. " +
                    "The game is set in a fictionalised representation of areas of Great Britain." +
                    "It is the fourth Forza Horizon title and eleventh instalment in the Forza series. " +
                    "The game is noted for its introduction of changing seasons to the series.  ",
                    GenreId = 6,
                    GenreName = "Sports",
                    ConsoleId = 2,
                    ConsoleName = "XBOX",
                    IsOnSale = false,
                    IsInStock = false,
                    Price = 24.99,
                    PhotoPath = "Forza.jpg"
                },
                 new Game
                 {
                     GameId = 9,
                     GameName = "Halo: The Master Chief Collection",
                     GameCreator = "343 Industries",
                     Description = "Halo: The Master Chief Collection is a compilation of first-person shooter video games in the Halo series, " +
                     "originally released in November 2014 for the Xbox One, and later on Microsoft Windows through 2019 and 2020. " +
                     "The enhanced version was released for the Xbox Series X|S in November 2020. " +
                     "The collection was developed by 343 Industries in partnership with other studios and was published by Xbox Game Studios." +
                     " The collection consists of Halo: Combat Evolved Anniversary, Halo 2: Anniversary, Halo 3, Halo 3: ODST, Halo: Reach, and Halo 4, " +
                     "which were originally released on earlier Xbox platforms. ",
                     GenreId = 1,
                     GenreName = "Action",
                     ConsoleId = 2,
                     ConsoleName = "XBOX",
                     IsOnSale = true,
                     IsInStock = true,
                     Price = 34.99,
                     PhotoPath = "Halo.jpg"
                 },
                 new Game
                 {
                     GameId = 10,
                     GameName = "Sea of Thieves",
                     GameCreator = "Rare",
                     Description = "Sea of Thieves is a 2018 action-adventure game developed by Rare and published by Xbox Game Studios. " +
                     "The player assumes the role of a pirate who completes voyages from different trading companies in order to become the ultimate pirate legend." +
                     " Sea of Thieves is a first-person multiplayer video game in which players cooperate with each other to explore an open world via a pirate ship." +
                     " The game is described as a 'shared world adventure game', which means groups of players will encounter each other regularly during " +
                     "their adventures, sometimes forming alliances, sometimes going head-to-head. ",
                     GenreId = 2,
                     GenreName = "Adventure",
                     ConsoleId = 2,
                     ConsoleName = "XBOX",
                     IsOnSale = false,
                     IsInStock = false,
                     Price = 44.99,
                     PhotoPath = "SeaOfThieves.jpg"
                 },
                 new Game
                 {
                     GameId = 11,
                     GameName = "Euro Truck Simulator 2",
                     GameCreator = "SCS Software",
                     Description = "Euro Truck Simulator 2 is a truck simulator game developed and published by SCS Software for Microsoft Windows, Linux," +
                     " and macOS and was initially released as open development on 19 October 2012. The game is a direct sequel to the 2008 game " +
                     "Euro Truck Simulator and it is the second video game in the Truck Simulator series." +
                     " The basic premise of the game is that the player can drive one of a choice of articulated trucks across a condensed depiction of Europe," +
                     " picking up cargo from various locations and delivering it. As the game progresses," +
                     " it is possible for the player to buy more vehicles and depots, as well as hire other drivers to work for them. ",
                     GenreId = 4,
                     GenreName = "Simulation",
                     ConsoleId = 4,
                     ConsoleName = "Personal Computer",
                     IsOnSale = true,
                     IsInStock = true,
                     Price = 9.99,
                     PhotoPath = "ETS2.jpg"
                 }, new Game
                 {
                     GameId = 12,
                     GameName = "Outlast 2",
                     GameCreator = "Red Barrels",
                     Description = "Outlast 2 (stylized as OU⸸LASTII) is a first-person psychological horror survival video game developed and published by " +
                     "Red Barrels. It is the sequel to the 2013 video game Outlast, and features a journalist named Blake Langermann, along with his wife Lynn," +
                     " roaming the Arizona desert to explore the murder of a pregnant woman only known as Jane Doe." +
                     " Blake and Lynn get separated in a helicopter crash, and Blake has to find his wife while traveling through a village inhabited by a " +
                     "sderanged sect that believes the end of days are upon them. ",
                     GenreId = 8,
                     GenreName = "Horror",
                     ConsoleId = 4,
                     ConsoleName = "Personal Computer",
                     IsOnSale = true,
                     IsInStock = false,
                     Price = 19.99,
                     PhotoPath = "outlast2.jpg"
                 }, new Game
                 {
                     GameId = 13,
                     GameName = "Super Mario Odyssey",
                     GameCreator = "Nintendo EPD",
                     Description = "Super Mario Odyssey is a platform game developed and published by Nintendo for the Nintendo Switch on October 27, 2017. " +
                     "An entry in the Super Mario series, it follows Mario and Cappy, a sentient hat that allows Mario to control other characters and objects, " +
                     "as they journey across various worlds to save Princess Peach from his nemesis Bowser, who plans to forcibly marry her." +
                     " In contrast to the linear gameplay of prior entries, the game returns to the primarily open-ended, " +
                     "3D platform gameplay featured in Super Mario 64 and Super Mario Sunshine.",
                     GenreId = 10,
                     GenreName = "Platforming",
                     ConsoleId = 3,
                     ConsoleName = "Nintendo",
                     IsOnSale = true,
                     IsInStock = true,
                     Price = 19.99,
                     PhotoPath = "Mario.jpg"
                 }, new Game
                 {
                     GameId = 14,
                     GameName = "The Legend of Zelda: Breath of the Wild",
                     GameCreator = "Nintendo EPD",
                     Description = "The Legend of Zelda: Breath of the Wild is a 2017 action-adventure game developed and published by Nintendo for the" +
                     " Nintendo Switch and Wii U consoles. Breath of the Wild is part of the Legend of Zelda franchise and is set at the end of the Zelda timeline;" +
                     " the player controls Link, who awakens from a hundred-year slumber to defeat Calamity Ganon and save the kingdom of Hyrule. ",
                     GenreId = 3,
                     GenreName = "Role-playing",
                     ConsoleId = 3,
                     ConsoleName = "Nintendo",
                     IsOnSale = true,
                     IsInStock = false,
                     Price = 29.99,
                     PhotoPath = "Zelda.jpg"
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

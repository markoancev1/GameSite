using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameSite.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consoles",
                columns: table => new
                {
                    ConsoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsoleName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsItOnPc = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consoles", x => x.ConsoleId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(nullable: true),
                    GenreDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: false),
                    State = table.Column<string>(maxLength: 10, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 25, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    OrderPlaced = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    GenreId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(nullable: true),
                    GameCreator = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: true),
                    IsOnSale = table.Column<bool>(nullable: false),
                    IsInStock = table.Column<bool>(nullable: false),
                    GenreId = table.Column<int>(nullable: false),
                    GenreName = table.Column<string>(nullable: true),
                    ConsoleId = table.Column<int>(nullable: false),
                    ConsoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_Consoles_ConsoleId",
                        column: x => x.ConsoleId,
                        principalTable: "Consoles",
                        principalColumn: "ConsoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", "c45e3593-07df-4b47-a7d8-fcf2f5d5b607", "admin", "ADMIN" },
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e75", "f23faf9c-c5ef-49d6-adc6-e2d6c86249a6", "guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", 0, "c8554266-b401-4519-9aeb-a9283053fc58", "admin@gamestore.com", true, false, null, "ADMIN@GAMESTORE.COM", "ADMIN@GAMESTORE.COM", "AQAAAAEAACcQAAAAEOelw7OD696QwJ36AOqNiEJdrlCRzC0TuSmkCxr42TwbekA67RHxij2oWNJrUJr72w==", null, false, "", false, "admin@gamestore.com" });

            migrationBuilder.InsertData(
                table: "Consoles",
                columns: new[] { "ConsoleId", "ConsoleName", "Description", "IsItOnPc" },
                values: new object[,]
                {
                    { 6, "SEGA", "Sega Corporation[a] is a Japanese multinational video game developer and publisher headquartered in Shinagawa, Tokyo.Its international branches, Sega of America and Sega Europe, are respectively headquartered in Irvine, California, and London.Sega's arcade division existed as Sega Interactive Co., Ltd. from 2015 to 2020 before it merged with Sega Games to createSega Corporation with Sega Games as the surviving entity. Sega is a subsidiary of Sega Group Corporation, which is, in turn,a part of Sega Sammy Holdings. From 1983 until 2002, Sega also developed video game consoles. ", false },
                    { 1, "Playstation", "PlayStation (Japanese: プレイステーション, Hepburn: Pureisutēshon, officially abbreviated as PS) is a Japanese video game brand that consists of five home video game consoles, as well as a media center, an online service, a line of controllers, two handhelds and a phone, as well as multiple magazines. The brand is produced by Sony Interactive Entertainment,a division of Sony; the first PlayStation console was released in Japan in December 1994, and worldwide the following year.", false },
                    { 4, "Personal Computer", "A personal computer (PC) is a multi-purpose computer whose size, capabilities, and price make it feasible for individual use.Personal computers are intended to be operated directly by an end user, rather than by a computer expert or technician. Unlike large, costly minicomputers and mainframes, time-sharing by many people at the same time is not used with personal computers. ", true },
                    { 3, "Nintendo", "Nintendo Co., Ltd. is a Japanese multinational consumer electronics and video game company headquartered in Kyoto.The company was founded in 1889 as Nintendo Karuta[c] by craftsman Fusajiro Yamauchi and originally produced handmade hanafuda playingcards. After venturing into various lines of business during the 1960s and acquiring a legal status as a public company under the currentcompany name, Nintendo distributed its first video game console, the Color TV-Game, in 1977. It gained international recognition with therelease of the Nintendo Entertainment System in 1985. ", false },
                    { 2, "XBOX", "Xbox is a video gaming brand created and owned by Microsoft. The brand consists of five video game consoles,as well as applications (games), streaming services, an online service by the name of Xbox Live,and the development arm by the name of Xbox Game Studios. The brand was first introduced in the United States in November 2001,with the launch of the original Xbox console. ", false },
                    { 5, "Atari", "Atari (/əˈtɑːri/) is a brand name owned by several entities since its inception in 1972, currently by Atari Interactive,a subsidiary of the French publisher Atari, SA. The original Atari, Inc., founded in Sunnyvale, California in 1972 by Nolan Bushnell andTed Dabney, was a pioneer in arcade games, home video game consoles, and home computers. The company's products,such as Pong and the Atari 2600, helped define the electronic entertainment industry from the 1970s to the mid-1980s.", false }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "GenreDescription", "GenreName" },
                values: new object[,]
                {
                    { 1, "Action games emphasize physical challenges that require hand-eye coordination and motor skill to overcome. They center around the player, who is in control of most of the action. Most of the earliest video games were considered action games;today, it is still a vast genre covering all games that involve physical challenges. ", "Action" },
                    { 2, "Adventure games were some of the earliest games created, beginning with the text adventure Colossal Cave Adventure in the 1970s. That game was originally titled simply 'Adventure', and is the namesake of the genre. Over time, graphics have been introduced to the genre and the interface has evolved. ", "Adventure" },
                    { 3, "Role-playing video games draw their gameplay from traditional tabletop role-playing games like Dungeons & Dragons.Most of these games cast the player in the role of a weak character that grows in strength and experience over the course of the game.", "Role-playing" },
                    { 5, "Strategy video games focus on gameplay requiring careful and skillfulthinking and planning in order to achieve victory and the action scales from world domination to squad-based tactics. ", "Strategy" },
                    { 6, "Sports are video games that simulate sports.This opposing team(s) can be controlled by other real life people or artificial intelligence.", "Sports" },
                    { 7, "Sandbox and open-world games are not specifically video game genres,as they generally describe gameplay features, but often games will be described as a sandbox or an open-world game as if it were a defining genre.They are included here for such distinguishing purposes. ", "Sandbox" },
                    { 8, "IHorror games are games that incorporate elements of horror fiction into their narrative,generally irrespective of the type of gameplay.It is the only major video game genre that is recognized by narrative elements rather than by gameplay,gameplay mode, or platform. Survival horror is a subgenre of horror games focused on action-adventure style of gameplay.", "Horror" },
                    { 9, "A massively multiplayer online game (also called MMO and MMOG) is a multiplayer online video game which is capable of supporting large numbers of players simultaneously. By necessity, they are played on the Internet.", "MMO" },
                    { 10, "Platform games (often simplified as platformer, or jump 'n' run) is a video game genre and subgenre of action games. Platformers are characterized by their heavy use of jumping and climbing to navigate the player's environment and reach their goal. Levels and environments tend to feature uneven terrain and suspended platforms of varying height that requires use of the player character's abilities in order to traverse.", "Platforming" },
                    { 4, "Simulation video games is a diverse super-category of games, generally designed to closely simulate aspects of a real or fictional reality.", "Simulation" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", "b4280b6a-0613-4cbd-a9e6-f1701e926e73" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "ConsoleId", "ConsoleName", "Description", "GameCreator", "GameName", "GenreId", "GenreName", "IsInStock", "IsOnSale", "PhotoPath", "Price" },
                values: new object[,]
                {
                    { 3, 1, "Playstation", "Bloodborne is an action role-playing game developed by FromSoftware and published by Sony Computer Entertainment,which released for the PlayStation 4 in March 2015.", "FromSoftware", "Bloodborne: GOTY", 1, "Action", true, true, "Bloodborne.jpg", 19.989999999999998 },
                    { 9, 2, "XBOX", "Halo: The Master Chief Collection is a compilation of first-person shooter video games in the Halo series, originally released in November 2014 for the Xbox One, and later on Microsoft Windows through 2019 and 2020. The enhanced version was released for the Xbox Series X|S in November 2020. The collection was developed by 343 Industries in partnership with other studios and was published by Xbox Game Studios. The collection consists of Halo: Combat Evolved Anniversary, Halo 2: Anniversary, Halo 3, Halo 3: ODST, Halo: Reach, and Halo 4, which were originally released on earlier Xbox platforms. ", "343 Industries", "Halo: The Master Chief Collection", 1, "Action", true, true, "Halo.jpg", 34.990000000000002 },
                    { 4, 1, "Playstation", "God of War is an action-adventure game developed by Santa Monica Studio and published by Sony Interactive Entertainment (SIE).Released on April 20, 2018, for the PlayStation 4 (PS4), it is the eighth installment in the God of War series,and the sequel to 2010's God of War III. Unlike previous games, which were loosely based on Greek mythology, this installment is rooted in Norse mythology, with the majority of it set in ancient Norway in the realm of Midgard. For the first time in the series, there are two protagonists: Kratos, the former Greek God of War who remains the only playable character, and his young son Atreus. Following the death of Kratos' second wife and Atreus' mother, they journey to fulfill her request that her ashes be spread at the highest peak of the nine realms. Kratos keeps his troubled past a secret from Atreus, who is unaware of his divine nature. Along their journey, they encounter monsters and gods of the Norse world. ", "SIE Santa Monica Studio", "God of War 2018", 2, "Adventure", false, false, "GodOfWar.jpg", 14.99 },
                    { 5, 1, "Playstation", "God of War is an action-adventure game developed by Santa Monica Studio and published by Sony Interactive Entertainment (SIE).Released on April 20, 2018, for the PlayStation 4 (PS4), it is the eighth installment in the God of War series,and the sequel to 2010's God of War III. Unlike previous games, which were loosely based on Greek mythology, this installment is rooted in Norse mythology, with the majority of it set in ancient Norway in the realm of Midgard. For the first time in the series, there are two protagonists: Kratos, the former Greek God of War who remains the only playable character, and his young son Atreus. Following the death of Kratos' second wife and Atreus' mother, they journey to fulfill her request that her ashes be spread at the highest peak of the nine realms. Kratos keeps his troubled past a secret from Atreus, who is unaware of his divine nature. Along their journey, they encounter monsters and gods of the Norse world. ", "Insomniac", "Spider-Man: GOTY", 2, "Adventure", true, true, "Spider-Man.jpg", 24.989999999999998 },
                    { 10, 2, "XBOX", "Sea of Thieves is a 2018 action-adventure game developed by Rare and published by Xbox Game Studios. The player assumes the role of a pirate who completes voyages from different trading companies in order to become the ultimate pirate legend. Sea of Thieves is a first-person multiplayer video game in which players cooperate with each other to explore an open world via a pirate ship. The game is described as a 'shared world adventure game', which means groups of players will encounter each other regularly during their adventures, sometimes forming alliances, sometimes going head-to-head. ", "Rare", "Sea of Thieves", 2, "Adventure", false, false, "SeaOfThieves.jpg", 44.990000000000002 },
                    { 1, 4, "Personal Computer", "The Elder Scrolls V: Skyrim is an open world action role-playing video game developed by Bethesda Game Studios and published by Bethesda Softworks.", "Bethesda", "Skyrim", 3, "Role-playing", true, true, "Skyrim.png", 9.9900000000000002 },
                    { 2, 4, "Personal Computer", "The Witcher 3: Wild Hunt is a 2015 action role-playing game developed and published by Polish developer CD Projekt Red and is based on The Witcher series of fantasy novels written by Andrzej Sapkowski.", "City Project Red", "Witcher 3: GOTY", 3, "Role-playing", false, true, "Witcher3.jpg", 19.989999999999998 },
                    { 6, 1, "Playstation", "Ghost of Tsushima is a 2020 action-adventure game developed by Sucker Punch Productions and published bySony Interactive Entertainment. Featuring an open world, it follows Jin Sakai, a samurai on a quest to protect Tsushima Island during the first Mongol invasion of Japan. The game was released on July 17, 2020 for PlayStation 4. Ghost of Tsushima received praise for its visuals and combat but was criticized for its open world activities. ", "Sucker Punch Productions", "Ghost of Tsushima", 3, "Role-playing", true, true, "GhostOfTsushima.webp", 34.990000000000002 },
                    { 14, 3, "Nintendo", "The Legend of Zelda: Breath of the Wild is a 2017 action-adventure game developed and published by Nintendo for the Nintendo Switch and Wii U consoles. Breath of the Wild is part of the Legend of Zelda franchise and is set at the end of the Zelda timeline; the player controls Link, who awakens from a hundred-year slumber to defeat Calamity Ganon and save the kingdom of Hyrule. ", "Nintendo EPD", "The Legend of Zelda: Breath of the Wild", 3, "Role-playing", false, true, "Zelda.jpg", 29.989999999999998 },
                    { 11, 4, "Personal Computer", "Euro Truck Simulator 2 is a truck simulator game developed and published by SCS Software for Microsoft Windows, Linux, and macOS and was initially released as open development on 19 October 2012. The game is a direct sequel to the 2008 game Euro Truck Simulator and it is the second video game in the Truck Simulator series. The basic premise of the game is that the player can drive one of a choice of articulated trucks across a condensed depiction of Europe, picking up cargo from various locations and delivering it. As the game progresses, it is possible for the player to buy more vehicles and depots, as well as hire other drivers to work for them. ", "SCS Software", "Euro Truck Simulator 2", 4, "Simulation", true, true, "ETS2.jpg", 9.9900000000000002 },
                    { 8, 2, "XBOX", "Forza Horizon 4 is a 2018 racing video game developed by Playground Games and published by Microsoft Studios. It was released on 2 October 2018 on Xbox One and Microsoft Windows after being announced at Xbox's E3 2018 conference.An enhanced version of the game was released on Xbox Series X/S on 10 November 2020. The game is set in a fictionalised representation of areas of Great Britain.It is the fourth Forza Horizon title and eleventh instalment in the Forza series. The game is noted for its introduction of changing seasons to the series.  ", "Playground Games", "Forza Horizon 4", 6, "Sports", false, false, "Forza.jpg", 24.989999999999998 },
                    { 12, 4, "Personal Computer", "Outlast 2 (stylized as OU⸸LASTII) is a first-person psychological horror survival video game developed and published by Red Barrels. It is the sequel to the 2013 video game Outlast, and features a journalist named Blake Langermann, along with his wife Lynn, roaming the Arizona desert to explore the murder of a pregnant woman only known as Jane Doe. Blake and Lynn get separated in a helicopter crash, and Blake has to find his wife while traveling through a village inhabited by a sderanged sect that believes the end of days are upon them. ", "Red Barrels", "Outlast 2", 8, "Horror", false, true, "outlast2.jpg", 19.989999999999998 },
                    { 7, 2, "XBOX", "Cuphead is a 2017 run and gun video game developed and published by Studio MDHR. The game was inspired by the rubber hose style of animation used in cartoons of the 1930s, such as the work of Fleischer Studios and Walt Disney Animation Studios, and sought to emulate their subversive and surrealist qualities. ", "	Studio MDHR", "Cuphead", 10, "Platforming", true, true, "Cuphead.jpg", 4.9900000000000002 },
                    { 13, 3, "Nintendo", "Super Mario Odyssey is a platform game developed and published by Nintendo for the Nintendo Switch on October 27, 2017. An entry in the Super Mario series, it follows Mario and Cappy, a sentient hat that allows Mario to control other characters and objects, as they journey across various worlds to save Princess Peach from his nemesis Bowser, who plans to forcibly marry her. In contrast to the linear gameplay of prior entries, the game returns to the primarily open-ended, 3D platform gameplay featured in Super Mario 64 and Super Mario Sunshine.", "Nintendo EPD", "Super Mario Odyssey", 10, "Platforming", true, true, "Mario.jpg", 19.989999999999998 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Games_ConsoleId",
                table: "Games",
                column: "ConsoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GenreId",
                table: "Games",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Consoles");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}

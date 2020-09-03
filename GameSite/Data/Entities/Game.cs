using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GameSite.Data.Entities
{
    public class Game
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string GameCreator { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string PhotoPath { get; set; }
        public bool IsOnSale { get; set; }
        public bool IsInStock { get; set; }
        public Genre Genre  { get; set; }

        public int GenreId { get; set; }
        public string GenreName { get; set; }

    }
}

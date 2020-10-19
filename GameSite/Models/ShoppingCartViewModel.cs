using GameSite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSite.Models
{
    public class ShoppingCartViewModel
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }


        public double SubTotal { get; set; }
        public double TotalPrice { get; set; }

        public IEnumerable<Game> AllGames { get; set; }
        public IEnumerable<Game> AllGamesAddedToCartByLoggedInUser { get; set; }
    }
}

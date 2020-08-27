using GameSite.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameSite.Models
{
    public class GameViewModel
    {
        [Key]
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string GameCreator { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile Photo { get; set; }
        public bool IsOnSale { get; set; }
        public bool IsInStock { get; set; }


        public Genre Genre { get; set; }
        public string GenreName { get; set; }
        public int? GenreId { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }
    }
}

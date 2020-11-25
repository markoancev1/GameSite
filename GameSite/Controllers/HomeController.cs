using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GameSite.Models;
using GameSite.Repository.Interface;
using GameSite.Data;
using GameSite.Data.Entities;
using DevExpress.Xpo.Helpers;

namespace GameSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGameRepository _gameRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IConsoleRepository _consoleRepository;
        private readonly DataContext _context
;
        public HomeController(ILogger<HomeController> logger,
            IGameRepository gameRepository,
            IGenreRepository genreRepository,
            IConsoleRepository consoleRepository,
            DataContext context)
        {
            _logger = logger;
            _gameRepository = gameRepository;
            _genreRepository = genreRepository;
            _consoleRepository = consoleRepository;
            _context = context;
        }

        
        public IActionResult Index()
        {
            var getGamesOnSale = _gameRepository.GetGamesOnSale();
            var getGameInStock = _gameRepository.GetGamesInStock();
            var getGameNotInStock = _gameRepository.GetGamesNotInStock();
            var getGameNotOnSale = _gameRepository.GetGamesNotOnSale();


            var gameViewModel = new GameViewModel
            {
                GamesInStock = getGameInStock,
                GamesOnSale = getGamesOnSale,
                GamesNotInStock = getGameNotInStock,
                GamesNotOnSale = getGameNotOnSale
            };
            return View(gameViewModel);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

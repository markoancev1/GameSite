using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GameSite.Models;
using GameSite.Repository.Interface;


namespace GameSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGameRepository _gameRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IShoppingCartRepository _cart;

        public HomeController(ILogger<HomeController> logger, 
            IGameRepository gameRepository,
            IGenreRepository genreRepository,
            IShoppingCartRepository cart)
        {
            _logger = logger;
            _gameRepository = gameRepository;
            _genreRepository = genreRepository;
            _cart = cart;
        }

        
        public IActionResult Index()
        {
            var getGamesOnSale = _gameRepository.GetGamesOnSale();
            var getGameInStock = _gameRepository.GetGamesInStock();

            var gameViewModel = new GameViewModel
            {
                GamesInStock = getGameInStock,
                GamesOnSale = getGamesOnSale,
            };
            return View(gameViewModel);
        }

        public IActionResult RefreshPartialViewNotification()
        {
            var notificationCounters = _cart.GetAllItemsInCart().Count();
            ViewData["Counter"] = notificationCounters;
            return PartialView("Notification");
        }

        public int AddToCartNotificationsCounterTest()
        {
            var notificationCounters = _cart.GetAllItemsInCart().Count();
            return notificationCounters;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

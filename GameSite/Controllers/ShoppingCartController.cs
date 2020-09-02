using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GameSite.Data.Entities;
using GameSite.Models;
using GameSite.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameSite.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartController(
            IGameRepository gameRepository,
            IGenreRepository genreRepository,
            IHttpContextAccessor httpContextAccessor,
            IShoppingCartRepository shoppingCartRepository)
        {
            _gameRepository = gameRepository;
            _genreRepository = genreRepository;
            _httpContextAccessor = httpContextAccessor;
            _shoppingCartRepository = shoppingCartRepository;
        }

        // GET: ShopCart
        public ActionResult Index()
        {
            List<Game> AllGamesListFromCartByLoggedInUser = new List<Game>();
            var TotalPriceCount = 0.0;
            var TotalShipping = 0.0;
            var NotificationCounter = 0;

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var itemsInCart = _shoppingCartRepository.GetAllItemsInCartByUserId(userId);

            foreach (var item in itemsInCart)
            {
                var game = _gameRepository.GetGameByID(item.GameId);
                if (game != null)
                {
                    AllGamesListFromCartByLoggedInUser.Add(game);
                }
            }

            TotalPriceCount = TotalShipping + Math.Round(AllGamesListFromCartByLoggedInUser.Sum(x => x.Price));
            NotificationCounter = _shoppingCartRepository.GetAllItemsInCart().Count();

            var shopCartViewModel = new ShoppingCartViewModel()
            {
                SubTotal = Math.Round(AllGamesListFromCartByLoggedInUser.Sum(x => x.Price), 2),
                TotalPrice = TotalPriceCount,
                AllGamesAddedToCartByLoggedInUser = AllGamesListFromCartByLoggedInUser,
                AddToCartTotalCounter = NotificationCounter
            };

            ViewData["Counter"] = NotificationCounter;

            return View(shopCartViewModel);
        }

        public JsonResult AddToCart(int id)
        {
            var getGameById = _gameRepository.GetGameByID(id);
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var gameId = getGameById.GameId;
            var genreId = getGameById.GenreId;
            var price = getGameById.Price;

            var shoppingCart = new ShoppingCart
            {
                UserId = userId,
                GameId = gameId,
                GenreId = genreId,
                Price = price++,
                DateAdded = DateTime.Now
            };

            _shoppingCartRepository.Add(shoppingCart);

            return new JsonResult(new { data = shoppingCart, url = Url.Action("Index", "Home") });
        }


        [HttpPost]
        public JsonResult Delete(int Id)
        {
            var getGame = _gameRepository.GetGameByID(Id);

            _shoppingCartRepository.DeleteByGameId(Id);
            return new JsonResult(new { data = getGame, url = Url.Action("Index", "ShoppingCart") });
        }

        public IActionResult Buy()
        {
            return RedirectToAction("Index", "Order");
        }
    }
}

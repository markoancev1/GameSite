﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GameSite.Data;
using GameSite.Data.Entities;
using GameSite.Logger;
using GameSite.Models;
using GameSite.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameSite.Controllers
{
    [Authorize(Roles = "admin, guest")]
    public class ShoppingCartController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly ILogger<ShoppingCartController> _logger;
        private readonly DataContext _context;

        public ShoppingCartController(
            IGameRepository gameRepository,
            IHttpContextAccessor httpContextAccessor,
            IShoppingCartRepository shoppingCartRepository,
            ILogger<ShoppingCartController> logger,
            DataContext context)
        {
            _gameRepository = gameRepository;
            _httpContextAccessor = httpContextAccessor;
            _shoppingCartRepository = shoppingCartRepository;
            _logger = logger;
            _context = context;
        }

        // GET: ShopCart
        public ActionResult Index()
        {
            List<Game> AllGamesListFromCartByLoggedInUser = new List<Game>();
            var TotalPriceCount = 0.0;
            var TotalShipping = 0.0;


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

            var shopCartViewModel = new ShoppingCartViewModel()
            {
                SubTotal = Math.Round(AllGamesListFromCartByLoggedInUser.Sum(x => x.Price), 2),
                TotalPrice = TotalPriceCount,
                AllGamesAddedToCartByLoggedInUser = AllGamesListFromCartByLoggedInUser,
            };
            _logger.LogInformation(LoggerMessageDisplay.ShoppingCartListed);
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
                Price = price,
                DateAdded = DateTime.Now
            };

            _shoppingCartRepository.Add(shoppingCart);
            _logger.LogInformation(LoggerMessageDisplay.GameAddedToShoppingCart);
            return new JsonResult(new { data = shoppingCart, url = Url.Action("Index", "Home") });
        }



        [HttpPost]
        public JsonResult Delete(int Id)
        {
            var getGame = _gameRepository.GetGameByID(Id);

            _shoppingCartRepository.DeleteByGameId(Id);
            _logger.LogInformation(LoggerMessageDisplay.GameDeletedFromShoppingCart);
            return new JsonResult(new { data = getGame, url = Url.Action("Index", "ShoppingCart") });
        }

        public IActionResult Buy()
        {
            return RedirectToAction("Index", "Order");
        }
    }
}

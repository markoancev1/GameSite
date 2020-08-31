using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameSite.Data.Entities;
using GameSite.Models;
using GameSite.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameSite.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IGameRepository gameRepository, ShoppingCart shoppingCart)
        {
            _gameRepository = gameRepository;
            _shoppingCart = shoppingCart;
        }

        [Authorize]
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }

        [Authorize]
        public RedirectToActionResult AddToShoppingCart(int gameId)
        {
            var selectedGame = _gameRepository.GetAllGames().FirstOrDefault(p => p.GameId == gameId);
            if (selectedGame != null)
            {
                _shoppingCart.AddToCart(selectedGame, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int gameId)
        {
            var selectedGame = _gameRepository.GetAllGames().FirstOrDefault(p => p.GameId == gameId);
            if (selectedGame != null)
            {
                _shoppingCart.RemoveFromCart(selectedGame);
            }
            return RedirectToAction("Index");
        }

    }
}

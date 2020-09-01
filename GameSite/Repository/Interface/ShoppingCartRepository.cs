using GameSite.Data;
using GameSite.Data.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSite.Repository.Interface
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly DataContext _context;

        public ShoppingCartRepository(DataContext context)
        {
            _context = context;
        }
        public void Add(ShoppingCart shoppingCart)
        {
            _context.ShoppingCarts.Add(shoppingCart);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var shoppingCart = GetShoppingCartById(id);
            _context.ShoppingCarts.Remove(shoppingCart);
            _context.SaveChanges();
        }

        public void DeleteByGameId(int gameId)
        {
            var shoppingCart = GetShoppingCartByGameId(gameId);
            _context.ShoppingCarts.Remove(shoppingCart);
            _context.SaveChanges();
        }

        public IEnumerable<ShoppingCart> GetAllItemsInCart()
        {
            var result = _context.ShoppingCarts.AsEnumerable();
            return result;
        }

        public IEnumerable<ShoppingCart> GetAllItemsInCartByUserId(string userId)
        {
            var result = _context.ShoppingCarts.AsEnumerable().Where(x => x.UserId == userId).DistinctBy(x => x.GameId);
            return result;
        }

        public ShoppingCart GetShoppingCartById(int id)
        {
            var result = _context.ShoppingCarts.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public ShoppingCart GetShoppingCartByGameId(int gameId)
        {
            var result = _context.ShoppingCarts.FirstOrDefault(x => x.GameId == gameId);
            return result;
        }
    }
}

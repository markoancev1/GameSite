using AspNetCore;
using GameSite.Data;
using GameSite.Data.Entities;
using GameSite.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSite.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly DataContext _context;

        public GameRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Game game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();
        }

        public void Delete(int gameId)
        {
            Game game = GetGameByID(gameId);
            _context.Games.Remove(game);
            _context.SaveChanges();
        }


        public IEnumerable<Game> GetGamesOnSale() => _context.Games
            .Where(s => s.IsOnSale);

        public IEnumerable<Game> GetGamesInStock() => _context.Games
            .Where(s => s.IsInStock);

        public IEnumerable<Game> GetAllGames()
        {
            var result = _context.Games.AsEnumerable();
            return result;
        }
        public Game GetGameByID(int gameId)
        {
            return _context.Games.FirstOrDefault(c => c.GameId == gameId);
        }

        public void Edit(Game game)
        {
            _context.Games.Update(game);
            _context.SaveChanges();
        }

        public IEnumerable<Game> GetAllGamesByConsoleId(int ConsoleId)
        {
            var result = _context.Games.Where(x => x.ConsoleId == ConsoleId).AsEnumerable();
            return result;
        }
    }
}

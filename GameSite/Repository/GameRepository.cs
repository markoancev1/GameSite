using GameSite.Data;
using GameSite.Data.Entities;
using GameSite.Logger;
using GameSite.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

        public IEnumerable<Game> GetGamesNotOnSale() => _context.Games
            .Where(s => s.IsOnSale == false);

        public IEnumerable<Game> GetGamesNotInStock() => _context.Games
            .Where(s => s.IsInStock == false);

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

        public IEnumerable<Game> GetAllGamesOnPc(int consoleId)
        {
            var result = _context.Games.AsEnumerable().Where(x => x.ConsoleId == consoleId);
            return result;
        }

        public IEnumerable<Game> GetAllGamesOnConsole()
        {
            var result = _context.Games.AsEnumerable().Where(x => x.ConsoleId != 4);
            return result;
        }
    }
}

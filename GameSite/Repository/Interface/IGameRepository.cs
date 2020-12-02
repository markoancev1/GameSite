using GameSite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSite.Repository.Interface
{
    public interface IGameRepository
    {
        void Add(Game game);
        void Delete(int gameId);
        void Edit(Game game);
        IEnumerable<Game> GetAllGames();
        IEnumerable<Game> GetGamesOnSale();
        IEnumerable<Game> GetGamesInStock();
        IEnumerable<Game> GetGamesNotOnSale();
        IEnumerable<Game> GetGamesNotInStock();
        IEnumerable<Game> GetAllGamesOnConsole();
        IEnumerable<Game> GetAllGamesOnPc(int consoleId);
        Game GetGameByID(int gameId);

    }
}

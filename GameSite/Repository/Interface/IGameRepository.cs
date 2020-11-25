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
        IEnumerable<Game> GetAllGamesByConsoleId(int ConsoleId);
        IEnumerable<Game> GetGamesOnSale();
        IEnumerable<Game> GetGamesInStock();
        IEnumerable<Game> GetGamesNotOnSale();
        IEnumerable<Game> GetGamesNotInStock();
        Game GetGameByID(int gameId);

    }
}

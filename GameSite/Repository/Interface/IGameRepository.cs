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
        IEnumerable<Game> GetAllGames();
        IEnumerable<Game> GetGamesOnSale();
        Game GetGameByID(int gameId);

    }
}

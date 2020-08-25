using GameSite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSite.Repository.Interface
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetAllGenres();

        void Add(Genre genre);
        void Edit(Genre genre);
        void Delete(int GenreID);
        Genre GetGenreById(int id);
    }
}

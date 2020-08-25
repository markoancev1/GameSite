using GameSite.Data;
using GameSite.Data.Entities;
using GameSite.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSite.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContext _context;

        public GenreRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public void Delete(int GenreId)
        {
            Genre genre = GetGenreById(GenreId);
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }

        public void Edit(Genre genre)
        {
            _context.Genres.Update(genre);
            _context.SaveChanges();
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            var result = _context.Genres.AsEnumerable();
            return result;
        }

        public Genre GetGenreById(int id)
        {
            var result = _context.Genres.FirstOrDefault(x => x.GenreId == id);
            return result;
        }
    }
}

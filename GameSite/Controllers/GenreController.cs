using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameSite.Data.Entities;
using GameSite.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameSite.Controllers
{
    [Authorize(Roles = "admin, guest")]
    public class GenreController : Controller
    {
        private readonly IGenreRepository _genreRepository;

        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public IActionResult Index()
        {
            var genreList = _genreRepository.GetAllGenres();
            return View(genreList);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {

            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]

        public IActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _genreRepository.Add(genre);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
        {
            var genre= _genreRepository.GetGenreById(id);
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Genre genre)
        {
            if (id != genre.GenreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _genreRepository.Edit(genre);
                }
                catch (Exception ex)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Details(int id)
        {
            var genre = _genreRepository.GetGenreById(id);

            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            Genre genre = _genreRepository.GetGenreById(id);

            return View(genre);
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                _genreRepository.Delete(id);
            }

            return RedirectToAction(nameof(Index));

        }
    }
}

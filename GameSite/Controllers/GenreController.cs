using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameSite.Data.Entities;
using GameSite.Logger;
using GameSite.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameSite.Controllers
{
    [Authorize(Roles = "admin, guest")]
    public class GenreController : Controller
    {
        private readonly IGenreRepository _genreRepository;
        private readonly ILogger<GenreController> _logger;
        public GenreController(IGenreRepository genreRepository, ILogger<GenreController> logger)
        {
            _genreRepository = genreRepository;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var genreList = _genreRepository.GetAllGenres();
            if (genreList != null)
            {
                _logger.LogInformation(LoggerMessageDisplay.GenresListed);
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.NoGenresInDB);
            }
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
                _logger.LogInformation(LoggerMessageDisplay.GenreCreated);
                return RedirectToAction(nameof(Index));
                
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.GenreNotCreatedModelStateInvalid);
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
                    _logger.LogInformation(LoggerMessageDisplay.GenreEdited);
                }
                catch (Exception ex)
                {
                    _logger.LogError(LoggerMessageDisplay.GenreEditErrorModelStateInvalid + "---> " + ex);
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
                _logger.LogWarning(LoggerMessageDisplay.NoGameFound);
                return NotFound();
            }
            _logger.LogInformation(LoggerMessageDisplay.GenreFoundDisplayDetails);
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
            try
            {
                if (ModelState.IsValid)
                {
                    _genreRepository.Delete(id);
                    _logger.LogInformation(LoggerMessageDisplay.GenreDeleted);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(LoggerMessageDisplay.GenreDeleted + "---> " + ex);
                throw;
            }

            return RedirectToAction(nameof(Index));

        }
    }
}

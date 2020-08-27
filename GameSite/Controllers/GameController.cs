using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GameSite.Data;
using GameSite.Data.Entities;
using GameSite.Models;
using GameSite.Repository;
using GameSite.Repository.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Converters;

namespace GameSite.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GameController(IGameRepository gameRepository, IGenreRepository genreRepository, DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _gameRepository = gameRepository;
            _genreRepository = genreRepository;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var gameList = _gameRepository.GetAllGames();
            return View(gameList);
        }
        [HttpGet]

        public IActionResult Add()
        {
            var model = new GameViewModel();

            PopulateChoices(model);

            return View(model);
        }


        [HttpPost]
        public IActionResult Add(GameViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                // map the data from model to your entity
                var game = new Game
                {
                    GameName = model.GameName,
                    GameCreator = model.GameCreator,
                    Price = model.Price,
                    Description = model.Description,
                    IsOnSale = model.IsOnSale,
                    IsInStock = model.IsInStock,
                    Genre = _context.Genres.Find(model.GenreId),
                    GenreName = model.GenreName,
                    PhotoPath = uniqueFileName

                };
        
                _context.Games.Add(game);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            // Form has errors, repopulate choices and redisplay form

            PopulateChoices(model);

            return View(model);
        }




        public IActionResult Edit(int id)
        {
            var game = _context.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }

            var model = new GameEditViewModel
            {
                GameName = game.GameName,
                GameCreator = game.GameCreator,
                Price = game.Price,
                Description = game.Description,
                IsOnSale = game.IsOnSale,
                IsInStock = game.IsInStock,
                GenreId = game.GenreId,
                GenreName = game.GenreName,
                ExistingPhotoPath = game.PhotoPath
            };

            PopulateChoices(model);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(GameEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Game game = _gameRepository.GetGameByID(model.Id);
                // Update the game object with the data in the model object
                game.GameName = model.GameName;
                game.GameCreator = model.GameCreator;
                game.Price = model.Price;
                game.Description = model.Description;
                game.IsOnSale = model.IsOnSale;
                game.IsInStock = model.IsInStock;
                game.Genre = _context.Genres.Find(model.GenreId);
                game.GenreName = model.GenreName;

                if (model.Photo != null)
                {
                    // If a new photo is uploaded, the existing photo must be
                    // deleted. So check if there is an existing photo and delete
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath,
                            "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    // Save the new photo in wwwroot/images folder and update
                    // PhotoPath property of the employee object which will be
                    // eventually saved in the database
                    game.PhotoPath = UploadedFile(model);
                }

                _context.Games.Update(game);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            PopulateChoices(model);

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var game = _gameRepository.GetGameByID(id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {

            Game game = _gameRepository.GetGameByID(id);


            return View(game);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {


            _gameRepository.Delete(id);

            return RedirectToAction(nameof(Index));

        }



        private string UploadedFile(GameViewModel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


        protected void PopulateChoices(GameViewModel model)
        {
            model.Genres = _context.Genres.Select(m => new SelectListItem
            {
                Value = m.GenreId.ToString(),
                Text = m.GenreName
            });
        }
    }
}

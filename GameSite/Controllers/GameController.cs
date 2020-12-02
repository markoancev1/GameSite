using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GameSite.Data;
using GameSite.Data.Entities;
using GameSite.Logger;
using GameSite.Models;
using GameSite.Repository;
using GameSite.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Converters;

namespace GameSite.Controllers
{
    [Authorize(Roles = "admin, guest")]
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IConsoleRepository _consoleRepository;
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<GameController> _logger;

        public GameController(IGameRepository gameRepository,
            IGenreRepository genreRepository,
            IConsoleRepository consoleRepository,
            DataContext context,
            IWebHostEnvironment webHostEnvironment,
            ILogger<GameController> logger
            )
        {
            _gameRepository = gameRepository;
            _genreRepository = genreRepository;
            _consoleRepository = consoleRepository;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }
        [Authorize(Roles = "admin, guest")]
        public IActionResult Index()
        {
            var gameList = _gameRepository.GetAllGames();
            
            if (gameList != null)
            {
                
                _logger.LogInformation(LoggerMessageDisplay.GamesListed);
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.NoGamesInDB);
            }
            return View(gameList);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]

        public IActionResult Add()
        {
            var model = new GameViewModel();
            PopulateChoices(model);
            _logger.LogInformation(LoggerMessageDisplay.GameFoundDisplayDetails);
            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Add(GameViewModel model)
        {

            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                var game = new Game
                {
                    GameName = model.GameName,
                    GameCreator = model.GameCreator,
                    Price = model.Price,
                    Description = model.Description,
                    IsOnSale = model.IsOnSale,
                    IsInStock = model.IsInStock,
                    GenreId = model.GenreId,
                    GenreName = model.GenreName,
                    ConsoleId = model.ConsoleId,
                    ConsoleName = model.ConsoleName,
                    PhotoPath = uniqueFileName

                };
        
                _context.Games.Add(game);
                _logger.LogInformation(LoggerMessageDisplay.GameCreated);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                _logger.LogError(LoggerMessageDisplay.GamesNotCreatedModelStateInvalid);

            }
            PopulateChoices(model);

            return View(model);
        }


        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
        {
            var game = _gameRepository.GetGameByID(id);
            try
            {

                if (game == null)
                {
                    throw new NullReferenceException();
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
                    ConsoleId = game.ConsoleId,
                    ConsoleName = game.ConsoleName,
                    ExistingPhotoPath = game.PhotoPath
                };

                PopulateEditChoices(model);
                _logger.LogInformation(LoggerMessageDisplay.GameFoundDisplayDetails);
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerMessageDisplay.NoGameFound + "--->" + ex);
                return View("Error");
            }
            
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Edit(GameEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Game game = _gameRepository.GetGameByID(model.Id);
                    game.GameName = model.GameName;
                    game.GameCreator = model.GameCreator;
                    game.Price = model.Price;
                    game.Description = model.Description;
                    game.IsOnSale = model.IsOnSale;
                    game.IsInStock = model.IsInStock;
                    game.GenreId = model.GenreId;
                    game.GenreName = model.GenreName;
                    game.ConsoleId = model.ConsoleId;
                    game.ConsoleName = model.ConsoleName;

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
                        _logger.LogInformation(LoggerMessageDisplay.PhotoEdited);
                    }

                    _context.Games.Update(game);
                    _logger.LogInformation(LoggerMessageDisplay.GameEdited);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(LoggerMessageDisplay.GameEditErrorModelStateInvalid + "--->" + ex);
                    return View("Error");
                }

            }

            PopulateChoices(model);

            return View(model);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Details(int id)
        {
            try {
                var game = _gameRepository.GetGameByID(id);
                if (game == null)
                {
                    throw new NullReferenceException();
                }
                _logger.LogInformation(LoggerMessageDisplay.GameFoundDisplayDetails);

                return View(game);
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerMessageDisplay.NoGameFound + "--->" + ex);
                return View("Error");
            }
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                Game game = _gameRepository.GetGameByID(id);

                if (game == null)
                {
                    throw new NullReferenceException();
                }
                _logger.LogInformation(LoggerMessageDisplay.GameFoundDisplayDetails);
                return View(game);
            }
            catch(Exception ex)
            {
                _logger.LogError(LoggerMessageDisplay.NoGameFound + "--->" + ex);
                return View("Error");
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {

            try
            {
                _gameRepository.Delete(id);
                _logger.LogInformation(LoggerMessageDisplay.GameDeleted);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LoggerMessageDisplay.GameDeletedError + "---> " + ex);
                throw;
            }
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
            else
            {
                _logger.LogError(LoggerMessageDisplay.PhotoUploadedError);
            }
            _logger.LogInformation(LoggerMessageDisplay.PhotoUploaded);
            return uniqueFileName;
        }
        protected void PopulateChoices(GameViewModel model)
        {
            model.Genres = _context.Genres.Select(m => new SelectListItem
            {
                Value = m.GenreId.ToString(),
                Text = m.GenreName
            });
            model.Consoles = _context.Consoles.Select(m => new SelectListItem
            {
                Value = m.ConsoleId.ToString(),
                Text = m.ConsoleName
            });


        }
        protected void PopulateEditChoices(GameEditViewModel model)
        {
            model.Genres = _context.Genres.Select(m => new SelectListItem
            {
                Value = m.GenreId.ToString(),
                Text = m.GenreName
            });
            model.Consoles = _context.Consoles.Select(m => new SelectListItem
            {
                Value = m.ConsoleId.ToString(),
                Text = m.ConsoleName
            });


        }
    }
}

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

        public GameController(IGameRepository gameRepository,IGenreRepository genreRepository,DataContext context, IWebHostEnvironment webHostEnvironment)
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
            var Genres = _genreRepository.GetAllGenres();

            GameViewModel GameVM = new GameViewModel();
            GameVM.Genres = GetSelelectListItemsGenres(Genres);

            return View(GameVM);
        }

        [HttpPost]

        public async Task<IActionResult> Add(GameViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                Game game = new Game
                {
                    GameName = model.GameName,
                    GameCreator = model.GameCreator,
                    Price = model.Price,
                    Description = model.Description,
                    IsOnSale = model.IsOnSale,
                    IsInStock = model.IsInStock,
                    GenreId = model.GenreId,
                    GenreName = model.GenreName,
                    ImageUrl = uniqueFileName
                };
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
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

            if (model.ImageUrl!= null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageUrl.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageUrl.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


        private IEnumerable<SelectListItem> GetSelelectListItemsGenres(IEnumerable<Genre> genres)
        {
            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "0",
                Text = "Select genre..."
            });
            foreach (var element in genres)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.GenreId.ToString(),
                    Text = element.GenreName
                });
            }
            return selectList;
        }

    }
}

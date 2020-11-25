using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameSite.Data;
using GameSite.Data.Entities;
using GameSite.Logger;
using GameSite.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameSite.Controllers
{
    [Authorize(Roles = "admin, guest")]
    public class ConsoleController : Controller
    {
        private readonly IConsoleRepository _consoleRepository;
        private readonly ILogger<ConsoleController> _logger;
        private readonly DataContext _context;

        public ConsoleController(IConsoleRepository consoleRepository, ILogger<ConsoleController> logger, DataContext context)
        {
            _consoleRepository= consoleRepository;
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var consoleList = _consoleRepository.GetAllConsoles();
            if (consoleList != null)
            {
                _logger.LogInformation(LoggerMessageDisplay.GenresListed);
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.NoGenresInDB);
            }
            return View(consoleList);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {

            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]

        public IActionResult Create(ConsoleUnit console)
        {
            if (ModelState.IsValid)
            {
                _consoleRepository.Add(console);
                _logger.LogInformation(LoggerMessageDisplay.ConsoleCreated);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.ConsoleNotCreatedModelStateInvalid);
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
        {
            var console = _consoleRepository.GetConsoleById(id);
            if (console == null)
            {
                return NotFound();
            }
            return View(console);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ConsoleUnit console)
        {
            if (id != console.ConsoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _consoleRepository.Edit(console);
                    _logger.LogInformation(LoggerMessageDisplay.ConsoleEdited);
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(LoggerMessageDisplay.ConsoleEditErrorModelStateInvalid + "---->" + ex);
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(console);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Details(int id)
        {
            var console = _consoleRepository.GetConsoleById(id);

            if (console == null)
            {
                _logger.LogWarning(LoggerMessageDisplay.NoConsoleFound);
                return NotFound();
            }
            _logger.LogInformation(LoggerMessageDisplay.ConsoleFoundDisplayDetails);
            return View(console);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            ConsoleUnit console = _consoleRepository.GetConsoleById(id);

            return View(console);
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _consoleRepository.Delete(id);
                    _logger.LogInformation(LoggerMessageDisplay.ConsoleDeleted);
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Exception Occured : {ex}");
                ViewBag.ErrorTitle = "Console is in use";
                ViewBag.ErrorMessage = " Console cannot be deleted as there are games using this console. If you want to delete this console, please remove the games using this console and then try to delete";
                return View("Error");
            }
            return RedirectToAction(nameof(Index));

        }
    }
}

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
    public class ConsoleController : Controller
    {
        private readonly IConsoleRepository _consoleRepository;

        public ConsoleController(IConsoleRepository consoleRepository)
        {
            _consoleRepository= consoleRepository;
        }
        public IActionResult Index()
        {
            var consoleList = _consoleRepository.GetAllConsoles();
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
                return RedirectToAction(nameof(Index));
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
                }
                catch (Exception ex)
                {
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
                return NotFound();
            }

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
            if (ModelState.IsValid)
            {
                _consoleRepository.Delete(id);
            }

            return RedirectToAction(nameof(Index));

        }
    }
}

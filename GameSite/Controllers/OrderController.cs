using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameSite.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GameSite.Controllers
{
    public class OrderController : Controller
    {

        public ViewResult Checkout() => View(new Order());

        public IActionResult Index()
        {
            return View();
        }
    }
}

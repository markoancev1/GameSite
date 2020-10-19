using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GameSite.Data.Entities;
using GameSite.Logger;
using GameSite.Models;
using GameSite.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameSite.Controllers
{
    [Authorize(Roles = "admin, guest")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderRepository orderRepository, IShoppingCartRepository shoppingCartRepository, ILogger<OrderController> logger)
        {
            _orderRepository = orderRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _logger = logger;
        }

        [Authorize(Roles = "admin")]

        public IActionResult Index()
        {
            var orderList = _orderRepository.GetAllOrders();

            if (orderList != null)
            {
                _logger.LogInformation(LoggerMessageDisplay.OrderListed);
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.NoOrdersInDB);
            }

            return View(orderList);
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (ModelState.IsValid)
            {
                order.OrderPlaced = DateTime.Now;
                _orderRepository.Add(order);
                _logger.LogInformation(LoggerMessageDisplay.OrderCreated);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                _logger.LogWarning(LoggerMessageDisplay.OrdersNotCreatedModelStateInvalid);
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            Order order = _orderRepository.GetOrderById(id);

            return View(order);
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {

            if (ModelState.IsValid)
            {
                _orderRepository.Delete(id);
                _logger.LogInformation(LoggerMessageDisplay.OrderDeleted);
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.OrderDeletedError);
            }

            return RedirectToAction(nameof(Index));

        }

    }
}

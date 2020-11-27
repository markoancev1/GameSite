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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderRepository orderRepository,
            IShoppingCartRepository shoppingCartRepository,
            ILogger<OrderController> logger,
            IHttpContextAccessor httpContextAccessor)
        {
            _orderRepository = orderRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _httpContextAccessor = httpContextAccessor;
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
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

                var shoppingCartItems = _shoppingCartRepository.GetAllItemsInCartByUserId(userId);

                var TotalPriceCount = Math.Round(shoppingCartItems.Sum(x => x.Price), 2);

                order.UserId = userId;
                order.Price = TotalPriceCount;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameSite.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameSite.Views.Shared
{
    public class NotificationsModel : PageModel
    {
        private readonly IShoppingCartRepository _cart;

        public NotificationsModel(IShoppingCartRepository cart)
        {
            _cart = cart;
        }

        public void OnGet()
        {
            var notificationCounters = _cart.GetAllItemsInCart().Count();

            ViewData["Counter"] = notificationCounters;
        }
    }
}
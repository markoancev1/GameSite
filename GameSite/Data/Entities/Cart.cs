using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSite.Data.Entities
{
    public class Cart
    {
        public string shoppingCartId { get; set; }
        public List<ShoppingCartItem> shoppingCartItems {get; set;}
    }
}

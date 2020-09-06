using GameSite.Data;
using GameSite.Data.Entities;
using GameSite.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSite.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private DataContext context;
        public OrderRepository(DataContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Order> Orders => context.Orders
        .Include(o => o.Carts)
        .ThenInclude(l => l.GameId);
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Carts.Select(l => l.GameId));
            if (order.OrderId == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}

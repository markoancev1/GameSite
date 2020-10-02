using GameSite.Data;
using GameSite.Data.Entities;
using GameSite.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GameSite.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private DataContext _context;
        
        public OrderRepository(DataContext ctx)
        {
            _context = ctx;
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Delete(int OrderId)
        {
            Order order = GetOrderById(OrderId);
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var result = _context.Orders.AsEnumerable();
            return result;
        }

        public Order GetOrderById(int id)
        {
            var result = _context.Orders.FirstOrDefault(x => x.OrderId == id);
            return result;
        }
    }
}

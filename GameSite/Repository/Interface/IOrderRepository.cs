using GameSite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSite.Repository.Interface
{
    public interface IOrderRepository
    {
        void Add(Order order);
        void Delete(int OrderID);
        Order GetOrderById(int id);
        IEnumerable<Order> GetAllOrders();
    }
}

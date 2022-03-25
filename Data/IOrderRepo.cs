using ShopiAssignment.Dtos;
using ShopiAssignment.Models;
using System.Collections.Generic;

namespace ShopiAssignment.Data
{
    public interface IOrderRepo
    {

        bool SaveChanges();
        IEnumerable<Order> GetAllOrders();
        Order GetById(int id);
        void CreateOrder(Order order);
        IEnumerable<Order> FilterOrder(OrderFilterModel order);

    }
}

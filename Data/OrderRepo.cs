using ShopiAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopiAssignment.Data
{
    public class OrderRepo : IOrderRepo
    {
        private readonly EntitiesContext _ctx;

        public OrderRepo(EntitiesContext ctx)
        {
            _ctx = ctx;
        }

        public void CreateOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            } 
            else if(order.BrandId == 0)
            {
                throw new ArgumentException(nameof(order));
            }

            _ctx.Orders.Add(order);
                    
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _ctx.Orders.ToList();
        }

        public IEnumerable<Order> FilterOrder(OrderFilterModel order)
        {

            if (order.SearchText == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            var ContainsValue = _ctx.Orders.Where(r => order.Statuses.Contains(r.Status)).Skip(order.PageNumber).Take(order.PageSize).ToList();


            var FilteredResults = _ctx.Orders.Where(t => t.StoreName.Contains(order.SearchText) || t.CustomerName.Contains(order.SearchText))
                .Where(t => (DateTime.Compare(t.CreatedOn, order.StartDate) >= 0) && (DateTime.Compare(t.CreatedOn, order.EndDate) <= 0))
               .Where(r => order.Statuses.Contains(r.Status)).Skip(order.PageNumber).Take(order.PageSize).ToList();
            switch (order.SortBy)
            {
                case "Id":
                    FilteredResults = (from o in FilteredResults orderby o.Id ascending select o).ToList();
                    break;
                case "BrandId":
                    FilteredResults = (from o in FilteredResults orderby o.BrandId ascending select o).ToList();
                    break;
                case "Price":
                    FilteredResults = (from o in FilteredResults orderby o.Price ascending select o).ToList();
                    break;
                case "CustomerName":
                    FilteredResults = (from o in FilteredResults orderby o.CustomerName ascending select o).ToList();
                    break;
                case "StoreName":
                    FilteredResults = (from o in FilteredResults orderby o.StoreName ascending select o).ToList();
                    break;
                case "CreatedOn":
                    FilteredResults = (from o in FilteredResults orderby o.CreatedOn ascending select o).ToList();
                    break;
                case "Status":
                    FilteredResults = (from o in FilteredResults orderby o.Status ascending select o).ToList();
                    break;
                default:
                    break;

            }
            return FilteredResults;
                   

        } 

        public Order GetById(int id)
        {
            return _ctx.Orders.FirstOrDefault(o => o.Id == id);

        }
        public bool SaveChanges()
        {
            return (_ctx.SaveChanges() >= 0);
        }

    }
}

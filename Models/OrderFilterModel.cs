using System;
using System.Collections.Generic;

namespace ShopiAssignment.Models
{
    public class OrderFilterModel
    {
        public string SearchText { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string SortBy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<OrderStatus> Statuses { get; set; }
    }
}

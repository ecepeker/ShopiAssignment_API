using ShopiAssignment.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ShopiAssignment.Dtos
{
    public class OrderCreateDto
    {
        [Required]
        public int BrandId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string StoreName { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public OrderStatus Status { get; set; }
    }
}

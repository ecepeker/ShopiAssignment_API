using System;
using System.ComponentModel.DataAnnotations;

namespace ShopiAssignment.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int Id { get; set; }
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

    public enum OrderStatus
    {
        Created = 10,
        InProgress = 20,
        Failed = 30,
        Completed = 40,
        Canceled = 50,
        Returned = 60
    }
}

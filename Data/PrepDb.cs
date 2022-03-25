using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ShopiAssignment.Models;
using System;
using System.Linq;

namespace ShopiAssignment.Data
{
    public static class PrepDb
    {
        public static void PrepPop(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<EntitiesContext>());
            } 
        }

        private static void SeedData(EntitiesContext ctx)
        {
            if (!ctx.Orders.Any())
            {
                ctx.Orders.AddRange(
                    new Order() { BrandId = 1, CustomerName = "Ali", StoreName = "Store1", Price = 3000, Status = OrderStatus.Completed, CreatedOn= DateTime.Now},
                    new Order() { BrandId = 2, CustomerName = "Ayşe", StoreName = "Store2", Price = 3600, Status = OrderStatus.Failed, CreatedOn = DateTime.Now },
                    new Order() { BrandId = 3, CustomerName = "Elif", StoreName = "Store3", Price = 2100, Status = OrderStatus.Completed, CreatedOn = DateTime.Now },
                    new Order() { BrandId = 5, CustomerName = "Deniz", StoreName = "Store4", Price = 3870, Status = OrderStatus.Completed, CreatedOn = DateTime.Now },
                    new Order() { BrandId = 8, CustomerName = "Mehmet", StoreName = "Store5", Price = 4300, Status = OrderStatus.InProgress, CreatedOn = DateTime.Now },
                    new Order() { BrandId = 4, CustomerName = "Emre", StoreName = "Store6", Price = 3900, Status = OrderStatus.InProgress, CreatedOn = DateTime.Now },
                    new Order() { BrandId = 9, CustomerName = "Ece", StoreName = "Store7", Price = 1980, Status = OrderStatus.Returned, CreatedOn = DateTime.Now },
                    new Order() { BrandId = 8, CustomerName = "Aslı", StoreName = "Store8", Price = 2150, Status = OrderStatus.Canceled, CreatedOn = DateTime.Now },
                    new Order() { BrandId = 11, CustomerName = "Berke", StoreName = "Store9", Price = 9000, Status = OrderStatus.Created, CreatedOn = DateTime.Now },
                    new Order() { BrandId = 13, CustomerName = "Pınar", StoreName = "Store10", Price = 12000, Status = OrderStatus.Canceled, CreatedOn = DateTime.Now }

                );

                ctx.SaveChanges();
            }
            else
            {
                Console.WriteLine("--->We already have data");
            }
        }
    }
}

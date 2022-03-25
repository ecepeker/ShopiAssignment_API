using Microsoft.EntityFrameworkCore;
using ShopiAssignment.Models;

namespace ShopiAssignment.Data
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext(DbContextOptions<EntitiesContext> opt): base(opt)
        {

        }

        public DbSet<Order> Orders { get; set; }
    }
}

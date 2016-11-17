using Microsoft.EntityFrameworkCore;

namespace NancyEFCore
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./customer.db");
        }
    }
}
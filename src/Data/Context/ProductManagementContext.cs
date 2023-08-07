using Business.Models;
using Microsoft.EntityFrameworkCore;


namespace Data.Context
{
    internal class ProductManagementContext : DbContext
    {
        public ProductManagementContext(DbContextOptions options) : base(options) {
        

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}

using Business.Models;
using Microsoft.EntityFrameworkCore;


namespace Data.Context
{
    public class ProductManagementContext : DbContext
    {
        public ProductManagementContext(DbContextOptions options) : base(options) {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetProperties()
                .Where(x => x.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)"); 

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductManagementContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}

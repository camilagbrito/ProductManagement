using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    internal class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");
            builder.Property(x => x.Description)
               .IsRequired()
               .HasColumnType("varchar(1000)");
            builder.Property(x => x.Image)
            .IsRequired()
            .HasColumnType("varchar(100)");

            builder.ToTable("Products");
        }
    }

    internal class ProviderMapping : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");
            builder.Property(x => x.IdentityCard)
               .IsRequired()
               .HasColumnType("varchar(14)");

            //1:1 => Provider : Address
         
            builder.ToTable("Providers");
        }
    }
}

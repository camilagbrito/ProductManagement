using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
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
            builder.HasOne(x => x.Address)
                .WithOne(x => x.Provider);

            //1:N => Provider: Products

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Provider)
                .HasForeignKey(x => x.ProviderId);

            builder.ToTable("Providers");
        }
    }
}

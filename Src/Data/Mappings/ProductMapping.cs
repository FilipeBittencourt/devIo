using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Description)
               .IsRequired()
               .HasColumnType("varchar(100)");

            builder.Property(p => p.Image)
               .IsRequired()
               .HasColumnType("varchar(100)");

            // 1 : 1 => Fornecedor : Endereco
            //builder.HasOne(a => a.Supplier);          


            builder.ToTable("Product");
        }
    }


}

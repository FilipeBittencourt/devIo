using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{

    public class SuppliertMapping : IEntityTypeConfiguration<Supplier>
    {

        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.FantasyName)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Document)
                .IsRequired()
                .HasColumnType("varchar(100)");

            // 1 : 1 => Fornecedor : Endereco
            builder.HasOne(a => a.Address)
                .WithOne(s => s.Supplier);

            // 1 : N => Fornecedor : Produtos
            builder.HasMany(p => p.Product)
                .WithOne(s => s.Supplier)
                .HasForeignKey(s => s.SupplierId);


            builder.ToTable("Supplier");
        }
    }

}

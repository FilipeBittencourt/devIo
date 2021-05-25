using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class AddresstMapping : IEntityTypeConfiguration<Address>
    {

        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Information)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

            builder.Property(p => p.Number)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

            builder.Property(p => p.Complement)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

            builder.Property(p => p.ZipCode)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

            builder.Property(p => p.Neighborhood)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

            builder.Property(p => p.City)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

            builder.Property(p => p.City)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

            builder.ToTable("Address");
        }
    }
}

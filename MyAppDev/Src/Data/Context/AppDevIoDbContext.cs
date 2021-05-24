using Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Context
{
    public class AppDevIoDbContext : DbContext
    {
        public AppDevIoDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Product  { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Address> Address { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Set maximum varchar in case you forget the property
            var properties = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string)));

            foreach (var property in properties)
            {
               // property.SetColumnType("varchar(10)");
                property.Relational().ColumnType = "varchar(100)";
                
            }


            //Mapping all entities
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDevIoDbContext).Assembly);

            //No delete cascade
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }
                

            base.OnModelCreating(modelBuilder);
        }
    }
}

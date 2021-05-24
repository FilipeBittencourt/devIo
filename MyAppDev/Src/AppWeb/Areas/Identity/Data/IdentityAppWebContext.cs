
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AppWeb.ViewModels;

namespace AppWeb.Areas.Identity.Data
{
    //public class IdentityAppWebContext : IdentityDbContext<IdentityUser>
    public class IdentityAppWebContext : IdentityDbContext
    {
        public IdentityAppWebContext(DbContextOptions<IdentityAppWebContext> options)
            : base(options)
        {
        }
        public DbSet<AppWeb.ViewModels.ProductViewModel> ProductViewModel { get; set; }
      

    }
     
}

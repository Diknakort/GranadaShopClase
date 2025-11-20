using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GranadaShopClase.API.Identity.Data
{
    public class IdentityDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=identityauthdb;Username=postgres;Password=postgres");
            return new ApplicationDbContext(optionsBuilder.Options);

        }
    }
}

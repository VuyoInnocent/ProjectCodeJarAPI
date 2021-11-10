using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectCodeJarAPI.Domain;

namespace ProjectCodeJarAPI.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
          : base(options)
        {
        }
        public DbSet<Coin> Coin { get; set; }

    }
}

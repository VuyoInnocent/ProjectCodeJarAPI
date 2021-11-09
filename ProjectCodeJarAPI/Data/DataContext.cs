using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectCodeJarAPI.Domain;
using ProjectCodeJarAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCodeJarAPI.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
          : base(options)
        {
        }
        public DbSet<Coin> Coin { get; set; }
        public DbSet<CoinJar> CoinJar { get; set; }
    }
}

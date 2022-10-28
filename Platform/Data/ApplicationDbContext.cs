using Microsoft.EntityFrameworkCore;
using Platform.Models;

namespace Platform.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            
        }

         public DbSet<Platforms> Platforms { get; set; }

    }
}
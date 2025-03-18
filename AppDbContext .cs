using Microsoft.EntityFrameworkCore;

namespace BackForFrontVue2
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Opțional: Adaugă DbSet pentru a lucra cu tabele dacă ai nevoie.
        // public DbSet<User> Users { get; set; }
    }
}
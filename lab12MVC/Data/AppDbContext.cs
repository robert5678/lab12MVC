using Microsoft.EntityFrameworkCore;
using lab12MVC.Models;

namespace lab12MVC.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TestCoreApp.Models;

namespace TestCoreApp.Data
{
    public class AppDbContext:DbContext
    {
        // Constractor
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }
        // إستدعاء موديل
        public DbSet<Item> Items { get; set; } 
        public DbSet<Category> Categries { get; set; }
    }
}

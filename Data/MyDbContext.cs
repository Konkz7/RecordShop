using Microsoft.EntityFrameworkCore;
using RecordShop.Models;

namespace RecordShop.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestDb");
        }
    }
}

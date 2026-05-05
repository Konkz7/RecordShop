using Microsoft.EntityFrameworkCore;
using RecordShop.Models;

namespace RecordShop.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
        {
        }
    }
}

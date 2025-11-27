
using Microsoft.EntityFrameworkCore;
using LMA25_V2.Models;

namespace LMA25_V2.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
    }
}




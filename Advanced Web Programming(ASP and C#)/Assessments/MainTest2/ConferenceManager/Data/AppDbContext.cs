using ConferenceManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ConferenceManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Paper> Papers { get; set; }
        public DbSet<Topic> Topics { get; set; }


    }
}

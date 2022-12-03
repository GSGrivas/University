using GreenhouseNursery.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenhouseNursery.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Plant> Plants { get; set; } //Do not make any changes here
        public DbSet<Category> Categories { get; set; } //Do not make any changes here

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Plant>().ToTable("Plant");
            modelBuilder.Entity<Category>().ToTable("Category");
        }
    }
}

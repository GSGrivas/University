using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCollection.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCollection.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}

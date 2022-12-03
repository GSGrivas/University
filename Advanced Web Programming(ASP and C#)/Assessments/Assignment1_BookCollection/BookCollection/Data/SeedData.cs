using BookCollection.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookCollection.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book { BookTitle = "Dune", BookAuthor = "Frank Herbert", BookISBN = "0-1720-7671-4", BookIsRead = true },
                    new Book { BookTitle = "Harry Potter", BookAuthor = "J.K. Rowling", BookISBN = "0-5538-7317-2", BookIsRead = true },
                    new Book { BookTitle = "The Lord of The Rings", BookAuthor = "J.R.R. Tolkien", BookISBN = "0-5931-0383-1", BookIsRead = true },
                    new Book { BookTitle = "A Song of Ice and Fire", BookAuthor = "George R.R. Martin", BookISBN = "0-5827-4618-3", BookIsRead = false }
                    );
                context.SaveChanges();

            }
            context.SaveChanges();
        }
    }
}

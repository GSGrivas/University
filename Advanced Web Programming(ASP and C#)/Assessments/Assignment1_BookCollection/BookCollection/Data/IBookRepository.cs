using BookCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCollection.Data
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAllBooks();

        void AddBook(Book book);

    }
}

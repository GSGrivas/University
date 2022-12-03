using BookCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCollection.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IQueryable<Book> GetAllBooks()
        {
            return _appDbContext.Books;
        }

        //public IEnumerable<Book> GetBooks
        //{
        //    get
        //    {
        //        return _appDbContext.Books;
        //    }
        //}

        public void AddBook(Book book)
        {
            _appDbContext.Books.Add(book);
            _appDbContext.SaveChanges();
        }


    }
}

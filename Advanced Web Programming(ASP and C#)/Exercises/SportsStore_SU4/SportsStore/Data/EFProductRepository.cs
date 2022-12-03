using SportsStore.Models;
using System.Collections.Generic;

namespace SportsStore.Data
{
    //Note: Make the necessary changes to this class to
    //      complete the implementation of the Repository pattern.
    public class EFProductRepository : IProductRepository
    {
        private AppDbContext _context;

        public EFProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> AllProducts
        { 
            get
            { 
                return _context.Products; 
            }
        }
    }
}

using SportsStore.Models;
using System.Collections.Generic;

namespace SportsStore.Data
{
    //Note: Make the necessary changes to this class to
    //      complete the implementation of the Repository pattern.
    public interface IProductRepository
    {
        IEnumerable<Product> AllProducts { get; }
    }
}

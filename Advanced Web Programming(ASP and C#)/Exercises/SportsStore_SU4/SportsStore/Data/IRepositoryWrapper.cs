using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Data
{
    public interface IRepositoryWrapper
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }

        IOrderRepository Order { get; }
    }
}

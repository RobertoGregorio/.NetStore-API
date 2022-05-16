using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Models;

namespace Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        public IEnumerable<Product> GetProductByPrice();

         public IEnumerable<Product> GetProductsPaginated(int pageNumber, int pageSize);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Repository;
using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public IEnumerable<Product> GetProductByPrice()
        {
            var products = Get().OrderBy(product => product.Price);
            return products;
        }
    }
}
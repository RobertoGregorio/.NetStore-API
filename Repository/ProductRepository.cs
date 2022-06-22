using System.Collections.Generic;
using System.Linq;
using Api.Interfaces;
using Repository;
using Api.Data;
using Api.Domain;

namespace Api.Repository
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

        public IEnumerable<Product> GetProductsPaginated(int pageNumber, int pageSize)
        {
            var products = Get().ToList().Skip((pageNumber - 1)*pageSize).Take(pageSize);

            return products;
        }
    }
}
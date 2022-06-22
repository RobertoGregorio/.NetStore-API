using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Api.Data;

namespace Api.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private IProductRepository _productRepository;

        private ICategoryRepository _categoryRepository;

        private DataContext _dbContext;

        public UnitOfWork([FromServices] DataContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IProductRepository productRepository
        {
            get => _productRepository ?? new ProductRepository(_dbContext);
        }

        public ICategoryRepository categoryRepository 
        { 
              get => _categoryRepository ?? new CategoryRepository(_dbContext);
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
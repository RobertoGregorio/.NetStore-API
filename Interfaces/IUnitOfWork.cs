using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;

namespace WebApi.Interfaces
{
    public interface IUnitOfWork
    {
        public IProductRepository productRepository { get;  }

        public ICategoryRepository categoryRepository { get; }
        
        void Commit();
    }
}
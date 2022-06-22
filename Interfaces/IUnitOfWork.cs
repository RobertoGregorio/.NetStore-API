namespace Api.Interfaces
{
    public interface IUnitOfWork
    {
        public IProductRepository productRepository { get;  }

        public ICategoryRepository categoryRepository { get; }
        
        void Commit();
    }
}
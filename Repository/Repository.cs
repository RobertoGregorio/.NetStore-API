using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Interfaces;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DataContext _dataContext;
        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(T baseEntity)
        {
            _dataContext.Set<T>().Remove(baseEntity);
        }

        public IEnumerable<T> Get()
        {
            var products = _dataContext.Set<T>();

            return products;
        }

        public T GetById(Expression<Func<T, bool>> func)
        {
            var product = _dataContext.Set<T>().FirstOrDefault(func);

            return product;
        }

        public void Insert(T baseEntity)
        {
            _dataContext.Set<T>().Add(baseEntity);

            _dataContext.SaveChanges();
        }

        public void Update(T baseEntity)
        {
            _dataContext.Set<T>().Update(baseEntity);

            _dataContext.SaveChanges();
        }
    }
}
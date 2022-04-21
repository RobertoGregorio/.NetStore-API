using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApi.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> Get();

        public T GetById(Expression<Func<T, bool>> func);

        public void Insert (T Entity);

        public void Delete(T Entity);

        public void Update(T Entity);

    }
}
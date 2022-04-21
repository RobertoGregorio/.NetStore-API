using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Models;

namespace Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public Category GetCategoryByCode(string code);
    }
}
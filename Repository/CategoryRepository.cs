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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public Category GetCategoryByCode(string code)
        {
           var category =  Get().FirstOrDefault(category => category.Code == code);

           return category;
        }

    }
}
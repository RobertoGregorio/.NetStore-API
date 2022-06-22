using System.Linq;
using Api.Interfaces;
using Repository;
using Api.Data;
using Api.Domain;

namespace Api.Repository
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
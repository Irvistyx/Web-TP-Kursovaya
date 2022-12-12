using MyCompany.Domain.Repositories.Abstract;
using MyCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.EntityFramework
{
    public class CategoryRepository : IProductCategory
    {
        private readonly AppDbContext context;
        public CategoryRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Category> AllCategory => context.Category;
    }
}

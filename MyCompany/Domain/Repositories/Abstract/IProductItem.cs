using MyCompany.Domain.Entities;
using MyCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.Abstract
{
    public interface IProductItem
    {
        IQueryable<Product> GetProductItems();
        Product GetProductItemById(Guid id);
        void SaveProductItem(Product entity);
        void DeleteProductItem(Guid id);
    }
}

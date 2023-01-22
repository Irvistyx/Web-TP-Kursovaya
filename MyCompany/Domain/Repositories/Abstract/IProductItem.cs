using MyCompany.Domain.Entities;
using System;
using System.Linq;

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
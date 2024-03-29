﻿using Microsoft.EntityFrameworkCore;
using MyCompany.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MyCompany.Domain.Repositories.Abstract
{
    [NotMapped]
    public class ProductRepository: IProductItem
    {
        private readonly AppDbContext context;
        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void DeleteProductItem(Guid id)
        {
            var Bask = context.Baskets.Where(x => x.product.Id == id);
            context.Baskets.RemoveRange(Bask);
            context.Products.Remove(new Product() { Id = id });
            context.SaveChanges();
        }

        public Product GetProductItemById(Guid id)
        {
            return context.Products.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Product> GetProductItems()
        {
            return context.Products;
        }

        public void SaveProductItem(Product entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
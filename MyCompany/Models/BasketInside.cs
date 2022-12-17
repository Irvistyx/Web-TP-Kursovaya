using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyCompany.Domain;
using MyCompany.Domain.Entities;
using MyCompany.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Models
{
    public class BasketInside
    {
        private readonly AppDbContext context;
        public BasketInside(AppDbContext context)
        {
            this.context = context;
        }
        public string BasketInsideId { get; set; }
        public List<Basket> listBasket { get; set; }

        public static BasketInside GetProduct(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var cont = service.GetService<AppDbContext>();
            string basketInsideId = session.GetString("ProductId") ?? Guid.NewGuid().ToString();

            session.SetString("ProductId", basketInsideId);

            return new BasketInside(cont) { BasketInsideId = basketInsideId };
        }

        public void AddToBasket(Product product)
        {
            context.Baskets.Add(new Basket
            {
                BasketInside = BasketInsideId,
                product = product,
                cost = product.cost
            });

            context.SaveChanges();
        }

        public List<Basket> GetBasket()
        {
            return context.Baskets.Where(c => c.BasketInside == BasketInsideId).Include(s => s.product).ToList();
        }
    }
}

using MyCompany.Domain.Repositories.Abstract;
using MyCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.EntityFramework
{
    public class EFOrderRepository : IAllOrder
    {
        private readonly AppDbContext context;
        private readonly BasketInside basketInside;
        public EFOrderRepository(AppDbContext context, BasketInside basketInside)
        {
            this.context = context;
            this.basketInside = basketInside;
        }
        public void createOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            context.Orders.Add(order);

            var items = basketInside.listBasket;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    ProductID = el.product.Id,
                    OrderID = order.Id,
                    Cost = el.product.cost,
                    Count = el.count
                };
                context.OrderDetails.Add(orderDetail);
            }
            context.SaveChanges();
        }

        public IQueryable<Order> getOrder()
        {
            return context.Orders;
        }
        public IQueryable<OrderDetail> getOrder(Guid id)
        {
            return context.OrderDetails.Where(x => x.OrderID == id);
        }

        public void SetStatus(string email, string status)
        {
            var order = context.Orders.Where(x => x.Email == email);
            var ord = order.AsEnumerable().Last();
            ord.Status = status;
            context.SaveChanges();
        }
        public void DeleteOrder(Guid id)
        {
            context.Orders.Remove(new Order() { Id = id });
            context.SaveChanges();
        }
    }
}

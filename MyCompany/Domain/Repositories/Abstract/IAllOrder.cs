﻿using MyCompany.Models;
using System;
using System.Linq;

namespace MyCompany.Domain.Repositories.Abstract
{
    public interface IAllOrder
    {
        void createOrder(Order order);
        IQueryable<Order> getOrder();
        IQueryable<OrderDetail> getOrder(Guid id);
        void SetStatus(string order, string status);
        void DeleteOrder(Guid id);
    }
}
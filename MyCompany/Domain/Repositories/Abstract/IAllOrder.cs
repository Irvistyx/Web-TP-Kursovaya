﻿using MyCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.Abstract
{
    public interface IAllOrder
    {
        void createOrder(Order order);
    }
}

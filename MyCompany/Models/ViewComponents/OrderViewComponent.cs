using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Models.ViewComponents
{
    public class OrderViewComponent : ViewComponent
    {
        private readonly DataManager dataManager;

        public OrderViewComponent(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult)View("Order_Layout", dataManager.Basket.GetBasket()));
        }
    }
}

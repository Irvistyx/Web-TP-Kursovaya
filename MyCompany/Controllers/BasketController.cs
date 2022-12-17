using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain.Entities;
using MyCompany.Domain.Repositories.Abstract;
using MyCompany.Models;
using Microsoft.EntityFrameworkCore;
using MyCompany.Models.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Controllers
{
    public class BasketController: Controller
    {
        private IProductItem _product;
        private readonly BasketInside _basketInside;

        public BasketController(IProductItem product, BasketInside basketInside)
        {
            _product = product;
            _basketInside = basketInside;
        }

        public ViewResult Index()
        {
            var items = _basketInside.GetBasket();
            _basketInside.listBasket = items;

            var obj = new BasketProductViewModel
            {
                basketInside = _basketInside
            };

            return View(obj);
        }

        public RedirectToActionResult addToBasket(Guid id)
        {
            var item = _product.GetProductItems().FirstOrDefault(i => i.Id == id);
            if(item != null)
            {
                _basketInside.AddToBasket(item);
            }
            return RedirectToAction("Index");
        }
    }
}

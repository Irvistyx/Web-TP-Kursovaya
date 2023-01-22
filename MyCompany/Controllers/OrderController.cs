using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain.Repositories.Abstract;
using MyCompany.Models;

namespace MyCompany.Controllers
{
    [Authorize]
    public class OrderController: Controller
    {
        private readonly IAllOrder allOrder;
        private readonly BasketInside basketInside;
        public OrderController(IAllOrder allOrder, BasketInside basketInside)
        {
            this.allOrder = allOrder;
            this.basketInside = basketInside;
        }
        public IActionResult checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult checkout(Order order)
        {
            basketInside.listBasket = basketInside.GetBasket();

            if(basketInside.listBasket.Count == 0)
            {
                ModelState.AddModelError("", "Корзина пуста!");
            }

            if(ModelState.IsValid)
            {
                allOrder.createOrder(order);
                return RedirectToAction("API", order);
            }

            return View(order);
        }
        public IActionResult Fail(string email)
        {
            ViewBag.Message = "Заказ не оплачен";
            allOrder.SetStatus(email, "Отменен");
            return View();
        }
        public IActionResult Complete(string email)
        {
            ViewBag.Message = "Заказ успешно обработан";
            allOrder.SetStatus(email, "Оплачен");
            return View();
        }
        public IActionResult API(Order order)
        {
            return View(order);
        }
        [HttpPost]
        public IActionResult API(string order, string select)
        {
            if (select == "Да")
            {
                return RedirectToAction("Complete", new { email = order });
            }
            else if (select == "Нет")
            {
                return RedirectToAction("Fail", new { email = order });
            }

            return View(order);
        }
    }
}

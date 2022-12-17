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
                return RedirectToAction("Complete");
            }

            return View(order);
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}

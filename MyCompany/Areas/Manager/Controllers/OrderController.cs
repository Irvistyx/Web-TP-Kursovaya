using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using MyCompany.Domain.Repositories.Abstract;
using MyCompany.Models;
using MyCompany.Service;
using System;

namespace MyCompany.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class OrderController: Controller
    {
        private readonly IAllOrder allOrder;
        private readonly DataManager dataManager;

        public OrderController(IAllOrder allOrder, DataManager dataManager)
        {
            this.allOrder = allOrder;
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.AllOrder.getOrder());
        }
        [HttpPost]
        public IActionResult Index(string email, string status)
        {
            allOrder.SetStatus(email, status);
            return View(dataManager.AllOrder.getOrder());
        }
        public IActionResult OrderDetail(Guid id)
        {
            return View(dataManager.AllOrder.getOrder(id));
        }
        public IActionResult Delete(Guid id)
        {
            dataManager.AllOrder.DeleteOrder(id);
            return RedirectToAction("Index");
        }
    }
}

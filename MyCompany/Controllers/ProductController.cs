using System;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;


namespace MyCompany.Controllers
{
    public class ProductController: Controller
    {
        private readonly DataManager dataManager;

        public ProductController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                return View("Show", dataManager.ProductItem.GetProductItemById(id));
            }

            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageProducts");
            return View(dataManager.ProductItem.GetProductItems());
        }
    }
}

using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using MyCompany.Domain.Entities;
using MyCompany.Service;

namespace MyCompany.Areas.Admin.Controllers
{
    [Area("Manager")]
    public class ProductController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        public ProductController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new Product() : dataManager.ProductItem.GetProductItemById(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(Product model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    model.TitleImagePath = titleImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }
                dataManager.ProductItem.SaveProductItem(model);
                return RedirectToAction(nameof(ProductController.Show), nameof(ProductController).CutController());
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Show()
        {
            return View(dataManager.ProductItem.GetProductItems());
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.ProductItem.DeleteProductItem(id);
            return RedirectToAction(nameof(ProductController.Show), nameof(ProductController).CutController());
        }
    }
}
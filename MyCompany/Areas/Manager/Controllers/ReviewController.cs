using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;

namespace MyCompany.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class Reviewontroller : Controller
    {
        private readonly DataManager dataManager;

        public Reviewontroller(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;

namespace MyCompany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleManagerController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly DataManager dataManager;

        public RoleManagerController(DataManager dataManager, UserManager<IdentityUser> userMgr)
        {
            this.dataManager = dataManager;
            userManager = userMgr;
        }

        public IActionResult Show()
        {
            ViewBag.Users = userManager.GetUsersInRoleAsync("manager");
            return View();
        }
    }
}
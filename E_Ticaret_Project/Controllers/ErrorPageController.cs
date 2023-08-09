using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Project.Controllers
{
    [AllowAnonymous]
    public class ErrorPageController : Controller
    {
        public IActionResult Error1(int code)
        {
            return View();
        }

        [HttpPost]
        public IActionResult HomePage()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}

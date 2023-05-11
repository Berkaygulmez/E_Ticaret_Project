using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Project.Areas.AdminPanel.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

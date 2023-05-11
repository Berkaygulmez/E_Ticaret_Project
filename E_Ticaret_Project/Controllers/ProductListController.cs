using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Project.Controllers
{
    public class ProductListController : Controller
    {
        public IActionResult ProductList()
        {
            return View();
        }
    }
}

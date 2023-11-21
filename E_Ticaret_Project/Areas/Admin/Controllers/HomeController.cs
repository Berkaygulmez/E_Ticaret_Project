using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace E_Ticaret_Project.Areas.AdminPanel.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly MyDbContext _baglanti;

        public HomeController(MyDbContext context)
        {
            _baglanti = context;
        }
        public IActionResult Index()
        {
            List<Product> topProducts = _baglanti.Products.OrderByDescending(p => p.ProductViewCount)
                                                    .Take(4)
                                                    .ToList();
            return View(topProducts);
        }


    }
}

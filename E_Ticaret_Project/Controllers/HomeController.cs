using E_Ticaret_Project.Models;
using E_Ticaret_Project.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _baglanti;
        public HomeController(ILogger<HomeController> logger, MyDbContext  context)
        {
            _logger = logger;
            _baglanti = context;
        }

        public IActionResult Index()
        {
            
            var productlist = _baglanti.Products.ToList();
            var categorylist = _baglanti.Categories.ToList(); // Burada ürünlerin kategorilerini getirdik
            return View(productlist);
        }

    }
}

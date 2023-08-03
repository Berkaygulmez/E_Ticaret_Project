using E_Ticaret_Project.Models;
using E_Ticaret_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace E_Ticaret_Project.Controllers
{
    [AllowAnonymous]
    public class ProductListController : Controller
    {
        private readonly MyDbContext _baglanti;

        public ProductListController(MyDbContext context)
        {
            _baglanti = context;
        }

        public IActionResult ProductList(int id) //tamam id dedik şimdi çalışır dene
        {
            var productsWithImagesAndCategory = _baglanti.Products
         .Where(p => p.CategoryID == id)
         .Include(p => p.ProductImage)
         .Include(p => p.Category)
         .ToList();

            return View(productsWithImagesAndCategory);
        }
        //public List<Product> GetProductsByCategoryId(int categoryId)
        //{
        //    return _baglanti.Products.Where(p => p.CategoryID == categoryId).ToList();
        //}
    }
}

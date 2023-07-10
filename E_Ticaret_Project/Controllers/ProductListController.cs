using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace E_Ticaret_Project.Controllers
{
    public class ProductListController : Controller
    {
        private readonly MyDbContext _baglanti;

        public ProductListController(MyDbContext context)
        {
            _baglanti = context;
        }

        public IActionResult ProductList(int id) //tamam id dedik şimdi çalışır dene
        {
            var kategoriİsimleri = _baglanti.Categories.ToList(); //sebebini hala net çözemedim ama bu şekilde yapılıyor :)

            var products = _baglanti.Products.Where(p => p.CategoryID == id).ToList();

            //if (products.Count() == 0) //güzel oldu ama ürün bulamayınca öyle yapmasın 
            //{
            //    // Ürün bulunamadıysa, hata mesajı gösterebilir veya başka bir işlem yapabilirsiniz
            //    return NotFound("Ürün bulunamadı.");
            //}

            return View(products);
        }
        //public List<Product> GetProductsByCategoryId(int categoryId)
        //{
        //    return _baglanti.Products.Where(p => p.CategoryID == categoryId).ToList();
        //}
    }
}

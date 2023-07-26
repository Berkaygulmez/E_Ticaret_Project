using E_Ticaret_Project.Migrations;
using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace E_Ticaret_Project.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly MyDbContext _baglanti;

        public ProductDetailsController(MyDbContext context)
        {
            _baglanti = context;
        }

        public IActionResult Index(int id)
        {
            Product product = new Product(); //newledik

            // ID'yi kullanarak ilgili ürünü veritabanından çekmek
            product = _baglanti.Products.Where(p => p.ProductID == id).FirstOrDefault();

            if (product == null)
            {
                // Ürün bulunamadıysa, hata mesajı gösterebilir veya başka bir işlem yapabilirsiniz
                return NotFound("Ürün bulunamadı.");
            }

            // Ürün bilgilerini Model'e ekleyerek view'e geçiş yapma
            return View(product);
            
        }
        
    }
    
}

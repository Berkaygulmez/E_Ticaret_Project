using E_Ticaret_Project.Migrations;
using E_Ticaret_Project.Models;
using E_Ticaret_Project.ViewModels;
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
            // ID'yi kullanarak ilgili ürünü veritabanından çekmek
          
            var product = new ProductandProductImage
            {
                //Gelen ürünün "Product" özelliği ürün bilgilerini içerirken, "ProductImages" liste özelliği o ürüne ait görsellerin listesini içerecektir.
                Product = _baglanti.Products.FirstOrDefault(p => p.ProductID == id), 
                ProductImages = _baglanti.ProductImages.Where(pi => pi.ProductID == id).ToList() 
            };


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

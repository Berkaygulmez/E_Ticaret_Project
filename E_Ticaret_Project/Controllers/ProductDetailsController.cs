using E_Ticaret_Project.Migrations;
using E_Ticaret_Project.Models;
using E_Ticaret_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace E_Ticaret_Project.Controllers
{
    [AllowAnonymous]
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
                ProductImageList = _baglanti.ProductImages.Where(pi => pi.ProductID == id).ToList()
            };



            // bu sayede Ürüne her tıklandığında o ürünün görüntüleme saysını bir artırıp güncelleyebileceğiz
            if (product != null && product.Product != null)
            {
                product.Product.ProductViewCount++;
                _baglanti.Products.Update(product.Product);
                _baglanti.SaveChanges();
            }

            ViewBag.ProductViewCount = product.Product.ProductViewCount;

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

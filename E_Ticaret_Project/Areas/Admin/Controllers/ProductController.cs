using E_Ticaret_Project.Migrations;
using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace E_Ticaret_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly MyDbContext _baglanti;

        public ProductController(MyDbContext context)
        {
            _baglanti = context;
        }

        public IActionResult Product()
        {
            return View();
        }

        //Bu methodda Product sayfasındaki datatable veri gönderiyoruz, return olarak json gönderiyoruz
        [HttpGet]
        public IActionResult ProductList()
        {
            var productList = _baglanti.Products.ToList(); //normal verileri çektim
            return Json(productList); //json formatında gönderdim
        }

        [HttpGet]
        public JsonResult GetProductById(int id)
        {
            var tekUrunVerisi = _baglanti.Products.Where(x => x.ProductID == id).FirstOrDefault();
            return Json(tekUrunVerisi); //json formatında gönderdim
        }

        [HttpPost]
        public JsonResult ProductAdd(Product product)
        {
            _baglanti.Products.Add(product);
            _baglanti.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult ProductUpdate(Product data)
        {
            _baglanti.Products.Update(data);
            _baglanti.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult ProductDelete(int ProductID)
        {
            var silinecekUrun = _baglanti.Products.Find(ProductID);

            _baglanti.Products.Remove(silinecekUrun);
            _baglanti.SaveChanges();

            return Json(new { success = true });
        }

    }
}

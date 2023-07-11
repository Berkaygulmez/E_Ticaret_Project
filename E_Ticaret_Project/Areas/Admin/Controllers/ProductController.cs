//using E_Ticaret_Project.Migrations;
using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            //Product sayfası yüklenirken en başta kategorilerimi markalarımı modellerimi ekledim buraya
            //Kategoriler
            List<Category> kategoriler = _baglanti.Categories.Select(x => new Category { CategoryID = x.CategoryID, CategoryName = x.CategoryName }).ToList();
            ViewBag.Kategoriler = kategoriler;

            //Markalar
            List<Trademark> markalar = _baglanti.Trademarks.Select(x => new Trademark { TrademarkID = x.TrademarkID, TrademarkName = x.TrademarkName, CategoryID = x.CategoryID }).ToList();
            ViewBag.Markalar = markalar;

            //Modeller
            List<Version> modeller = _baglanti.Versions.Select(x => new Version { VersionID = x.VersionID, VersionName = x.VersionName, TrademarkID = x.TrademarkID }).ToList();
            ViewBag.Modeller = modeller;

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

using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace E_Ticaret_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TrademarkController : Controller
    {
        private readonly MyDbContext _baglanti;

        public TrademarkController(MyDbContext context)
        {
            _baglanti = context;
        }

        public IActionResult Trademark()
        {
            // bu linq sorgusu ile category tablosundan sadece category ıd ve category name'i çektiğimizi demeye çalışıyor.
            List<Category> kategoriler = _baglanti.Categories.Select(x => new Category { CategoryID = x.CategoryID, CategoryName = x.CategoryName }).ToList();

            ViewBag.Kategoriler = kategoriler;

            return View();
        }

        //Bu methodda Trademark sayfasındaki datatable veri gönderiyoruz, return olarak json gönderiyoruz
        [HttpGet]
        public IActionResult TrademarkList()
        {
            var TrademarkList = _baglanti.Trademarks.ToList(); //normal verileri çektim
            return Json(TrademarkList); //json formatında gönderdim
        }

        [HttpGet]
        public JsonResult GetTrademarkById(int id)
        {
            var tekMarkaVerisi = _baglanti.Trademarks.Where(x => x.TrademarkID == id).FirstOrDefault();
            return Json(tekMarkaVerisi); //json formatında gönderdim
        }

        [HttpPost]
        public JsonResult TrademarkAdd(Trademark Trademark)
        {
            _baglanti.Trademarks.Add(Trademark);
            _baglanti.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult TrademarkUpdate(Trademark data)
        {
            _baglanti.Trademarks.Update(data);
            _baglanti.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult TrademarkDelete(int TrademarkID)
        {
            var silinecekMarka = _baglanti.Trademarks.Find(TrademarkID);

            _baglanti.Trademarks.Remove(silinecekMarka);
            _baglanti.SaveChanges();

            return Json(new { success = true });
        }

    }
}

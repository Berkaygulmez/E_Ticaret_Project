using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace E_Ticaret_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ModelController : Controller
    {
        private readonly MyDbContext _baglanti;

        public ModelController(MyDbContext context)
        {
            _baglanti = context;
        }

        public IActionResult Model()
        {
            List<Category> kategoriler = _baglanti.Categories.Select(x => new Category { CategoryID = x.CategoryID, CategoryName = x.CategoryName }).ToList();

            ViewBag.Kategoriler = kategoriler;
            // bu linq sorgusu ile marka tablosundan sadece marka ıd ve marka name'i çektiğimizi demeye çalışıyor.
            List<Trademark> markalar = _baglanti.Trademarks.Select(x => new Trademark { TrademarkID = x.TrademarkID, TrademarkName = x.TrademarkName }).ToList();

            ViewBag.Markalar = markalar;

            return View();
        }

        //Bu methodda Model sayfasındaki datatable veri gönderiyoruz, return olarak json gönderiyoruz
        [HttpGet]
        public IActionResult ModelList()
        {
            var ModelList = _baglanti.Models.ToList(); //normal verileri çektim
            return Json(ModelList); //json formatında gönderdim
        }

        [HttpGet]
        public JsonResult GetModelById(int id)
        {
            var tekModelVerisi = _baglanti.Models.Where(x => x.ModelID == id).FirstOrDefault();
            return Json(tekModelVerisi); //json formatında gönderdim
        }

        [HttpPost]
        public JsonResult ModelAdd(Model Model)
        {
            _baglanti.Models.Add(Model);
            _baglanti.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult ModelUpdate(Model data)
        {
            _baglanti.Models.Update(data);
            _baglanti.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult ModelDelete(int ModelID)
        {
            var silinecekMarka = _baglanti.Models.Find(ModelID);

            _baglanti.Models.Remove(silinecekMarka);
            _baglanti.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult GetMarkalarByCategory(int categoryId)
        {
            // Kategoriye göre markaları filtreleyin
            List<Trademark> markalar = _baglanti.Trademarks
                .Where(x => x.CategoryID == categoryId)
                .Select(x => new Trademark { TrademarkID = x.TrademarkID, TrademarkName = x.TrademarkName })
                .ToList();

            // Partial view'e markaları gönderin
            return PartialView("_MarkalarPartial", markalar);
        }


    }
}

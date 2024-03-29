﻿using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace E_Ticaret_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class VersionController : Controller
    {
        private readonly MyDbContext _baglanti;

        public VersionController(MyDbContext context)
        {
            _baglanti = context;
        }

        public IActionResult Version()
        {
            List<Category> kategoriler = _baglanti.Categories.Select(x => new Category { CategoryID = x.CategoryID, CategoryName = x.CategoryName }).ToList();
            ViewBag.Kategoriler = kategoriler;

            // bu linq sorgusu ile marka tablosundan sadece marka ıd ve marka name'i çektiğimizi demeye çalışıyor.
            List<Trademark> markalar = _baglanti.Trademarks.Select(x => new Trademark { TrademarkID = x.TrademarkID, TrademarkName = x.TrademarkName, CategoryID = x.CategoryID }).ToList();
            ViewBag.Markalar = markalar;

            return View();
        }

        //Bu methodda Model sayfasındaki datatable veri gönderiyoruz, return olarak json gönderiyoruz
        [HttpGet]
        public IActionResult VersionList()
        {
            var modelList = _baglanti.Versions.Join(_baglanti.Trademarks, version => version.TrademarkID, trademark => trademark.TrademarkID, (version, trademark) => new
           {
               version.VersionID,
               version.VersionName,
               TrademarkName = trademark.TrademarkName
           }).ToList(); //normal verileri çektim

            return Json(modelList); //json formatında gönderdim
        }

        [HttpGet]
        public JsonResult GetVersionById(int id)
        {
            var tekModelVerisi = _baglanti.Versions.Where(x => x.VersionID == id).FirstOrDefault();
            return Json(tekModelVerisi); //json formatında gönderdim
        }

        [HttpPost]
        public JsonResult VersionAdd(Version Model)
        {
            _baglanti.Versions.Add(Model);
            _baglanti.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult VersionUpdate(Version data)
        {
            _baglanti.Versions.Update(data);
            _baglanti.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult VersionDelete(int VersionID)
        {
            var silinecekMarka = _baglanti.Versions.Find(VersionID);

            _baglanti.Versions.Remove(silinecekMarka);
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

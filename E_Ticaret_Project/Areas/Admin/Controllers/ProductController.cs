﻿//using E_Ticaret_Project.Migrations;
using E_Ticaret_Project.Helpers;
using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_Ticaret_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly MyDbContext _baglanti;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(MyDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _baglanti = context;
            _webHostEnvironment = webHostEnvironment;
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
            List<E_Ticaret_Project.Models.Version> modeller = _baglanti.Versions.Select(x => new E_Ticaret_Project.Models.Version { VersionID = x.VersionID, VersionName = x.VersionName, TrademarkID = x.TrademarkID }).ToList();
            ViewBag.Modeller = modeller;

            return View();
        }

        //Bu methodda Product sayfasındaki datatable veri gönderiyoruz, return olarak json gönderiyoruz
        [HttpGet]
        public IActionResult ProductList()
        {
            //burda bildiğin product.tolist yapıyoruz aslında ama farklı olarak veriler çekicez diğer tabloda. Id yerine Name i yazsın diye.
            var productList = _baglanti.Products
           .Join(_baglanti.Categories,
                 product => product.CategoryID,
                 category => category.CategoryID,
                 (product, category) => new { product, category })
           .Join(_baglanti.Trademarks,
                 pc => pc.product.TrademarkID,
                 trademark => trademark.TrademarkID,
                 (pc, trademark) => new { pc.product, pc.category, trademark })
           .Join(_baglanti.Versions,
                 pct => pct.product.VersionID,
                 version => version.VersionID,
                 (pct, version) => new
                 {
                     ProductID = pct.product.ProductID,
                     ProductName = pct.product.ProductName,
                     ProductPrice = pct.product.ProductPrice,
                     ProductDescription = pct.product.ProductDescription,
                     CategoryName = pct.category.CategoryName,
                     TrademarkName = pct.trademark.TrademarkName,
                     VersionName = version.VersionName
                 })
           .ToList();

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

        //hiçbir şey yazmazsan zaten get demektir
        public IActionResult AddProductImage(int id)
        {
            ViewBag.UrunID = id;

            var products = _baglanti.ProductImages.Where(p => p.ProductID == id).ToList(); //şimdi yüklenen fotoğraflar o üründe gözüksün ana sayfada. daha sonrada fotoğraf sil güncelle felanda yapabilirsin. tamam uğraşıyim bbbai

            return View(products);
        }

        [HttpPost] // bu sadece addProductImage post olduğu zaman çalışır olay bu kadar :)
        public IActionResult AddProductImage(int id, ProductImage ProductImage, IFormFile ProductImageUrl)
        {
            if (ProductImageUrl != null && ProductImageUrl.Length > 0)
            {
                ImageSaveMethod ısm = new ImageSaveMethod(_webHostEnvironment);
                string fotografUrl = ısm.FotografEkle(ProductImageUrl, "Image/ProductImage");

                // Veritabanına kaydetme işlemi
                ProductImage.ProductID = id; //bunu yazmayı unutmuşsun dene şimdi çalışır
                ProductImage.ProductImageUrl = fotografUrl;

                _baglanti.ProductImages.Add(ProductImage);
                _baglanti.SaveChanges();
            }     
            //verileri burada yani post işlemi yaparken gönderiyordun bu doğru değil
            return View(); 
        }

    }
}

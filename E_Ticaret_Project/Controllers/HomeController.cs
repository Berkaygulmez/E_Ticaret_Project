using E_Ticaret_Project.Models;
using E_Ticaret_Project.ViewComponents;
using E_Ticaret_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret_Project.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _baglanti;
        public HomeController(ILogger<HomeController> logger, MyDbContext context)
        {
            _logger = logger;
            _baglanti = context;
        }

        public IActionResult Index()
        {
            HomeModel model = new HomeModel();
            model.Products = _baglanti.Products.ToList();
            model.TopViewProduct = _baglanti.Products.OrderByDescending(p => p.ProductViewCount)
                                                    .Take(4)
                                                    .ToList();
            model.GetSuggestion = _baglanti.Products.Where(x => x.Suggestion == true).ToList();
            model.Categories = _baglanti.Categories.ToList(); // Burada ürünlerin kategorilerini getirdik
            model.Trademarks = _baglanti.Trademarks.ToList();
            model.Version = _baglanti.Versions.ToList();



            ViewBag.TotalProductPiece = model.Products.Count();

            //daha güzel yöntemler vardır ama bende çok iyi bilmiyorum şimdi gidip productımage tablosunu komple çekicez
            model.ProductImages = _baglanti.ProductImages.ToList();


            var sonEklenenSliderID = 0;
            if (_baglanti.HomeSliders.Count() > 0) //içinde veri var mı diye bakıyorum çünküüüüü;
            {
                sonEklenenSliderID = _baglanti.HomeSliders.Max(y => y.SliderID); //Sen bunu müşteriye sattığında ilk kez veritabanı oluşturacak ve dolayısıyla içinde hiç veri olmayacak.
                                                                                 //tabloda hiç veri yokken max aramaya çalışırsa hata verir
                                                                                 //o yüzden eğer içinde veri varsa max çalışmalı veri yoksa yani 0 sa o zaman hiç çalışmasın burası sorun değil :)
                var sonEklenenSlider = _baglanti.HomeSliders.Where(x => x.SliderID == sonEklenenSliderID).FirstOrDefault();

                ViewBag.SliderImageName = sonEklenenSlider.SliderPhotoName;


                model.HomeSliders = _baglanti.HomeSliders.Where(x => x.SliderID != sonEklenenSliderID).ToList();
            }


            return View(model);
        }


        public IActionResult Search(string q)
        {
            List<Product> searchResults = _baglanti.Products
                .Where(u => u.ProductName.Contains(q))
                .ToList();

            return Json(searchResults);
        }

        [HttpGet]
        public IActionResult SonProduct(int id)
        {

            var product = _baglanti.Products.Find(id);

            var categoryId = product.CategoryID; // Ürünün kategori ID'si
            var category = _baglanti.Categories.Find(categoryId); // Kategori nesnesini çek
            var categoryName = category.CategoryName; // Kategori adını al


            var data = new
            {
                ProductId = product.ProductID,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductPrice = product.ProductPrice,
                CategoryName = categoryName
            };

            // JSON olarak döndür
            return Json(data);
        }
    }
}
//ben buraya ekledim bunun bir sayfası yok her controllerin bir sayfası olmak zorunda değil ben ajaxla buraya istek atıyorum bana ürünü veriyor
//biz her zaman veritabanında nasıl veriler varsa onu çekiyoruz ama şunu yapabilmemiz lazım mesela 
//ürün adını getir (zaten aynı tablo)
//ürün kategori adını getir
//ürün görsellerini liste şeklinde getir (zor:)

//ve bunları return json data ile göndermen lazım anladın mı, her seferinde product.tolist veya find işimizi çözmüyor tamam denerim

//şöyle bir kopya vereyim    bir değişken tanımlayacaksın var data olsun onun elemanlarını tanımlayacaksın dizi şeklinde sonra o elemanların içini istediğin veriler ile dolduracaksın bu biraz zor olacak senden şimdilik sadece ürün adı ve ürün kategori adını istiyorum başka hiçbir şey getirme. sonra bu bilgileri html de yaz zaten ürün adını yazmışım kopyası hazır :) tamamdır <3


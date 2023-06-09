﻿using E_Ticaret_Project.Models;
using E_Ticaret_Project.ViewComponents;
using E_Ticaret_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _baglanti;
        public HomeController(ILogger<HomeController> logger, MyDbContext  context)
        {
            _logger = logger;
            _baglanti = context;
        }

        public IActionResult Index()
        {
            HomeModel model = new HomeModel();
            model.Products = _baglanti.Products.ToList();
            model.Categories = _baglanti.Categories.ToList(); // Burada ürünlerin kategorilerini getirdik
            model.Trademarks = _baglanti.Trademarks.ToList();
            model.Version = _baglanti.Versions.ToList();

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

    }
}

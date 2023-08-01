using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using E_Ticaret_Project.Helpers;

namespace E_Ticaret_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly MyDbContext _baglanti;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SliderController(MyDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _baglanti = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Slider()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SliderList()
        {
            var sliderList = _baglanti.HomeSliders.ToList(); //normal verileri çektim
            return Json(sliderList); //json formatında gönderdim
        }

        [HttpGet]
        public JsonResult GetSliderById(int id)
        {
            var tekSliderVerisi = _baglanti.HomeSliders.Where(x => x.SliderID == id).FirstOrDefault();
            return Json(tekSliderVerisi); //json formatında gönderdim
        }

        [HttpPost]
        public JsonResult SliderAdd(HomeSlider homeSlider, IFormFile sliderPhoto)
        {
            if (sliderPhoto != null && sliderPhoto.Length > 0)
            {


                ImageSaveMethod ısm = new ImageSaveMethod(_webHostEnvironment);
                string fotografAdi = ısm.FotografEkle(sliderPhoto, "Image/SliderImage");

                // Veritabanına kaydetme işlemi
                homeSlider.SliderPhotoName = fotografAdi;

                _baglanti.HomeSliders.Add(homeSlider);
                _baglanti.SaveChanges();
            }


            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult SliderUpdate(HomeSlider HomeSlider)
        {
            _baglanti.HomeSliders.Update(HomeSlider);
            _baglanti.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult SliderDelete(int SliderID)
        {
            var silinecekSlider = _baglanti.HomeSliders.Find(SliderID);

            if (silinecekSlider == null)
            {
                return Json(new { success = false, message = "Slider bulunamadı" });
            }

            if (silinecekSlider.SliderPhotoName != null) //Silinecek fotoğraf adı boşsa if içindeki kodlar çalışmasın :)
            {
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Image/SliderImage", silinecekSlider.SliderPhotoName);

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _baglanti.HomeSliders.Remove(silinecekSlider);
            _baglanti.SaveChanges();

            return Json(new { success = true });
        }


    }
}

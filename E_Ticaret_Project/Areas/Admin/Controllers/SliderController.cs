using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace E_Ticaret_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly MyDbContext _baglanti;

        public SliderController(MyDbContext context)
        {
            _baglanti = context;
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
        public JsonResult SliderAdd(HomeSlider homeSlider)
        {
            _baglanti.HomeSliders.Add(homeSlider);
            _baglanti.SaveChanges();

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

            _baglanti.HomeSliders.Remove(silinecekSlider);
            _baglanti.SaveChanges();

            return Json(new { success = true });
        }


    }
}

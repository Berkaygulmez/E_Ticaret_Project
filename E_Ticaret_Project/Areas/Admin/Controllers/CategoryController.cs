//using E_Ticaret_Project.Migrations;
using E_Ticaret_Project.Helpers;
using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret_Project.Areas.Admin.Controllers
{ 
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly MyDbContext _baglanti;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoryController(MyDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _baglanti = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Category()
        {
            return View();
        }

        //Bu methodda Category sayfasındaki datatable veri gönderiyoruz, return olarak json gönderiyoruz
        [HttpGet]
        public IActionResult CategoryList()
        {
            var categoryList = _baglanti.Categories.ToList(); //normal verileri çektim
            return Json(categoryList); //json formatında gönderdim
        }

        [HttpGet]
        public JsonResult GetCategoryById(int id)
        {
            var tekKategoriVerisi = _baglanti.Categories.Where(x => x.CategoryID == id).FirstOrDefault();
            return Json(tekKategoriVerisi); //json formatında gönderdim
        }

        [HttpPost]
        public JsonResult CategoryAdd(Category category)
        {
            _baglanti.Categories.Add(category);
            _baglanti.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult CategoryUpdate(Category data)
        {
            _baglanti.Categories.Update(data);
            _baglanti.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult CategoryDelete(int categoryID)
        {
            var silinecekKategori = _baglanti.Categories.Find(categoryID);

            _baglanti.Categories.Remove(silinecekKategori);
            _baglanti.SaveChanges();

            return Json(new { success = true });
        }

        public IActionResult AddCategoryImage(int id)
        {
            ViewBag.KategoriID = id;

            var categorys = _baglanti.Categories.Where(X=>X.CategoryID == id).FirstOrDefault();//şimdi yüklenen fotoğraflar o üründe gözüksün ana sayfada. daha sonrada fotoğraf sil güncelle felanda yapabilirsin. tamam uğraşıyim bbbai

            return View(categorys);
        }

        [HttpPost] // bu sadece addProductImage post olduğu zaman çalışır olay bu kadar :)
        public IActionResult AddCategoryImage(int id, Category CategoryImage2, IFormFile CategoryImage)
        {
            CategoryImage2 = _baglanti.Categories.Where(X => X.CategoryID == id).FirstOrDefault();

            if (CategoryImage != null && CategoryImage.Length > 0)
            {
                ImageSaveMethod ısm = new ImageSaveMethod(_webHostEnvironment);
                string fotografUrl = ısm.FotografEkle(CategoryImage, "Image/CategoryImage");

                // Veritabanına kaydetme işlemi
                CategoryImage2.CategoryID = id; //bunu yazmayı unutmuşsun dene şimdi çalışır
                CategoryImage2.CategoryImage = fotografUrl;

                _baglanti.Categories.Update(CategoryImage2);
                _baglanti.SaveChanges();
            }
     
            return RedirectToAction("AddCategoryImage", new { id = id });
        }




        [HttpPost]
        public JsonResult DeleteCategoryImage(int categoryID)
        {
            // Belirli bir Category kaydını veritabanından çek
            var category = _baglanti.Categories.FirstOrDefault(x => x.CategoryID == categoryID);

            if (category != null)
            {
                // CategoryImage'i sıfırla veya null yaparak silme işlemi gerçekleştirilir
                category.CategoryImage = null; // Veya category.CategoryImage = ""; gibi bir değer atayabilirsiniz

                // Değişiklikleri kaydet

                _baglanti.Categories.Update(category);
                _baglanti.SaveChanges();
            }

            return Json(new { success = true });// Kategori listesine yönlendirme yapılabilir
        }


        //[HttpPost]
        //public JsonResult VersionDelete(int VersionID)
        //{
        //    var silinecekMarka = _baglanti.Versions.Find(VersionID);

        //    _baglanti.Versions.Remove(silinecekMarka);
        //    _baglanti.SaveChanges();

        //    return Json(new { success = true });
        //}

    }
}

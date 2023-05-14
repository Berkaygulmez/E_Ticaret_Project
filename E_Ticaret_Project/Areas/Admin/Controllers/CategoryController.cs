//using E_Ticaret_Project.Migrations;
using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret_Project.Areas.Admin.Controllers
{ 
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly MyDbContext _baglanti;

        public CategoryController(MyDbContext context)
        {
            _baglanti = context;
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


    }
}

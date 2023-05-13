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


        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            _baglanti.Categories.Add(category);
            _baglanti.SaveChanges();

            return RedirectToAction();
        }


        [HttpPost]
        public IActionResult CategoryDelete(int categoryID)
        {
            var silinecekKategori = _baglanti.Categories.Find(categoryID);

            _baglanti.Categories.Remove(silinecekKategori);
            _baglanti.SaveChanges();

            return RedirectToAction("CategoryAdd");
        }

    }
}

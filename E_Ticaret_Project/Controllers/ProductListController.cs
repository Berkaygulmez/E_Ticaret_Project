using E_Ticaret_Project.Models;
using E_Ticaret_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Composition;
using System.Linq;

namespace E_Ticaret_Project.Controllers
{
    [AllowAnonymous]
    public class ProductListController : Controller
    {
        private readonly MyDbContext _baglanti;

        public ProductListController(MyDbContext context)
        {
            _baglanti = context;
        }

        public IActionResult ProductList(int id, int? min, int? max) //tamam id dedik şimdi çalışır dene
        {

            ProductandProductImage panda = new ProductandProductImage();

            if (min == null && max == null)
            {
                //sadece ürünleri ve kategorisini getirelim zaten bir ürünün bir kategorisi olacağı için burda sıkıntı çıkmaz
                panda.ProductList = _baglanti.Products
                    .Where(p => p.CategoryID == id)
                    .Include(p => p.Category)
                    .ToList();
            }
            else
            {
                //
                panda.ProductList = _baglanti.Products
                    .Where(p => p.CategoryID == id && p.ProductPrice >= min && p.ProductPrice <= max)
                    .Include(p => p.Category)
                    .ToList();
            }

            if (panda.ProductList.Count() > 0)
            {
                int maximumPrice = _baglanti.Products.Where(x => x.CategoryID == id).Max(p => p.ProductPrice);
                ViewBag.MaxPrice = maximumPrice;
            }
            else
            {
                //Viewbag boş olmaması için bunu yapıyoruz. hata almamak için.
                int maximumPrice = 10000;
                ViewBag.MaxPrice = maximumPrice;
            }

            panda.ProductImageList = _baglanti.ProductImages.ToList();

            return View(panda); //enfes dondurma :)
        }
        //public List<Product> GetProductsByCategoryId(int categoryId)
        //{
        //    return _baglanti.Products.Where(p => p.CategoryID == categoryId).ToList();
        //}
    }
}

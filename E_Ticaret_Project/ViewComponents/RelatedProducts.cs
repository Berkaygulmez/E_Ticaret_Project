using E_Ticaret_Project.Models;
using E_Ticaret_Project.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret_Project.ViewComponents
{
    public class RelatedProducts : ViewComponent
    {
        private readonly MyDbContext _baglanti;
        public RelatedProducts(MyDbContext context)
        {
            _baglanti = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {


            var randomProduct = _baglanti.Products.OrderBy(p => Guid.NewGuid()).FirstOrDefault();
            var productImage = _baglanti.ProductImages.FirstOrDefault(pi => pi.ProductID == randomProduct.ProductID);
            var category = _baglanti.Categories.FirstOrDefault(c => c.CategoryID == randomProduct.CategoryID);

            var productAndImage = new ProductandProductImage
            {
                Product = randomProduct,
                ProductImages = productImage,
                Category = category
            };

            return View(productAndImage);
        }


    }
}


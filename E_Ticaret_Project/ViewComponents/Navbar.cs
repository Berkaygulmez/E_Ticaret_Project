using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_Ticaret_Project.ViewComponents
{
    public class Navbar : ViewComponent
    {

        private readonly MyDbContext _baglanti;

        public Navbar(MyDbContext context)
        {
            _baglanti = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryList = _baglanti.Categories.ToList();

            //int userID = int.Parse(User.FindFirst(ClaimTypes.Role).Value);
            //var productpiece = _baglanti.Carts.Where(x => x.RegisterID == userID).Include(cart => cart.Product).ToList();
            //ViewBag.ProductPiece = productpiece;

            return View(categoryList);
        }

    }
}

using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace E_Ticaret_Project.ViewComponents
{
    public class Navbar : ViewComponent
    {

        private readonly MyDbContext _baglanti;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Navbar(MyDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _baglanti = context;
            _httpContextAccessor = httpContextAccessor; //bizim user nesnesini kullanmamızı sağlayan bir yapı enjekte ettik
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var newuser = _httpContextAccessor.HttpContext.User; //o yapıyı var user nesnesine atadık

            var cartList = _baglanti.Carts.ToList();

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                int userID = int.Parse(newuser.FindFirst(ClaimTypes.SerialNumber).Value); //burda eski User nesnesini değil yeni oluşturduğumuz user i kullandık dikkat et ilk harfi küçük yani aynı isimde ama karışmaz
                int productpiece = _baglanti.Carts.Where(x => x.RegisterID == userID).Select(x => x.Piece).Sum();  //kullanıcı adı oturumdaki kullanıcı adı olan kişinin satırlarındaki Piece değerleri toplamını alıyorum bu bize giriş yapan kullanıcının kaç ürün aldığını gösterecek. kaç satır veri var ona bakmıyoruz satırların içinde bir üründen birden fazla almış olabilir
                ViewBag.ProductPiece = productpiece;
            }
            return View(cartList);
        }

    }
}

using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace E_Ticaret_Project.Controllers
{
    public class OrderController : Controller
    {
        private readonly MyDbContext _baglanti;

        public OrderController(MyDbContext context)
        {
            _baglanti = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CompleteOrder()
        {
            //string userID = null; // Başlangıçta userID'yi null olarak ayarlayın

            //if (User.Identity.IsAuthenticated) //sisteme bir kullanıcı giriş yapmışmı diğer kontrolü
            //{
            //    var roleClaim = User.FindFirst(ClaimTypes.Role);
            //    if (roleClaim != null)  // KUllanıcı Role=İd (olarak tanımladık) değeri var mı diye kontrol ediyoruz.
            //    {
            //        userID = roleClaim.Value; // userID'yi roleClaim'den alınan değere ata
            //                                  // Gerekli işlemleri gerçekleştirin
            //    }
            //}

            int userID = int.Parse(User.FindFirst(ClaimTypes.SerialNumber).Value);

            var userCartItems = _baglanti.Carts.Where(c => c.RegisterID == Convert.ToInt64(userID)).ToList();

            if (userCartItems.Any())
            {
                // Kullanıcının sepetinde ürün varsa, sipariş oluşturun ve "Order" tablosuna taşıyın
                foreach (var cartItem in userCartItems)
                {
                    var orderItem = new Order
                    {
                        RegisterID = cartItem.RegisterID,
                        ProductID = cartItem.ProductID,
                        Piece = cartItem.Piece,
                    };

                    // Sipariş öğesini "Order" tablosuna ekleyin
                    _baglanti.Orders.Add(orderItem);
                }

                // Sepetteki tüm öğeleri "Cart" tablosundan kaldırın
                _baglanti.Carts.RemoveRange(userCartItems);

                // Veritabanında değişiklikleri kaydedin
                _baglanti.SaveChanges();
            }

            // Siparişi tamamladıktan sonra kullanıcıyı uygun sayfaya yönlendirin
            return RedirectToAction("Index", "Home");
        }
    }
}


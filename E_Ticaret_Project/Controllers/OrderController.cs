using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            // Kullanıcının sepetini bulun
            int RegisterID = 8;
            var userCartItems = _baglanti.Carts.Where(c => c.RegisterID == RegisterID).ToList();

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
            return RedirectToAction("OrderCompleted", "Order");
        }
    }
}


using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace E_Ticaret_Project.Controllers
{

    public class CartController : Controller
    {
        private readonly MyDbContext _baglanti;
        public CartController(MyDbContext context)
        {
            _baglanti = context;
        }

        public IActionResult Index()//buraya daha sonra giriş yapan kullanıcının id sini gireriz ona göre listeyi getirir şimdikik kalsın bakalım
        {
            //olabilir
            //sisteme otantike olan kullanıcının ID'si
            int userID = int.Parse(User.FindFirst(ClaimTypes.Role).Value); 

            var cartsWithProducts = _baglanti.Carts.Where(x=>x.RegisterID == userID).Include(cart => cart.Product).ToList();

            var ProductPiece = cartsWithProducts.Count();
            ViewBag.ProductPiece = ProductPiece;
            var CartToplam = cartsWithProducts.Sum(x=>x.Product.ProductPrice * x.Piece); 
            ViewBag.ToplamCart = CartToplam;

            return View(cartsWithProducts);
        }

        public IActionResult CartPay()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddToCart(int id, int quantity = 1)
        {
            int userID = int.Parse(User.FindFirst(ClaimTypes.Role).Value);
            try
            {

                Cart cart = new Cart { RegisterID = userID, ProductID = id, Piece = quantity };

                //adam cart ına aynı üründen eklemişmi diye bakıyorum
                var cartdaAyniUrunVarMı = _baglanti.Carts.Where(x => x.RegisterID == 8 && x.ProductID == id).ToList();

                if(cartdaAyniUrunVarMı.Count() > 0) //eklemişse burası çalışacak
                {

                    var existingCartItem = cartdaAyniUrunVarMı.First(); // İlk bulunan öğeyi alıyoruz, çünkü aynı üründen yalnızca bir kez ekleyebiliriz. 
                    existingCartItem.Piece += quantity; // Miktarı artırıyoruz.
                    _baglanti.Carts.Update(existingCartItem); // Varolan öğeyi güncelliyoruz.
                    _baglanti.SaveChanges();
                }
                else
                {
                    _baglanti.Carts.Add(cart);
                    _baglanti.SaveChanges();
                }


                TempData["SuccessMessage"] = "Ürün sepete eklendi.";

                return RedirectToAction("Index", "ProductDetails", new { id = id }); //ürünü sepete ekledikten sonra bu adrese gitsin
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun şekilde hata mesajı döndürebilirsiniz
                return BadRequest(new { message = "Hata oluştu: " + ex.Message });
            }
        }

        public IActionResult DeleteProduct(int productId)
        {
            // Ürünü veritabanından silme işlemi
            var cartItem = _baglanti.Carts.FirstOrDefault(cart => cart.Product.ProductID == productId);
            if (cartItem != null)
            {
                _baglanti.Carts.Remove(cartItem);
                _baglanti.SaveChanges();
            }

            return RedirectToAction("Index", "Cart"); // Silme işleminden sonra istediğiniz sayfaya yönlendirme
        }
    }
}

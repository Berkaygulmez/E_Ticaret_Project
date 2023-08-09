using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_Ticaret_Project.Controllers
{
    [AllowAnonymous]
    public class LogInController : Controller
    {
        private readonly MyDbContext _baglanti;
        public LogInController(MyDbContext context)
        {
            _baglanti = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Register register)
        {
            var user = _baglanti.Registers.FirstOrDefault(u => u.UserName == register.UserName); // bağlanı üzerinden register tablosundaki USERNAME'den verileri çeken LINQ sorgusu

            if (user != null)
            {
                if (user.LockoutEnd != null && user.LockoutEnd > DateTime.Now) //eğer kilit süresi şuandan uzunsa ve null değilse hesap kilitlendi uyarı mesajı verir
                {
                    ModelState.AddModelError("", "Hesabınız geçici olarak kilitlendi. Lütfen daha sonra tekrar deneyin.");
                    TempData["ErrorMessage"] = "Hesabınız geçici olarak kilitlendi. Lütfen daha sonra tekrar deneyin.";
                    return View();
                }

                if (user.Password == register.Password) // gelen şifreyle tabloda ki şifre aynıysa çalışır
                {
                    if (user.AccessFailedCount > 0) //deneme hakkı 0'dan büyükse deneme hakkını sıfırlar ve kaydeder.
                    {
                        user.AccessFailedCount = 0;
                        user.LockoutEnd = DateTime.MinValue;
                        _baglanti.SaveChanges();
                    }


                    var claims = new List<Claim>                        // claimler ile Otantike oldundu
                    { 
                        new Claim(ClaimTypes.Name,user.UserName),
                        new Claim(ClaimTypes.Role,user.RegisterID.ToString())
                    };
                    var useridentity = new ClaimsIdentity(claims, "a");
                    ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                    await HttpContext.SignInAsync(principal);

                    return RedirectToAction("Index", "Home");
                }
                else   // gelen şifreyle tabloda ki şifre aynı değilse çalışır.
                {
                    user.AccessFailedCount++; // deneme hakkını artırır ve 

                    if (user.AccessFailedCount >= 3) //3'ten büyük olduğunda kilitleme süresini 30 dakika uzatır.
                    {
                        user.LockoutEnd = DateTime.Now.AddMinutes(30);
                    }

                    _baglanti.SaveChanges();

                    ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
                    TempData["ErrorMessage"] = "Kullanıcı adı veya şifre yanlış.";
                    return View();
                }
            }
            ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
            TempData["ErrorMessage"] = "Kullanıcı adı veya şifre yanlış.";
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            //Çıkış Yap
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");

        }

    }
}


using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace E_Ticaret_Project.Controllers
{
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
        public IActionResult Index(Register register) //buraya niye farklı bişeyler yazdın ki?
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

                    return RedirectToAction("Index", "Home");
                }
                else   // gelen şifreyle tabloda ki şifre aynıysa değilse çalışır.
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
    }
}


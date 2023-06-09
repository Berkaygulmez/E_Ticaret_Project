﻿using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace E_Ticaret_Project.Controllers
{
    public class RegisterController : Controller
    {

        private readonly MyDbContext _baglanti;

        public RegisterController(MyDbContext context)
        {
            _baglanti = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Register model)
        {
            if (ModelState.IsValid)
            {
                // Veritabanına kaydetme işlemleri burada yapılabilir

                //var mailVarMı = sql e gidip mailadresi var mı diye bakacak linq kodu count dönderecek yani sayı

                //if mailVarMı > 0  dan büyükse kaydetmesin çünkü o mail adresi kullanılmış else ise kaydetsin kaydetme kodları zaten aşağıda
                if (_baglanti.Registers.Any(r => r.Mail == model.Mail))
                {
                    ModelState.AddModelError("", "Bu e-posta adresi zaten kullanımda.");
                    TempData["ErrorMessage"] = "Bu e-posta adresi zaten kullanımda.";
                    return RedirectToAction("Index");
                }

                if (_baglanti.Registers.Any(r => r.UserName == model.UserName))
                {
                    ModelState.AddModelError("", "Bu kullanıcı adı zaten kullanımda.");
                    TempData["ErrorMessage"] = "Bu kullanıcı adı zaten kullanımda.";
                    return RedirectToAction("Index");
                }

                _baglanti.Registers.Add(model);
                _baglanti.SaveChanges();

                // Kayıt işlemi başarılı olduğunda, giriş sayfasına yönlendirin
                return RedirectToAction("Index", "LogIn");
            }

            // ModelState.IsValid false olduğunda, hata mesajlarıyla birlikte kayıt sayfasını tekrar gösterin
            return View(model);
        }
    }
}

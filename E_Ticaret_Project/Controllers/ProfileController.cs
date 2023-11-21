using E_Ticaret_Project.Models;
using E_Ticaret_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace E_Ticaret_Project.Controllers
{
    public class ProfileController : Controller
    {
        private readonly MyDbContext _baglanti;

        public ProfileController(MyDbContext context)
        {
            _baglanti = context;
        }

        public IActionResult Index()
        {
            int userID = int.Parse(User.FindFirst(ClaimTypes.SerialNumber).Value);

            var register = _baglanti.Registers.Find(userID);
            var registerAddress = _baglanti.RegisterAddresses.Where(x => x.RegisterID == userID).ToList(); //o kullanıcıya ait tüm adreslerin listesini alıyorum

            var viewModel = new RegisterViewModel
            {
                Register = register,
                RegisterAddressList = registerAddress
            };
            return View(viewModel);
        }

        public ActionResult EditProfile() //bunu yapmışsın ama Index de hiçbir yerde kullanmamışsın ki
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditProfile(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
              //  int userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                // Kullanıcıyı veritabanından çek
                var user = _baglanti.Registers.FirstOrDefault(u => u.RegisterID == viewModel.Register.RegisterID);

                if (user != null)
                {
                    // Kullanıcının profil verilerini güncelle
                    user.RegisterID = viewModel.Register.RegisterID;
                    user.NameSurname = viewModel.Register.NameSurname;
                    user.UserName = viewModel.Register.UserName;
                    user.Mail = viewModel.Register.Mail;
                    // Diğer özellikleri güncellemeye devam edebilirsiniz

                    // Değişiklikleri kaydet
                    _baglanti.Registers.Update(user); // Registers yerine doğru DbSet adını kullanmalısınız
                    _baglanti.SaveChanges();

                    // Profil güncelleme başarılı oldu, başka bir sayfaya yönlendir
                    return RedirectToAction("Index", "Profile"); // Örneğin kullanıcının profilini gösteren bir sayfaya yönlendirebilirsiniz
                }
            }

            return View(viewModel); // Hata durumunda view'i tekrar gösterme
        }



        public ActionResult GetAddresses(int userId)
        {
            var addresses = _baglanti.RegisterAddresses.Where(ra => ra.RegisterID == userId).ToList();
            return PartialView("_AddressOptions", addresses);
        }
    }
}

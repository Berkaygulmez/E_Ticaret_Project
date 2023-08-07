using E_Ticaret_Project.Models;
using E_Ticaret_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace E_Ticaret_Project.Controllers
{
    public class ProfileController : Controller
    {
        private readonly MyDbContext _baglanti;

        public ProfileController(MyDbContext context)
        {
            _baglanti = context;
        }

        public IActionResult Index(int id)
        {
            var register = _baglanti.Registers.Find(id);
            var registerAddress = _baglanti.RegisterAddresses.Where(x => x.RegisterID == id).ToList(); //o kullanıcıya ait tüm adreslerin listesini alıyorum

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
                var register = _baglanti.Registers.Find(viewModel.Register.RegisterID); //kullanıcıyı buldun

                //kullanıcının bilgilerini güncelledin

                //foreach açtın kaç adres varsa o kadar listeyi döndün
                //adresi güncelledin



                //alt taraf yok yani :) 
                //var registerAddress = _baglanti.RegisterAddresses.FirstOrDefault(ra => ra.RegisterID == viewModel.Register.RegisterID);

                //if (register != null)
                //{
                //    register.NameSurname = viewModel.Register.NameSurname;
                //    register.UserName = viewModel.Register.UserName;
                //    register.Mail = viewModel.Register.Mail;

                //    if (registerAddress != null)
                //    {
                //        //registerAddress.Address = viewModel.RegisterAddress.Address;
                //    }

                //    _baglanti.SaveChanges();
                //    return RedirectToAction(); // İstenilen sayfaya yönlendirme
                //}
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

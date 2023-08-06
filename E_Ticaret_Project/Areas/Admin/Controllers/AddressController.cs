using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AddressController : Controller
    {
        //buraya Bağlantı gelicek fakat Model oluşturulurken bir sıkıntı yaşandı
        public IActionResult Address()
        {
            return View();
        }
    }
}

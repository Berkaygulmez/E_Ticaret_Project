using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Ticaret_Project.Areas.Admin.ViewComponents
{
    public class AdminNavbar : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View();
        }
    }
}

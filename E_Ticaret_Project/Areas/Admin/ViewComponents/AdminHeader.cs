using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Ticaret_Project.Areas.Admin.ViewComponents
{
    public class AdminHeader : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View();
        }
    }
}

using E_Ticaret_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret_Project.ViewComponents
{
    public class Navbar : ViewComponent
    {

        private readonly MyDbContext _baglanti;

        public Navbar(MyDbContext context)
        {
            _baglanti = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryList = _baglanti.Categories.ToList();

            return View(categoryList);
        }

    }
}

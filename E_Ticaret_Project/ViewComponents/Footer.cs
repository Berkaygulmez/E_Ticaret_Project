﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Ticaret_Project.ViewComponents
{
    public class Footer : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View();
        }

    }
}

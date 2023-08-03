using E_Ticaret_Project.Models;
using System.Collections.Generic;

namespace E_Ticaret_Project.ViewModels
{
    public class HomeModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }

        public List<Trademark> Trademarks { get; set; }

        public List<Version> Version { get; set; }
        public List<HomeSlider> HomeSliders { get; set; }
        public List<ProductImage> ProductImages { get; set; }

    }
}

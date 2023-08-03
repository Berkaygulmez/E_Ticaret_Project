using E_Ticaret_Project.Models;
using System.Collections.Generic;

namespace E_Ticaret_Project.ViewModels
{
    public class ProductandProductImage
    {
        public Product Product { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<Category> Categories { get; set; }

    }
}

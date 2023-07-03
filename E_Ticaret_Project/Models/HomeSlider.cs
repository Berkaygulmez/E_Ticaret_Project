using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace E_Ticaret_Project.Models
{
    public class HomeSlider
    {
        [Key]
        public int SliderID { get; set; }
        public string SliderPhotoName { get; set; } // Fotoğraf dosyası özelliği
        public string SliderImageUrl { get; set; }
        public string SliderImageDescription { get; set; }
        public string SliderTitle { get; set; }
    }
}

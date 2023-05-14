using System.ComponentModel.DataAnnotations;

namespace E_Ticaret_Project.Models
{
    public class HomeSlider
    {
        [Key]
        public int SliderID { get; set; }
        public string SliderImageUrl { get; set; }
        public string SliderImageDescription { get; set; }
    }
}

namespace E_Ticaret_Project.Models
{
    public class ProductImage
    {
        public int ProductImageID { get; set; }
        public int ProductID { get; set; }
        public string ProductImageUrl { get; set; }
        public Product product { get; set; }
    }
}

namespace E_Ticaret_Project.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int CategoryID { get; set; }  
        public Category Category { get; set; }
        public int TrademarkID { get; set; }
        public int VersionID { get; set; }
    }
}

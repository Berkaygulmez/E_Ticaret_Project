namespace E_Ticaret_Project.Models
{
    public class Model
    {
        public int ModelID { get; set; }
        public string ModelName { get; set; }
        public int TrademarkID { get; set; }
        public Trademark Trademark { get; set; }
    }
}

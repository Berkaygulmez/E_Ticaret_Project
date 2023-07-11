using System.ComponentModel.DataAnnotations;

namespace E_Ticaret_Project.Models
{
    public class Trademark
    {
        [Key]
        public int TrademarkID { get; set; }
        public string TrademarkName { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}

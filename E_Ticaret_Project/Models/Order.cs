using System.ComponentModel.DataAnnotations;

namespace E_Ticaret_Project.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int RegisterID { get; set; }
        public int ProductID { get; set; }
        public int Piece { get; set; }
        public Product Product { get; set; }
        public Register Register { get; set; }
    }
}

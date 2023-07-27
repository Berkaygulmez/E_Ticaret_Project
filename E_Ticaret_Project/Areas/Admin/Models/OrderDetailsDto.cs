namespace E_Ticaret_Project.Areas.Admin.Models
{
    public class OrderDetailsDto
    {
        public int OrderID { get; set; }
        public string ProductName { get; set; }
        public string NameSurname { get; set; }
        public int Piece { get; set; }
    }
}

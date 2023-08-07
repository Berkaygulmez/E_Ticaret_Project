using System.ComponentModel.DataAnnotations;

namespace E_Ticaret_Project.Models
{
    public class RegisterAddress
    {
        [Key]
        public int RegisterAddressID { get; set; }
        public int RegisterID { get; set; }
        public Register Register { get; set; }  
        public string Address { get; set; }

    }
}

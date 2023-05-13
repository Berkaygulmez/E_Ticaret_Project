using System.ComponentModel.DataAnnotations;

namespace E_Ticaret_Project.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}

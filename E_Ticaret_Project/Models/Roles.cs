using System.ComponentModel.DataAnnotations;

namespace E_Ticaret_Project.Models
{
    public class Roles

    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
}

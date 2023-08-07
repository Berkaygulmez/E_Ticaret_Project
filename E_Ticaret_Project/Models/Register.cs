using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace E_Ticaret_Project.Models
{
    public class Register
    {
        [Key]
        public int RegisterID { get; set; } 
        public string NameSurname { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string UserName { get; set; }
        public DateTime LockoutEnd { get; set; }
        public int AccessFailedCount { get; set; }

    }
}

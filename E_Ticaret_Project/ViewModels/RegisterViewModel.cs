using E_Ticaret_Project.Models;
using System.Collections.Generic;

namespace E_Ticaret_Project.ViewModels
{
    public class RegisterViewModel
    {
        public Register Register { get; set; }
        public List<RegisterAddress> RegisterAddressList { get; set; } //bir kullanıcının birden fazla adresi olacaksa liste gelmeli
    }

}

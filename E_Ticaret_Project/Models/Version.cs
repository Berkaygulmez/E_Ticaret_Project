using System.ComponentModel.DataAnnotations;

namespace E_Ticaret_Project.Models
{
    public class Version
    {
        [Key]
        public int VersionID { get; set; }
        public string VersionName { get; set; } 
        public int TrademarkID { get; set; }
        public Trademark Trademark { get; set; }
    }
}

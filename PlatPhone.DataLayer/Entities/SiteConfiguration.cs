using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PlatPhone.DataLayer
{
    /// <summary>
    /// تنظیمات سایت
    /// </summary>
    [Table("SiteConfiguration")]
    public class SiteConfiguration 
    {
        [Key]
        public string Key { get; set; }
        public string Value { get; set; }

    }
}

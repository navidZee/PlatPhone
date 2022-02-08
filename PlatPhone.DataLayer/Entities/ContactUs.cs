using PlatPhone.DataLayer.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatPhone.DataLayer
{
    [Table("ContactUs")]
    public class ContactUs : PublicAllTable
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Subject { get; set; }

        [StringLength(250)]
        public string Message { get; set; }
    }
}

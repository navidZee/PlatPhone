using PlatPhone.DataLayer.Entities.Base;
using PlatPhone.DataLayer.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatPhone.DataLayer
{
    [Table("User")]
    public class User : PublicAllTable
    {
        public User()
        {
        }

        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        [MinLength(6, ErrorMessage = "Password should be more than 6 charecters")]
        public string Password { get; set; }

     
        //public int AddressID { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }


        [StringLength(50)]
        public string Name { get; set; }


        [StringLength(50)]
        public string Family { get; set; }


        [StringLength(11)]
        public string Tell { get; set; }


        [StringLength(10)]
        public string PostalCode { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public RoleEnum Role { get; set; } = RoleEnum.Customer;

        public string UserAddress { get; set; }
    }
}

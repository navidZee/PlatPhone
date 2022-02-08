using PlatPhone.DataLayer.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatPhone.DataLayer
{
    /// <summary>
    /// دسته بندی محصولات
    /// </summary>
    [Table("Category")]
    public class Category : PublicAllTable
    {
        public int Parent { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string ImgName { get; set; }
        public bool IsDeleted { get; set; } = false;
        //public virtual ICollection<Discount> Discounts { get; set; }

        //public virtual ICollection<Product> Products { get; set; }
    }
}

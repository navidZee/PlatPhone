using PlatPhone.DataLayer.Entities.Base;
using PlatPhone.DataLayer.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatPhone.DataLayer
{
    [Table("Product")]
    public class Product : PublicAllTable
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(70)]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        [Required]
        public string Description { get; set; }
        [StringLength(150)]
        public string Keyword { get; set; }
        
        [Required]
        public decimal Price { get; set; }
       
        public string ImageUrl { get; set; }
        //موجودی
        [Required]
        public int Inventory { get; set; }
        public byte Discount { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<InvoiceDetail> FactorDetails { get; set; }
    }
}

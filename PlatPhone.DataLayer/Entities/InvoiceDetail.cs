using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatPhone.DataLayer
{
    [Table("InvoiceDetail")]
    public class InvoiceDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public float Count { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public int InvoiceHeader_Id { get; set; }
        [ForeignKey("InvoiceHeader_Id")]    
        public virtual InvoiceHeader InvoiceHeader { get; set; }

        public int Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public virtual Product Product { get; set; }

    }
}

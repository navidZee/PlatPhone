using PlatPhone.DataLayer.Entities.Base;
using PlatPhone.DataLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatPhone.DataLayer
{
    [Table("InvoiceHeader")]
    public class InvoiceHeader : PublicAllTable
    {       
        public int User_Id { get; set; }
        [ForeignKey("User_Id")]
        public virtual User User { get; set; }
        public int FactorCode { get; set; }
        public RequestLevel RequestLevel { get; set; }
        public bool IsFinaly { get; set; }
        public Checkout Checkout { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}


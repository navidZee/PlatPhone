using PlatPhone.DataLayer.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatPhone.DataLayer
{
    [Table("ClientMenuLink")]
    public class ClientMenuLink : PublicAllTable
    {
        public string Title { get; set; }
        
        public string Content { get; set; }
    }
}

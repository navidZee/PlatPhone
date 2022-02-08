using PlatPhone.DataLayer.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatPhone.DataLayer
{
    public class News : PublicAllTable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string KeyWord { get; set; }
        public string Image { get; set; }
    }
}

using PlatPhone.DataLayer.Entities.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatPhone.DataLayer
{
    [Table("Image")]
    public class Image : PublicAllTable
    {

        public int Type { get; set; }

        public int Itemid { get; set; }

        public string Url { get; set; }

        [StringLength(50)]
        public string Alt { get; set; }

        [StringLength(50)]
        public string Title { get; set; }
    }


    public enum TypeImage
    {
        [Description("اخبار")]
        News,
        Article,
        Product
    }

}

using PlatPhone.DataLayer.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatPhone.DataLayer
{
    /// <summary>
    /// نظرات
    /// </summary>
    [Table("Comment")]
    public class Comment : PublicAllTable
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Subject { get; set; } = "not";

        public bool IsConfirmed { get; set; } = false;
        public bool IsRejected { get; set; } = false;

        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(400)]
        public string Text { get; set; }

        public int Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public Product Product { get; set; }
    }
}

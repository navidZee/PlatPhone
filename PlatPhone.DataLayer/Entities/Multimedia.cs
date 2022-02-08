using PlatPhone.DataLayer.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatPhone.DataLayer
{
    public class Multimedia : PublicAllTable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public string Cover { get; set; }
        public MultimediaType MultimediaType { get; set; }

        [NotMapped]
        public string FileForEdit { get; set; }
    }

    public enum MultimediaType : byte
    {
        Image = 1,//عکس
        Video = 2 // ویدئو
    }

}

using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
namespace PlatPhone.Extention
{
    public static class File
    {
        /// <summary>
        /// ذخیره فایل
        /// </summary>
        /// <param name="File">فایل</param>
        /// <param name="DirectoryName">پوشه ذخیره فایل - {Uploads/UserImage} </param>
        /// <param name="ProgrammerFileName">- نام فایلی ک برنامه نویس میخواهد سیو بشود - کاربر در ادیت عکس</param>

        public async static Task<string> CreateFile(IFormFile File, string DirectoryName, string ProgrammerFileName)
        {
            string ImageName = ProgrammerFileName == null || ProgrammerFileName == "" || ProgrammerFileName == "null" ||

                Path.GetExtension(ProgrammerFileName) != Path.GetExtension(File.FileName)
                || ProgrammerFileName.Contains("default-avatar.jpg") ? Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(File.FileName) : ProgrammerFileName;

            string SavePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{DirectoryName}", ImageName);
            using (var stream = new FileStream(SavePath, FileMode.Create))
            {
                await File.CopyToAsync(stream);
            }
            return ImageName;
        }

        public async static Task<string> UpdateFile(IFormFile File, string DirectoryName, string ImageName, string Path)
        {
            DeleteFile(Path);
            return await CreateFile(File, DirectoryName, ImageName);
        }

        public static void DeleteFile(string Path)
        {
            if (!Path.Contains("default-avatar.jpg") && System.IO.File.Exists(Path))
                System.IO.File.Delete(Path);
        }
    }
}

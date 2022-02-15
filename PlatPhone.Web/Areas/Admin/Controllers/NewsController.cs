using FloristStore.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using PlatPhone.Auth;
using PlatPhone.DataLayer;
using PlatPhone.DataLayer.Enum;
using PlatPhone.DataLayer.Service;
using PlatPhone.Extention;
using PlatPhone.Providers;
using System.Linq;
using System.Net;

namespace PlatPhone.Areas.Admin.Controllers
{
    [SessionAuthorize(true, RoleEnum.Admin)]

    public class NewsController : BaseController
    {
        private DatabaseRepository<News> newsService;
        public NewsController(DatabaseRepository<News> newsService)
        {
            this.newsService = newsService;
        }

        // GET: Admin/Product
        public IActionResult Index() => View();
        public PartialViewResult GetListNews() => PartialView($"{StatcPath.PartialViewPath}News/_ListNews.cshtml", newsService.GetAll().Where(g => !g.IsDeleted).OrderByDescending(x => x.CreateDate).ToList());
        public PartialViewResult GetAddNews() => PartialView($"{StatcPath.PartialViewPath}News/_AddNews.cshtml");
        public PartialViewResult GetEditNews(int id) => PartialView($"{StatcPath.PartialViewPath}News/_EditNews.cshtml", newsService.Read(id));
        public PartialViewResult GetDisplayNews(int id) => PartialView($"{StatcPath.PartialViewPath}News/_DisplayNews.cshtml", newsService.Read(id));
        public HttpStatusCode ConfirmDelete(int id)
        {
            var x = newsService.Read(id);
            x.IsDeleted = true;
            newsService.Update(x);
            newsService.Save();
            return HttpStatusCode.OK;
        }

        [HttpPost]
        public string Operation(NewsDto newsDto)
        {
            string imageUrl;
            News temp = new News();
            temp.Id = newsDto.Id;
            temp.Title = newsDto.Title;
            temp.Description = newsDto.Description;
            temp.ShortDescription = newsDto.ShortDescription;
            temp.KeyWord = newsDto.KeyWord;
            temp.Image = newsDto.Image;


            if (temp.Id == 0)
            {
                if (newsDto.ImageFile is not null)
                {
                    if (Validation.ValidatorFile(newsDto.ImageFile, 0, new string[] {
                            "image/jpg", "image/jpeg", "image/png"}) == HttpStatusCode.NotAcceptable)
                        return HttpStatusCode.NotAcceptable.ToString();
                    temp.Image = PlatPhone.Extention.File.CreateFile(newsDto.ImageFile, "Image/Uploade/NewsImage/", "").Result;
                }
                newsService.Create(temp);
                newsService.Save();
            }
            else
            {
                if (newsDto.ImageFile is not null)
                {
                    if (Validation.ValidatorFile(newsDto.ImageFile, 0, new string[] { "image/jpg", "image/jpeg", "image/png" }) == HttpStatusCode.NotAcceptable)
                        return HttpStatusCode.NotAcceptable.ToString();

                    temp.Image = Extention.File.UpdateFile(newsDto.ImageFile, "Image/Uploade/NewsImage/", "", temp.Image).Result;
                }
                newsService.Update(temp);
                ViewBag.msg = newsService.Save();
                return HttpStatusCode.OK.ToString();
            }

            return HttpStatusCode.OK.ToString();
        }
    }
}
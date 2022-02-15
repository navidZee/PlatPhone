using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayer.Enum;
using DataLayer.Service;
using FloristStore.Auth;
using FloristStore.Models.Dtos;
using FloristStore.Providers;

namespace FloristStore.Areas.Admin.Controllers
{
    [SessionAuthorize(true, RoleEnum.Admin)]

    public class NewsController : Controller
    {
        DatabaseRepository<News> newsTable = new DatabaseRepository<News>(new EF());

        // GET: Admin/Product
        public ActionResult Index() => View();
        public PartialViewResult GetListNews() => PartialView($"{StatcPath.PartialViewPath}News/_ListNews.cshtml", newsTable.GetAll().Where(g => !g.IsDeleted).OrderByDescending(x => x.CreateDate).ToList());
        public PartialViewResult GetAddNews() => PartialView($"{StatcPath.PartialViewPath}News/_AddNews.cshtml");
        public PartialViewResult GetEditNews(int id) => PartialView($"{StatcPath.PartialViewPath}News/_EditNews.cshtml", newsTable.Read(id));
        public PartialViewResult GetDisplayNews(int id) => PartialView($"{StatcPath.PartialViewPath}News/_DisplayNews.cshtml", newsTable.Read(id));
        public HttpStatusCode ConfirmDelete(int id)
        {
            var x = newsTable.Read(id);
            x.IsDeleted = true;
            newsTable.Update(x);
            newsTable.Save();
            return HttpStatusCode.OK;
        }
        [HttpPost]
        public HttpStatusCode Operation(NewsDto newsDto)
        {
            string imageUrl;
            News temp = new News();
            temp.Id = newsDto.Id;
            temp.Title = newsDto.Title;
            temp.Description = newsDto.Description;
            temp.ShortDescription = newsDto.ShortDescription;
            temp.KeyWord = newsDto.KeyWord;
            temp.Image = newsDto.Image;
            if (Session["USER"] == null)
                return HttpStatusCode.Unauthorized;
            if (temp.Id == 0)
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];
                    if (FloristStore.Extention.Validation.ValidatorFile(file, new string[] {
                            "image/jpg", "image/jpeg", "image/png"}) == HttpStatusCode.NotAcceptable)
                        return HttpStatusCode.NotAcceptable;
                    temp.Image = FloristStore.Extention.File.CreateFile(file, Server, "Image/Uploade/NewsImage/", "").Result;
                }
                newsTable.Create(temp);
                newsTable.Save();
            }
            else
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];
                    if (FloristStore.Extention.Validation.ValidatorFile(file, new string[] {
                "image/jpg", "image/jpeg", "image/png"}) == HttpStatusCode.NotAcceptable)
                        return HttpStatusCode.NotAcceptable;
                    temp.Image = FloristStore.Extention.File.UpdateFile(file, Server, "Image/Uploade/NewsImage/", "", temp.Image).Result;
                }
                newsTable.Update(temp);
                ViewBag.msg = newsTable.Save();
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.OK;
        }
    }
}
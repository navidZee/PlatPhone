using Microsoft.AspNetCore.Mvc;
using PlatPhone.DataLayer;
using PlatPhone.DataLayer.Service;
using System.Linq;

namespace PlatPhone.Controllers
{
    public class NewsController : BaseController
    {
        private DatabaseRepository<News> newsService;

        public NewsController(DatabaseRepository<News> newsService)
        {
            this.newsService = newsService;
        }

        // GET: News
        public IActionResult ListNews(int pageId = 1)
        {
            var News = newsService.GetAll().Where(g => !g.IsDeleted);
            #region pageing
            int count = News.Count();
            //تعداد کل صفحع 
            ViewBag.count = (count / 15) + ((count % 15) > 0 ? 1 : 0);
            //شماره صفحه 
            ViewBag.PageId = pageId;
            //Skip
            int skip = (pageId - 1) * 15;
            #endregion
            return View(model: News/*.OrderBy(g => g.Id).Skip(skip).Take(15)*/.ToList());
        }
        
        public IActionResult DetailNews(int ? id)
        {
            var News = newsService.GetAll().Where(g => !g.IsDeleted);
            if (!id.HasValue || !News.Any(g => g.Id == id))
                return Redirect("/News/ListNews");
            return View(News.Where(g => g.Id == id).FirstOrDefault());
        }

    }
}
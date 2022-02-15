using Microsoft.AspNetCore.Mvc;
using PlatPhone.DataLayer;
using PlatPhone.DataLayer.Context;
using PlatPhone.DataLayer.Service;
using PlatPhone.Providers;
using System.Linq;
using System.Net;

namespace PlatPhone.Areas.Admin.Controllers
{
    public class CommentController : BaseController
    {
        private DatabaseRepository<Comment> commentService;
        private ApplicationContext context;

        public CommentController(DatabaseRepository<Comment> commentService,
            ApplicationContext context)
        {
            this.commentService = commentService;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult ListComments()
        {          
            return PartialView($"{StatcPath.PartialViewPath}Comments/_ListComments.cshtml", commentService.GetAll().Where(g => !g.IsConfirmed && g.IsRejected == false).ToList());

        }

        public ActionResult IndexContactUs()
        {
            return View();
        }

        public PartialViewResult ListContactUs()
        {
            return PartialView($"{StatcPath.PartialViewPath}Comments/_ListContactUs.cshtml", context.ContactUs.ToList());
        }

        public string SuccssProductStatus(int id)
        {
            var x = commentService.Read(id);
            x.IsConfirmed = true;
            commentService.Update(x);
            commentService.Save();
            return HttpStatusCode.OK.ToString();
        }

        public string RejectdProductStatus(int id)
        {
            var x = commentService.Read(id);
            x.IsConfirmed = true;
            x.IsRejected = true;
            commentService.Update(x);
            commentService.Save();
            return HttpStatusCode.OK.ToString();
        }

    }
}
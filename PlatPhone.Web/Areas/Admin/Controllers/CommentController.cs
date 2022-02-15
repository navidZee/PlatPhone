using DataLayer;
using DataLayer.Service;
using FloristStore.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FloristStore.Areas.Admin.Controllers
{
    public class CommentController : Controller
    {
        DatabaseRepository<Comment> Comment = new DatabaseRepository<Comment>(new EF());
        EF ef = new EF();


        // GET: Admin/Comment
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ListComments()
        {          
            return PartialView($"{StatcPath.PartialViewPath}Comments/_ListComments.cshtml", Comment.GetAll().Where(g => !g.IsConfirmed && g.IsRejected == false).ToList());

        }
        public ActionResult IndexContactUs()
        {
            return View();
        }

        public PartialViewResult ListContactUs()
        {
            return PartialView($"{StatcPath.PartialViewPath}Comments/_ListContactUs.cshtml", ef.ContactUs.ToList());

        }

        public HttpStatusCode SuccssProductStatus(int id)
        {
            var x = Comment.Read(id);
            x.IsConfirmed = true;
            Comment.Update(x);
            Comment.Save();
            return HttpStatusCode.OK;
        }


        public HttpStatusCode RejectdProductStatus(int id)
        {
            var x = Comment.Read(id);
            x.IsConfirmed = true;
            x.IsRejected = true;
            Comment.Update(x);
            Comment.Save();
            return HttpStatusCode.OK;
        }

    }
}
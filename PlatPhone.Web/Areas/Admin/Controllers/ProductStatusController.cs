using FloristStore.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayer.Service;
using DataLayer.Enum;
using System.Net;
using FloristStore.Auth;

namespace FloristStore.Areas.Admin.Controllers
{
    [SessionAuthorize(true, RoleEnum.Admin)]
    public class ProductStatusController : Controller
    {
        DatabaseRepository<InvoiceHeader> MyInvice = new DatabaseRepository<InvoiceHeader>(new EF());
        DatabaseRepository<Product> productTable = new DatabaseRepository<Product>(new EF());
        DatabaseRepository<User> User = new DatabaseRepository<User>(new EF());

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ListProductStatus()
        {
            IQueryable<InvoiceHeader> invoiceHeaders = MyInvice.GetAll().Where(g => g.IsFinaly);

            string email = Session["USER"] as string;

            User user = User.GetAll().Where(g => g.Email == email).FirstOrDefault();

            return PartialView($"{StatcPath.PartialViewPath}ProductStatus/_ListProductStatus.cshtml", invoiceHeaders.ToList());
        }


        public HttpStatusCode SuccssProductStatus(int id)
        {
            var x = MyInvice.Read(id);
            x.RequestLevel = RequestLevel.delivered;
            MyInvice.Update(x);
            MyInvice.Save();
            return HttpStatusCode.OK;
        }


        public HttpStatusCode RejectdProductStatus(int id)
        {
            var x = MyInvice.Read(id);
            x.RequestLevel = RequestLevel.Rejectd;
            MyInvice.Update(x);
            MyInvice.Save();
            return HttpStatusCode.OK;
        }
        public HttpStatusCode SendingProductStatus(int id)
        {
            var x = MyInvice.Read(id);
            x.RequestLevel = RequestLevel.Sending;
            MyInvice.Update(x);
            MyInvice.Save();
            return HttpStatusCode.OK;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayer.Enum;
using DataLayer.Service;
using FloristStore.Auth;
using FloristStore.Providers;
using System.Data.Entity;
using System.Net;

namespace FloristStore.Areas.Admin.Controllers
{
    [SessionAuthorize(true, RoleEnum.Admin)]
    public class ReportSalController : Controller
    {
        DatabaseRepository<InvoiceHeader> MyInvoic = new DatabaseRepository<InvoiceHeader>(new EF());
        DatabaseRepository<InvoiceDetail> MyInvoicDetail = new DatabaseRepository<InvoiceDetail>(new EF());
        DatabaseRepository<User> User = new DatabaseRepository<User>(new EF());
        // GET: Admin/ReportSal
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ListReportSal()
        {
            IQueryable<InvoiceHeader> invoiceHeaders = MyInvoic.GetAll().Where(g => g.IsFinaly);

            string email = Session["USER"] as string;

            User user = User.GetAll().Where(g => g.Email == email).FirstOrDefault();

            return PartialView($"{StatcPath.PartialViewPath}ReportSal/_ListReportSal.cshtml", invoiceHeaders.ToList());
        }

        public PartialViewResult DetailReportSal(int id)
        {
            var Report = MyInvoicDetail.GetAll().Where(g => g.InvoiceHeader_Id == id).ToList();

            return PartialView($"{StatcPath.PartialViewPath}ReportSal/_DetailReportSal.cshtml", Report);
        }

        public HttpStatusCode ChekoutReportSal(int id)
        {

            var x = MyInvoic.Read(id);
            if (x.Checkout == Checkout.ok)
            {
                x.Checkout = Checkout.nok;
            }
            else
                x.Checkout = Checkout.ok;


            MyInvoic.Update(x);
            MyInvoic.Save();
            return HttpStatusCode.OK;
        }

    }
}
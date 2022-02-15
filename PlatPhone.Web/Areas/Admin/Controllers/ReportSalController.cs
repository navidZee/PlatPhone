using Microsoft.AspNetCore.Mvc;
using PlatPhone.Auth;
using PlatPhone.DataLayer;
using PlatPhone.DataLayer.Enum;
using PlatPhone.DataLayer.Service;
using PlatPhone.Providers;
using System.Linq;
using System.Net;

namespace PlatPhone.Areas.Admin.Controllers
{
    [SessionAuthorize(true, RoleEnum.Admin)]
    public class ReportSalController : BaseController
    {
        private DatabaseRepository<InvoiceHeader> invoiceHeaderService;
        private DatabaseRepository<InvoiceDetail> invoicDetailService;
        private DatabaseRepository<User> userService;

        public ReportSalController(DatabaseRepository<InvoiceHeader> invoiceHeaderService,
            DatabaseRepository<InvoiceDetail> invoicDetailService,
            DatabaseRepository<User> userService)
        {
            this.invoiceHeaderService = invoiceHeaderService;
            this.invoicDetailService = invoicDetailService;
            this.userService = userService;
        }

        // GET: Admin/ReportSal
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult ListReportSal()
        {
            IQueryable<InvoiceHeader> invoiceHeaders = invoiceHeaderService.GetAll().Where(g => g.IsFinaly);

            User user = userService.GetAll().Where(g => g.Email == UserEmail).FirstOrDefault();

            return PartialView($"{StatcPath.PartialViewPath}ReportSal/_ListReportSal.cshtml", invoiceHeaders.ToList());
        }

        public PartialViewResult DetailReportSal(int id)
        {
            var Report = invoicDetailService.GetAll().Where(g => g.InvoiceHeader_Id == id).ToList();

            return PartialView($"{StatcPath.PartialViewPath}ReportSal/_DetailReportSal.cshtml", Report);
        }

        public HttpStatusCode ChekoutReportSal(int id)
        {
            var x = invoiceHeaderService.Read(id);
         
            if (x.Checkout == Checkout.ok)
            {
                x.Checkout = Checkout.nok;
            }
            else
                x.Checkout = Checkout.ok;

            invoiceHeaderService.Update(x);
            invoiceHeaderService.Save();
            return HttpStatusCode.OK;
        }

    }
}
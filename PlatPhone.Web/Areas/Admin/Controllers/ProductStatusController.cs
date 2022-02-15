using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class ProductStatusController : BaseController
    {
        private DatabaseRepository<InvoiceHeader> invoiceService;
        private DatabaseRepository<Product> productService;
        private DatabaseRepository<User> userService;

        public ProductStatusController(DatabaseRepository<InvoiceHeader> invoiceService,
            DatabaseRepository<Product> productService,DatabaseRepository<User> userService)
        {
            this.invoiceService = invoiceService;
            this.productService = productService;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult ListProductStatus()
        {
            IQueryable<InvoiceHeader> invoiceHeaders = invoiceService.GetAll().Where(g => g.IsFinaly).Include(d=>d.User);

            return PartialView($"{StatcPath.PartialViewPath}ProductStatus/_ListProductStatus.cshtml", invoiceHeaders.ToList());
        }

        public string SuccssProductStatus(int id)
        {
            var x = invoiceService.Read(id);
            x.RequestLevel = RequestLevel.delivered;
            invoiceService.Update(x);
            invoiceService.Save();
            return HttpStatusCode.OK.ToString();
        }

        public string RejectdProductStatus(int id)
        {
            var x = invoiceService.Read(id);
            x.RequestLevel = RequestLevel.Rejectd;
            invoiceService.Update(x);
            invoiceService.Save();
            return HttpStatusCode.OK.ToString();
        }

        public string SendingProductStatus(int id)
        {
            var x = invoiceService.Read(id);
            x.RequestLevel = RequestLevel.Sending;
            invoiceService.Update(x);
            invoiceService.Save();
            return HttpStatusCode.OK.ToString();
        }

    }
}
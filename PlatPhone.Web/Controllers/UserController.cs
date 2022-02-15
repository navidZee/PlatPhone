using Microsoft.AspNetCore.Mvc;
using PlatPhone.Auth;
using PlatPhone.DataLayer;
using PlatPhone.DataLayer.Enum;
using PlatPhone.DataLayer.Service;
using System;
using System.Linq;

namespace PlatPhone.Controllers
{
    public class UserController : BaseController
    {
        private DatabaseRepository<User> userService;
        private DatabaseRepository<InvoiceHeader> invoiceHeaderService;
        private DatabaseRepository<InvoiceDetail> invoiceDetailService;

        public UserController(DatabaseRepository<User> userService,
            DatabaseRepository<InvoiceHeader> invoiceHeaderService,
            DatabaseRepository<InvoiceDetail> invoiceDetailService)
        {
            this.userService = userService;
            this.invoiceHeaderService = invoiceHeaderService;
            this.invoiceDetailService = invoiceDetailService;
        }

        [SessionAuthorize(true, RoleEnum.Admin, RoleEnum.Customer)]
        public IActionResult ProfileUser(bool shopcart = false)
        {
            ViewBag.active = 0;
            User user = userService.GetAll().Where(g => g.Email == this.UserEmail).FirstOrDefault();
            return View(new Tuple<User, bool>(user, shopcart));
        }
    }
}
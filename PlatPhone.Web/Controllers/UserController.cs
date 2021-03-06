using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlatPhone.Auth;
using PlatPhone.DataLayer;
using PlatPhone.DataLayer.Enum;
using PlatPhone.DataLayer.Service;
using System;
using System.Collections.Generic;
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
        public ActionResult EditePersonalInformation()
        {
            ViewBag.active = 2;
            DataLayer.User user = userService.GetAll().Where(g => g.Email == UserEmail).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public IActionResult EditePersonalInformation(User user)
        {
            DataLayer.User finalUser = userService.GetAll().Where(g => g.Email == UserEmail).FirstOrDefault();
            if (finalUser.Email != user.Email && !userService.GetAll().Any(g => g.Email == user.Email))
            {
                finalUser.Email = user.Email;
            }

            finalUser.UserName = user.UserName;
            finalUser.Name = user.Name;
            finalUser.Family = user.Family;
            finalUser.Tell = user.Tell;
            finalUser.UserAddress = user.UserAddress;

            var x = userService.Save();
            
            return View(user);
        }

        public IActionResult Orders(bool isDone = false)
        {
            ViewBag.active = 1;
            DataLayer.User MyUser = userService.GetAll().Where(g => g.Email == UserEmail).FirstOrDefault();

            if (MyUser == null)
                return Redirect("/Home/Index");

            var UserInvoce = invoiceHeaderService.GetAll().Where(g => g.User_Id == MyUser.Id && g.IsFinaly).Include(p => p.InvoiceDetails).OrderByDescending(p => p.Id).ToList();

            string str = "";
            if (isDone)
                str = UserInvoce.LastOrDefault().FactorCode.ToString();

            return View(new Tuple<User, List<InvoiceHeader>, bool, string>(MyUser, UserInvoce, isDone, str));
        }
    }
}
﻿using Microsoft.AspNetCore.Mvc;
using PlatPhone.DataLayer;
using PlatPhone.DataLayer.Enum;
using PlatPhone.DataLayer.Service;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PlatPhone.Controllers
{
    public class AccountController : BaseController
    {
        private DatabaseRepository<User> userService;
        
        public AccountController(DatabaseRepository<User> userService)
        {
            this.userService = userService;
        }

        // GET: Account
        [HttpGet]
        public IActionResult Login(string redirectToUrl = null)
        {
            if (redirectToUrl != null)
            {
                TempData["redirectToUrl"] = redirectToUrl;
                return Redirect("/Account/Login");
            }
            return View();
        }
        public PartialViewResult Signupuser() => PartialView("_Signup");

        //[HttpPost]
        //public IActionResult Login(string Email, string Password, string remember)
        //{
        //    string msg = "";

        //    HashAlgorithm temp = new SHA256CryptoServiceProvider();
        //    byte[] result = temp.ComputeHash(Encoding.UTF8.GetBytes(Password));
        //    Password = Convert.ToBase64String(result);

        //    if (CheckLogin(Email, Password))
        //    {
        //        System.Web.HttpContext.Current.Session["USER"] = Email;
        //        System.Web.HttpContext.Current.Session.Timeout = 60;

        //        if (TempData["redirectToUrl"] != null)
        //            return Redirect(TempData["redirectToUrl"].ToString());
        //        else if (GetRole(Email) == RoleEnum.Admin)
        //            return Redirect("/Admin/Home/Index");
        //        else
        //            return Redirect("/Home");
        //    }
        //    else
        //    {
        //        msg = "نام کاربری یا رمز عبور اشتباه می باشد";
        //    }

        //    ViewBag.result = msg;
        //    return View(model: new User());
        //}

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Signup(User record, string Confirm)
        //{
        //    if (record.Password != Confirm)
        //    {
        //        ViewBag.successmessage = "کلمه عبور و تکرار آن یکسان نمیباشد";
        //        return View("SignUp", record);
        //    }
        //    if (emailexist(record.Email))
        //    {
        //        ViewBag.successmessage = "ایمیل وارد شده تکراری میباشد";
        //        return View("SignUp", record);
        //    }
        //    else
        //    {
        //        #region PasswordHash

        //        HashAlgorithm temp = new SHA256CryptoServiceProvider();
        //        byte[] result = temp.ComputeHash(Encoding.UTF8.GetBytes(record.Password));
        //        record.Password = Convert.ToBase64String(result);


        //        #endregion

        //        record.Role = RoleEnum.Customer;
        //        userService.Create(record);
        //        ModelState.Clear();
        //        if (!userService.Save())
        //        {
        //            ViewBag.successmessage = "مشکلی در سیتسم بوجود آمده است";
        //            return View("SignUp", new User());
        //        }
        //        else
        //        {
        //            return Redirect("/Account/Login");
        //        }
        //    }
        //}

        //public IActionResult Logout()
        //{
        //    Session.Abandon();
        //    return Redirect("/Home/Index");
        //}

        //public static bool CheckLogin(string Email, string Password)
        //{
        //    return entity.Users.Any(item => item.Email == Email && item.Password == Password && !item.IsDeleted);
        //}

        //public static bool emailexist(string Email)
        //{
        //    var result = entity.Users.Where(item => item.Email == Email).FirstOrDefault();
        //    return result != null;
        //}

        //public static RoleEnum GetRole(string Email) =>  .Users.Where(item => item.Email == Email && !item.IsDeleted).FirstOrDefault().Role;

    }
}
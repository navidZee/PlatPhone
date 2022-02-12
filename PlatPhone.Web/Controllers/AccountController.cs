using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PlatPhone.DataLayer;
using PlatPhone.DataLayer.Context;
using PlatPhone.DataLayer.Enum;
using PlatPhone.DataLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PlatPhone.Controllers
{
    public class AccountController : BaseController
    {
        private DatabaseRepository<User> userService;
        private ApplicationContext context;

        public AccountController(DatabaseRepository<User> userService,
            ApplicationContext context)
        {
            this.userService = userService;
            this.context = context;
        }

        // GET: Account
        [HttpGet]
        public IActionResult Login(string redirectToUrl = null)
        {
            if (redirectToUrl != null)
            {
                TempData["redirectToUrl"] = redirectToUrl;
                return base.Redirect("/Account/Login");
            }
            return View();
        }
        public PartialViewResult Signupuser() => PartialView("_Signup");

        [HttpPost]
        public async Task<IActionResult> Login(string Email, string Password, string remember)
        {
            string msg = "";

            HashAlgorithm temp = new SHA256CryptoServiceProvider();
            byte[] result = temp.ComputeHash(Encoding.UTF8.GetBytes(Password));
            Password = Convert.ToBase64String(result);

            if (CheckLogin(Email, Password))
            {
                await SignIn(Email);

                return RedirectUser(Email);
            }
            else
            {
                msg = "نام کاربری یا رمز عبور اشتباه می باشد";
            }

            ViewBag.result = msg;
            return View(model: new User());
        }

        private IActionResult RedirectUser(string Email)
        {
            if (TempData["redirectToUrl"] != null)
                return base.Redirect(TempData["redirectToUrl"].ToString());
            else if (GetRole(Email) == RoleEnum.Admin)
                return base.Redirect("/Admin/Home/Index");
            else
                return base.Redirect("/Home");
        }

        private async Task SignIn(string Email)
        {
            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, Email)
                    };

            ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(User record, string Confirm)
        {
            if (record.Password != Confirm)
            {
                ViewBag.successmessage = "کلمه عبور و تکرار آن یکسان نمیباشد";
                return View("SignUp", record);
            }
            if (emailexist(record.Email))
            {
                ViewBag.successmessage = "ایمیل وارد شده تکراری میباشد";
                return View("SignUp", record);
            }
            else
            {
                #region PasswordHash

                HashAlgorithm temp = new SHA256CryptoServiceProvider();
                byte[] result = temp.ComputeHash(Encoding.UTF8.GetBytes(record.Password));
                record.Password = Convert.ToBase64String(result);

                #endregion

                record.Role = RoleEnum.Customer;
                userService.Create(record);
                ModelState.Clear();
                if (!userService.Save())
                {
                    ViewBag.successmessage = "مشکلی در سیتسم بوجود آمده است";
                    return View("SignUp", new User());
                }
                else
                {
                    return base.Redirect("/Account/Login");
                }
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return base.Redirect("/Home/Index");
        }

        public  bool CheckLogin(string Email, string Password)
        {
            return context.Users.Any(item => item.Email == Email && item.Password == Password && !item.IsDeleted);
        }

        public  bool emailexist(string Email)
        {
            var result = context.Users.Where(item => item.Email == Email).FirstOrDefault();
            return result != null;
        }

        public RoleEnum GetRole(string Email)
        {
            return context.Users.Where(item => item.Email == Email && !item.IsDeleted).FirstOrDefault().Role;
        }
    }
}
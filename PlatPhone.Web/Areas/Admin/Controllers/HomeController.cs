using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlatPhone.Auth;
using PlatPhone.DataLayer;
using PlatPhone.DataLayer.Context;
using PlatPhone.DataLayer.Enum;
using PlatPhone.DataLayer.Service;
using System;
using System.Linq;
using Wholesale.Web.Models.Dto;

namespace PlatPhone.Areas.Admin.Controllers
{
    [SessionAuthorize(true, RoleEnum.Admin)]
    public class HomeController : BaseController
    {
        private DatabaseRepository<User> userService;
        private DatabaseRepository<Multimedia> multimediaService;
        private DatabaseRepository<Product> productService;
        private DatabaseRepository<Category> categoryService;
        private DatabaseRepository<ContactUs> contactUsService;
        private DatabaseRepository<News> newsService;
        private DatabaseRepository<ClientMenuLink> clientMenuLinkService;
        private ApplicationContext context;

        public HomeController(DatabaseRepository<User> userService,
        DatabaseRepository<Multimedia> multimediaService,
        DatabaseRepository<Product> productService,
        DatabaseRepository<Category> categoryService,
        DatabaseRepository<ContactUs> contactUsService,
        DatabaseRepository<News> newsService,
        DatabaseRepository<ClientMenuLink> clientMenuLinkService,
        ApplicationContext context)
        {
            this.userService = userService;
            this.multimediaService = multimediaService;
            this.productService = productService;
            this.categoryService = categoryService;
            this.contactUsService = contactUsService;
            this.newsService = newsService;
            this.clientMenuLinkService = clientMenuLinkService;
            this.context = context;
        }

        public ActionResult Index()
        {
            AdminHomePageViewModel model = new AdminHomePageViewModel();
            
            model.TotalNews = newsService.GetAll().Where(g => !g.IsDeleted).Count();
            model.TotalUsers = userService.GetAll().Where(g => !g.IsDeleted && g.Role == RoleEnum.Customer).Count();
            model.TotalProducts = productService.GetAll().Where(g => !g.IsDeleted).Count();
            model.SellMonth = context.InvoiceHeaders.Where(g => g.CreateDate.Month == DateTime.Now.Month && g.CreateDate.Year == DateTime.Now.Year && !g.IsDeleted && g.IsFinaly).Include(g => g.InvoiceDetails).ToList().Sum(g => g.InvoiceDetails.Sum(f => (f.Count * (int)f.Price)));

            var categories = categoryService.GetAll().Where(g => !g.IsDeleted).ToList();
            foreach (var item in categories)
            {
                ChartDash chartDash = new ChartDash();
                chartDash.Name = item.Name;
                var products = productService.GetAll().Where(g => g.CategoryId == item.Id).ToList();
                products.ForEach(g =>
                {
                    chartDash.FinalPrice += context.InvoiceDetails.Where(product => product.Product_Id == g.Id).Include(gs => gs.InvoiceHeader).Where(gs => gs.InvoiceHeader.CreateDate.Month == DateTime.Now.Month && gs.InvoiceHeader.CreateDate.Year == DateTime.Now.Year && gs.InvoiceHeader.IsFinaly & !gs.InvoiceHeader.IsDeleted).ToList().Sum(gs => (gs.Count * (int)gs.Price));
                });
                chartDash.FinalPrice = (chartDash.FinalPrice * 100) / model.SellMonth;
                model.Charts.Add(chartDash);
            }
            model.Charts = model.Charts.OrderByDescending(g => g.FinalPrice).Take(12).ToList();

            return View(model);
        }

    }
}
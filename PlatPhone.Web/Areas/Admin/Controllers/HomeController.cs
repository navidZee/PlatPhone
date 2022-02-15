using DataLayer;
using DataLayer.Enum;
using DataLayer.Service;
using FloristStore.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wholesale.Web.Models.Dto;
using System.Data.Entity;

namespace FloristStore.Areas.Admin.Controllers
{
    [SessionAuthorize(true, RoleEnum.Admin)]
    public class HomeController : BaseController
    {
        DatabaseRepository<User> myUserTable = new DatabaseRepository<User>(new EF());
        DatabaseRepository<Multimedia> myMultimediaTable = new DatabaseRepository<Multimedia>(new EF());
        DatabaseRepository<Product> myProductTable = new DatabaseRepository<Product>(new EF());
        DatabaseRepository<Category> myCategoryTable = new DatabaseRepository<Category>(new EF());
        DatabaseRepository<ContactUs> myContactUsTable = new DatabaseRepository<ContactUs>(new EF());
        DatabaseRepository<News> myNewsTable = new DatabaseRepository<News>(new EF());
        DatabaseRepository<ClientMenuLink> myCMLTable = new DatabaseRepository<ClientMenuLink>(new EF());
        EF ef = new EF();
        // GET: Admin/Home
        public ActionResult Index()
        {
            AdminHomePageViewModel model = new AdminHomePageViewModel();

            model.TotalNews = myNewsTable.GetAll().Where(g => !g.IsDeleted).Count();
            model.TotalUsers = myUserTable.GetAll().Where(g => !g.IsDeleted && g.Role == RoleEnum.Customer).Count();
            model.TotalProducts = myProductTable.GetAll().Where(g => !g.IsDeleted).Count();
            model.SellMonth = ef.InvoiceHeaders.Where(g => g.CreateDate.Month == DateTime.Now.Month && g.CreateDate.Year == DateTime.Now.Year && !g.IsDeleted && g.IsFinaly).Include(g => g.InvoiceDetails).ToList().Sum(g => g.InvoiceDetails.Sum(f => (f.Count * (int)f.Price)));

            var categories = myCategoryTable.GetAll().Where(g => !g.IsDeleted).ToList();
            foreach (var item in categories)
            {
                ChartDash chartDash = new ChartDash();
                chartDash.Name = item.Name;
                var products = myProductTable.GetAll().Where(g => g.CategoryId == item.Id).ToList();
                products.ForEach(g =>
                {
                    chartDash.FinalPrice += ef.InvoiceDetails.Where(product => product.Product_Id == g.Id).Include(gs => gs.InvoiceHeader).Where(gs => gs.InvoiceHeader.CreateDate.Month == DateTime.Now.Month && gs.InvoiceHeader.CreateDate.Year == DateTime.Now.Year && gs.InvoiceHeader.IsFinaly & !gs.InvoiceHeader.IsDeleted).ToList().Sum(gs => (gs.Count * (int)gs.Price));
                });
                chartDash.FinalPrice = (chartDash.FinalPrice * 100) / model.SellMonth;
                model.Charts.Add(chartDash);
            }
            model.Charts = model.Charts.OrderByDescending(g => g.FinalPrice).Take(12).ToList();

            return View(model);
        }
    }
}
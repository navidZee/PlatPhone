using Microsoft.AspNetCore.Mvc;
using PlatPhone.DataLayer;
using PlatPhone.DataLayer.Service;
using PlatPhone.Models.ViewModel;
using System.Linq;

namespace PlatPhone.Controllers
{
    public class HomeController : BaseController
    {
        private DatabaseRepository<InvoiceHeader> invoiceHeaderService;
        private DatabaseRepository<InvoiceDetail> invoiceDetailService;
        private DatabaseRepository<Multimedia> multimediaService;
        private DatabaseRepository<Product> productService;
        private DatabaseRepository<Category> categoryService;
        private DatabaseRepository<ContactUs> contactUsService;
        private DatabaseRepository<News> newsService;
        private DatabaseRepository<ClientMenuLink> clientMenuLinkService;

        public HomeController(DatabaseRepository<Multimedia> multimediaService,
            DatabaseRepository<Product> productService,
            DatabaseRepository<Category> categoryService,
            DatabaseRepository<ContactUs> contactUsService,
            DatabaseRepository<News> newsService,
            DatabaseRepository<ClientMenuLink> clientMenuLinkService,
            DatabaseRepository<InvoiceHeader> invoiceHeaderService,
            DatabaseRepository<InvoiceDetail> invoiceDetailService)
        {
            this.multimediaService = multimediaService;
            this.productService = productService;
            this.categoryService = categoryService;
            this.clientMenuLinkService = clientMenuLinkService;
            this.contactUsService = contactUsService;
            this.newsService = newsService;
            this.invoiceHeaderService = invoiceHeaderService;
            this.invoiceDetailService = invoiceDetailService;
        }

        public IActionResult Index()
        {
            var product = productService.GetAll();
            var category = categoryService.GetAll();
            var news = newsService.GetAll();
            var cmls = clientMenuLinkService.GetAll();
            HomePageViewModel model = new HomePageViewModel();

            model.NewProducts = product.Where(g => !g.IsDeleted).OrderByDescending(g => g.Id).Take(4).ToList();

            model.HasDiscountProducts = product.Where(g => !g.IsDeleted && g.Discount > 0).OrderByDescending(g => g.Id).Take(4).ToList();

            model.Categories = category.Where(g => g.IsDeleted != true && g.Parent == 0).ToList();
            model.News = news.Where(g => g.IsDeleted != true).OrderByDescending(g => g.Id).Take(4).ToList();

            model.ClientMenuLinks = cmls.Where(g => g.IsDeleted != true).OrderByDescending(g => g.Id).ToList();

            ViewBag.Categories = model.Categories;
            return View(model);
        }

        public IActionResult ContactUs() => View(false);
        public IActionResult AboutUs() => View();
        public IActionResult PackagingUnit() => View();

        [HttpPost]
        public IActionResult ContactUs(ContactUs contactUs)
        {
            contactUsService.Create(contactUs);
            contactUsService.Save();
            return View(true);
        }

        [HttpGet]
        public IActionResult DetailPage(int pageIdefider)
        {
            var cmls = clientMenuLinkService.GetAll();
            if (!cmls.Any(g => g.Id == pageIdefider))
                return Redirect("/Home/Index");
            return View(cmls.FirstOrDefault(g => g.Id == pageIdefider));
        }

        public IActionResult Gellery() => View(multimediaService.GetAll().Where(g => !g.IsDeleted).ToList());

        public IActionResult Error403() => View();

        public IActionResult Error404() => View();
    }
}

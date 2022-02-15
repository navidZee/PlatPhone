using FloristStore.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using PlatPhone.Auth;
using PlatPhone.DataLayer;
using PlatPhone.DataLayer.Enum;
using PlatPhone.DataLayer.Service;
using PlatPhone.DataLayer.ViewMadel;
using PlatPhone.Models;
using PlatPhone.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace PlatPhone.Areas.Admin.Controllers
{
    [SessionAuthorize(true, RoleEnum.Admin)]
    public class ProductController : BaseController
    {
        private DatabaseRepository<News> newsService;
        private DatabaseRepository<Product> productService;
        private DatabaseRepository<User> userService;
        private DatabaseRepository<Category> catgoryService;
        private DatabaseRepository<Image> imageService;
        private DatabaseRepository<InvoiceHeader> invoiceHeaderService;

        public ProductController(DatabaseRepository<News> newsService,
         DatabaseRepository<Product> productService,
         DatabaseRepository<User> userService,
         DatabaseRepository<Category> catgoryService,
         DatabaseRepository<Image> imageService,
         DatabaseRepository<InvoiceHeader> invoiceHeaderService)
        {
            this.newsService = newsService;
            this.productService = productService;
            this.userService = userService;
            this.imageService = imageService;
            this.invoiceHeaderService = invoiceHeaderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetListProduct(BaseFilter Filter)
        {
            var readProduct = productService.Select(p => !p.IsDeleted);
            var readCatgory = catgoryService.Read();
            var readImage = imageService.Read();

            CollegeViewModelProduct veiwModel = new CollegeViewModelProduct(readProduct, readImage, readCatgory);

            return PartialView($"{StatcPath.PartialViewPath}Product/_ListProduct.cshtml", veiwModel);
        }

        public ActionResult AddProduct() => View(model: catgoryService.Read());

        public PartialViewResult GetAddProduct()
        {
            return PartialView($"{StatcPath.PartialViewPath}Product/_AddProduct.cshtml", catgoryService.GetAll().Where(g => !g.IsDeleted).ToList());
        }
        public PartialViewResult GetEditProduct(int id)
        {
            Tuple<Product, List<Category>> result =
                new Tuple<Product, List<DataLayer.Category>>
                (productService.Read(id), catgoryService.GetAll().Where(g => !g.IsDeleted).ToList());

            return PartialView($"{StatcPath.PartialViewPath}Product/_EditProduct.cshtml", result);
        }

        public HttpStatusCode ConfirmDelete(int id)
        {
            var x = productService.Read(id);
            x.IsDeleted = true;
            productService.Update(x);
            productService.Save();
            return HttpStatusCode.OK;
        }

        [HttpGet]
        public ActionResult Operation(int id)
        {
            ViewBag.cat = catgoryService.Read();
            return View(model: productService.Read(id));
        }

        [HttpPost]
        public HttpStatusCode Operation(ProductDto productDto)
        {
            if (productDto.CategoryId == 0)
                return HttpStatusCode.NotModified;

            #region fillModal            
            string imageUrl;
            Product temp = new Product();
            temp.Id = productDto.Id;
            temp.Name = productDto.Name;
            temp.CategoryId = productDto.CategoryId;
            temp.Description = productDto.Description;
            temp.Keyword = productDto.Keyword;
            temp.Price = productDto.Price;
            temp.Discount = productDto.Discount;
            temp.Inventory = productDto.Inventory;
            #endregion

            if (temp.Id == 0)
            {
                //var file = Request.Files[0];
                //if (PlatPhone.Extention.Validation.ValidatorFile(file, new string[] { "image/jpg", "image/jpeg", "image/png" }) == HttpStatusCode.NotAcceptable)
                //    return HttpStatusCode.NotAcceptable;
                //temp.ImageUrl = PlatPhone.Extention.File.CreateFile(file, Server, "Image/Uploade/ProductImage/", "").Result;
                productService.Create(temp);
                productService.Save();
            }
            else
            {
                //if (Request.Files.Count > 0)
                //{
                //    var file = Request.Files[0];
                //    if (PlatPhone.Extention.Validation.ValidatorFile(file, new string[] { "image/jpg", "image/jpeg", "image/png" }) == HttpStatusCode.NotAcceptable)
                //        return HttpStatusCode.NotAcceptable;
                //    temp.ImageUrl = PlatPhone.Extention.File.UpdateFile(file, Server, "Image/Uploade/ProductImage/", "", temp.ImageUrl).Result;
                //}
                productService.Update(temp);
                ViewBag.msg = productService.Save();
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.OK;
        }

        public ActionResult Category() => View();

        public ActionResult Delete(int id)
        {
            productService.Delete(id);
            productService.Save();

            return Redirect("/Admin/Product");
        }

    }
}
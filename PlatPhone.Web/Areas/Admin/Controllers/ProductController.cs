using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayer.Service;
using DataLayer.ViewMadel;
using System.IO;
using FloristStore.Providers;
using FloristStore.Models.Dtos;
using System.Net;
using FloristStore.Models;
using DataLayer.Enum;
using FloristStore.Auth;

namespace FloristStore.Areas.Admin.Controllers
{
    [SessionAuthorize(true, RoleEnum.Admin)]
    public class ProductController : BaseController
    {
        DatabaseRepository<Product> productTable = new DatabaseRepository<Product>(new EF());
        DatabaseRepository<User> userTable = new DatabaseRepository<User>(new EF());
        DatabaseRepository<Category> catgoryTable = new DatabaseRepository<Category>(new EF());
        DatabaseRepository<Image> imageTable = new DatabaseRepository<Image>(new EF());
        DatabaseRepository<InvoiceHeader> invoiceHeaderTable = new DatabaseRepository<InvoiceHeader>(new EF());

        // GET: Admin/Product
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetListProduct(BaseFilter Filter)
        {
            var readProduct = productTable.Select(p => !p.IsDeleted);
            var readCatgory = catgoryTable.Read();
            var readImage = imageTable.Read();

            CollegeViewModelProduct veiwModel = new CollegeViewModelProduct(readProduct, readImage, readCatgory);

            return PartialView($"{StatcPath.PartialViewPath}Product/_ListProduct.cshtml", veiwModel);
        }

        public ActionResult AddProduct()
        {
            //ViewBag.catId = "";

            return View(model: catgoryTable.Read());

        }

        public PartialViewResult GetAddProduct()
        {
            return PartialView($"{StatcPath.PartialViewPath}Product/_AddProduct.cshtml", catgoryTable.GetAll().Where(g => !g.IsDeleted).ToList());
        }
        public PartialViewResult GetEditProduct(int id)
        {
            Tuple<Product, List<Category>> result =
                new Tuple<Product, List<DataLayer.Category>>
                (productTable.Read(id), catgoryTable.GetAll().Where(g => !g.IsDeleted).ToList());

            //var x = new SelectList()

            return PartialView($"{StatcPath.PartialViewPath}Product/_EditProduct.cshtml", result);
        }

        public HttpStatusCode ConfirmDelete(int id)
        {
            var x = productTable.Read(id);
            x.IsDeleted = true;
            productTable.Update(x);
            productTable.Save();
            return HttpStatusCode.OK;

        }

        [HttpGet]
        public ActionResult Operation(int id)
        {

            ViewBag.cat = catgoryTable.Read();
            //ViewData["img"]=

            return View(model: productTable.Read(id));

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
                var file = Request.Files[0];
                if (FloristStore.Extention.Validation.ValidatorFile(file, new string[] { "image/jpg", "image/jpeg", "image/png" }) == HttpStatusCode.NotAcceptable)
                    return HttpStatusCode.NotAcceptable;
                temp.ImageUrl = FloristStore.Extention.File.CreateFile(file, Server, "Image/Uploade/ProductImage/", "").Result;
                productTable.Create(temp);
                productTable.Save();
            }
            else
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];
                    if (FloristStore.Extention.Validation.ValidatorFile(file, new string[] { "image/jpg", "image/jpeg", "image/png" }) == HttpStatusCode.NotAcceptable)
                        return HttpStatusCode.NotAcceptable;
                    temp.ImageUrl = FloristStore.Extention.File.UpdateFile(file, Server, "Image/Uploade/ProductImage/", "", temp.ImageUrl).Result;
                }
                productTable.Update(temp);
                ViewBag.msg = productTable.Save();
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.OK;
        }

        public ActionResult Category()
        {
            return View();
        }

        //[HttpPost]
        public ActionResult Delete(int id)
        {
            productTable.Delete(id);
            productTable.Save();

            return Redirect("/Admin/Product");
        }
    }
}
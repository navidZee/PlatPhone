using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlatPhone.DataLayer;
using PlatPhone.DataLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
namespace PlatPhone.Controllers
{
    public class ProductController : BaseController
    {
        private DatabaseRepository<Product> productService;
        private DatabaseRepository<Comment> commentService;

        public ProductController(DatabaseRepository<Product> productService,
            DatabaseRepository<Comment> commentService)
        {
            this.productService = productService;
            this.commentService = commentService;
        }

        // GET: Product
        public IActionResult ListProduct(int? Groups, int? hisDiscount, string Address, string keyWord, int pageId = 1)
        {
            var Products = productService.GetAll().Where(g => !g.IsDeleted);

            if (Groups.HasValue && Groups != 0)
                Products = Products.Where(g => g.CategoryId == Groups);
            if (hisDiscount.HasValue)
                Products = Products.Where(g => g.Discount > 0);
            if (keyWord != null && keyWord != "")
                Products = Products.Where(g => g.Name.Contains(keyWord));

            return View(model: Products/*.OrderBy(g => g.Id).Skip(skip).Take(15)*/.ToList());
        }
        public IActionResult DetailProduct(int? id)
        {
            var Products = productService.GetAll().Where(g => !g.IsDeleted);

            if (!id.HasValue || !Products.Any(g => g.Id == id))
                return Redirect("/Product/ListProduct");

            Tuple<Product, List<Comment>, bool> model = new Tuple<Product, List<Comment>, bool>(
                Products.Where(g => g.Id == id).Include(g => g.Category).FirstOrDefault(),
                commentService.GetAll().Where(g => g.Product_Id == id.Value && g.IsConfirmed).ToList(), false);

            return View(model);
        }

        public IActionResult AddComment(int? id)
        {
            var Products = productService.GetAll().Where(g => !g.IsDeleted);

            if (!id.HasValue || !Products.Any(g => g.Id == id))
                return Redirect("Home/Product/AddComment");

            return View(Products.Where(g => g.Id == id).Include(g => g.Category).FirstOrDefault());
        }

        public IActionResult RegisterComment(Comment comment, int productId)
        {
            comment.Product_Id = productId;
            commentService.Create(comment);

            ViewBag.data = "نظر شما با موفقیت ثبت گردید پس از تایید مدیریت در سایت نمایش داده میشود";
            return Redirect("/Product/DetailProduct?showAl=true&?id=" + productId);
        }
    }
}
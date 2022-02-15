using FloristStore.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatPhone.Auth;
using PlatPhone.DataLayer;
using PlatPhone.DataLayer.Enum;
using PlatPhone.DataLayer.Service;
using PlatPhone.Providers;
using System;
using System.Linq;
using System.Net;

namespace PlatPhone.Areas.Admin.Controllers
{
    [SessionAuthorize(true, RoleEnum.Admin)]
    public class CatgoryController : BaseController
    {
        private DatabaseRepository<Category> categoryService;
        public CatgoryController(DatabaseRepository<Category> categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: Admin/Catgory
        [HttpGet]
        public IActionResult Index() => View();

        public PartialViewResult GetListCategory() => PartialView($"{StatcPath.PartialViewPath}Category/_GetListCategory.cshtml", categoryService.GetAll().Where(g => !g.IsDeleted).ToList());

        public PartialViewResult GetAddCategory() => PartialView($"{StatcPath.PartialViewPath}Category/_GetAddCategory.cshtml", categoryService.Read());

        public PartialViewResult GetAddSubCategory() => PartialView($"{StatcPath.PartialViewPath}Category/_GetAddSubCategory.cshtml", categoryService.Read());

        public string Operation(CategoryDto categoryDto)
        {
            try
            {
                Category CatParent = new Category();
                CatParent.Parent = 0;
                CatParent.Name = categoryDto.Name;
                if (categoryDto.ImageName != null)
                {
                    if (PlatPhone.Extention.Validation.ValidatorFile(categoryDto.ImageName,0, new string[] { "image/svg+xml", "image/jpg", "image/jpeg", "image/png" }) == HttpStatusCode.NotAcceptable)
                        return HttpStatusCode.NotAcceptable.ToString();

                    CatParent.ImgName = PlatPhone.Extention.File.CreateFile(categoryDto.ImageName, "Image/Uploade/CatrgoryImage/", "").Result;
                    categoryService.Create(CatParent);
                    categoryService.Save();
                    return HttpStatusCode.OK.ToString();
                }
                else
                {
                    return HttpStatusCode.BadRequest.ToString();
                }
            }
            catch
            {
                return HttpStatusCode.NotFound.ToString();
            }
        }

        public string OperationSubCategory(SubCategoryDto SubCategoryDto)
        {
            try
            {
                Category SubCat = new Category();
                SubCat.Parent = Convert.ToInt32(SubCategoryDto.Parent);
                SubCat.Name = SubCategoryDto.Name;
                SubCat.ImgName = null;

                categoryService.Create(SubCat);
                categoryService.Save();
                return HttpStatusCode.OK.ToString();
            }
            catch
            {
                return HttpStatusCode.NotFound.ToString();
            }
        }

        public string ConfirmDelete(int id)
        {
            var x = categoryService.Read(id);
            x.IsDeleted = true;
            categoryService.Update(x);
            categoryService.Save();
            return HttpStatusCode.OK.ToString();
        }

        [HttpPost]
        public ActionResult Index(FormCollection input, int? id)
        {
            Category temp = new Category();
            if (id != null)
            {
                temp.Name = input["subCatName"].ToString();
                temp.Parent = Convert.ToInt32(input["selectCategory"]);

            }
            else
            {
                temp.Name = input["catName"].ToString();
                temp.Parent = 0;
            }

            categoryService.Create(temp);
            ViewBag.msg = categoryService.Save();
            return Redirect("/Admin/Catgory/Index");
        }
    }
}
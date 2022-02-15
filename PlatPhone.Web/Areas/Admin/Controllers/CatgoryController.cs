using DataLayer;
using DataLayer.Enum;
using DataLayer.Service;
using FloristStore.Auth;
using FloristStore.Models.Dtos;
using FloristStore.Providers;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FloristStore.Areas.Admin.Controllers
{
    [SessionAuthorize(true, RoleEnum.Admin)]
    public class CatgoryController : BaseController
    {
        DatabaseRepository<Category> catgoryTable = new DatabaseRepository<Category>(new EF());

        // GET: Admin/Catgory
        [HttpGet]
        public ActionResult Index() => View();

        public PartialViewResult GetListCategory() => PartialView($"{StatcPath.PartialViewPath}Category/_GetListCategory.cshtml", catgoryTable.GetAll().Where(g => !g.IsDeleted).ToList());

        public PartialViewResult GetAddCategory() => PartialView($"{StatcPath.PartialViewPath}Category/_GetAddCategory.cshtml", catgoryTable.Read());

        public PartialViewResult GetAddSubCategory() => PartialView($"{StatcPath.PartialViewPath}Category/_GetAddSubCategory.cshtml", catgoryTable.Read());

        public HttpStatusCode Operation(CategoryDto categoryDto)
        {
            try
            {
                Category CatParent = new Category();
                CatParent.Parent = 0;
                CatParent.Name = categoryDto.Name;
                if (Request.Files[0] != null)
                {
                    var file = Request.Files[0];

                    if (
                    FloristStore.Extention.Validation.ValidatorFile(file, new string[] { "image/svg+xml", "image/jpg", "image/jpeg", "image/png" }) == HttpStatusCode.NotAcceptable)
                        return HttpStatusCode.NotAcceptable;

                    CatParent.ImgName = FloristStore.Extention.File.CreateFile(file, Server, "Image/Uploade/CatrgoryImage/", "").Result;
                    catgoryTable.Create(CatParent);
                    catgoryTable.Save();
                    return HttpStatusCode.OK;
                }
                else
                {
                    return HttpStatusCode.BadRequest;
                }
            }
            catch
            {
                return HttpStatusCode.NotFound;
            }
        }

        public HttpStatusCode OperationSubCategory(SubCategoryDto SubCategoryDto)
        {
            try
            {
                Category SubCat = new Category();
                SubCat.Parent = Convert.ToInt32(SubCategoryDto.Parent);
                SubCat.Name = SubCategoryDto.Name;
                SubCat.ImgName = null;

                catgoryTable.Create(SubCat);
                catgoryTable.Save();
                return HttpStatusCode.OK;
            }
            catch
            {
                return HttpStatusCode.NotFound;
            }
        }

        public HttpStatusCode ConfirmDelete(int id)
        {
            var x = catgoryTable.Read(id);
            x.IsDeleted = true;
            catgoryTable.Update(x);
            catgoryTable.Save();
            return HttpStatusCode.OK;
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
            catgoryTable.Create(temp);
            ViewBag.msg = catgoryTable.Save();
            return Redirect("/Admin/Catgory/Index");
        }

    }
}
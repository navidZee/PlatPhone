using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayer.Enum;
using DataLayer.Service;
using FloristStore.Auth;
using FloristStore.Models.Dtos;
using FloristStore.Providers;

namespace FloristStore.Areas.Admin.Controllers
{
    [SessionAuthorize(true, RoleEnum.Admin)]
    public class ClientMenuLinkController : Controller
    {
        DatabaseRepository<ClientMenuLink> CMLTable = new DatabaseRepository<ClientMenuLink>(new EF());
        // GET: Admin/ClientMenuLink
        public ActionResult Index() => View();
        public PartialViewResult GetListCML() => PartialView($"{StatcPath.PartialViewPath}ClientMenuLink/_ListCML.cshtml", CMLTable.GetAll().Where(g => !g.IsDeleted).ToList());
        public PartialViewResult GetAddCML() => PartialView($"{StatcPath.PartialViewPath}ClientMenuLink/_AddCML.cshtml");
        public PartialViewResult GetEditCML(int id) => PartialView($"{StatcPath.PartialViewPath}ClientMenuLink/_EditCML.cshtml", CMLTable.Read(id));
        public PartialViewResult GetDisplayCML(int id) => PartialView($"{StatcPath.PartialViewPath}ClientMenuLink/_DisplayCML.cshtml", CMLTable.Read(id));
        public HttpStatusCode ConfirmDelete(int id)
        {
            var x = CMLTable.Read(id);
            x.IsDeleted = true;
            CMLTable.Update(x);
            CMLTable.Save();
            return HttpStatusCode.OK;
        }
        [ValidateInput(false)]
        public HttpStatusCode Operation(ClientMenuLink cml)
        {
            if (Session["USER"] == null)
                return HttpStatusCode.Unauthorized;
            if (cml.Id==0)
            {
                CMLTable.Create(cml);
                CMLTable.Save();
            }
            else
            {
                CMLTable.Update(cml);
                ViewBag.msg = CMLTable.Save();
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.OK;
        }
    }
}
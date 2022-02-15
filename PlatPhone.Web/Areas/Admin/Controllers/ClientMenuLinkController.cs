using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PlatPhone.Auth;
using PlatPhone.DataLayer;
using PlatPhone.DataLayer.Enum;
using PlatPhone.DataLayer.Service;
using PlatPhone.Providers;
using System.Linq;
using System.Net;

namespace PlatPhone.Areas.Admin.Controllers
{
    [SessionAuthorize(true, RoleEnum.Admin)]
    public class ClientMenuLinkController : BaseController
    {
        private DatabaseRepository<ClientMenuLink> clientMenuLinkService;
        public ClientMenuLinkController(DatabaseRepository<ClientMenuLink> clientMenuLinkService)
        {
            this.clientMenuLinkService = clientMenuLinkService;
        }

        // GET: Admin/ClientMenuLink
        public IActionResult Index() => View();
        public PartialViewResult GetListCML() => PartialView($"{StatcPath.PartialViewPath}ClientMenuLink/_ListCML.cshtml", clientMenuLinkService.GetAll().Where(g => !g.IsDeleted).ToList());
        public PartialViewResult GetAddCML() => PartialView($"{StatcPath.PartialViewPath}ClientMenuLink/_AddCML.cshtml");
        public PartialViewResult GetEditCML(int id) => PartialView($"{StatcPath.PartialViewPath}ClientMenuLink/_EditCML.cshtml", clientMenuLinkService.Read(id));
        public PartialViewResult GetDisplayCML(int id) => PartialView($"{StatcPath.PartialViewPath}ClientMenuLink/_DisplayCML.cshtml", clientMenuLinkService.Read(id));
        public HttpStatusCode ConfirmDelete(int id)
        {
            var x = clientMenuLinkService.Read(id);
            x.IsDeleted = true;
            clientMenuLinkService.Update(x);
            clientMenuLinkService.Save();
            return HttpStatusCode.OK;
        }

        //[ValidateInput(false)]
        public HttpStatusCode Operation(ClientMenuLink cml)
        {
            if (cml.Id==0)
            {
                clientMenuLinkService.Create(cml);
                clientMenuLinkService.Save();
            }
            else
            {
                clientMenuLinkService.Update(cml);
                ViewBag.msg = clientMenuLinkService.Save();
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.OK;
        }
    }
}
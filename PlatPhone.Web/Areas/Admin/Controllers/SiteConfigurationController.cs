using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DataLayer;
using DataLayer.Service;
using FloristStore.Providers;
using DataLayer.Enum;
using FloristStore.Auth;
using System.Net;

namespace FloristStore.Areas.Admin.Controllers
{

    [SessionAuthorize(true, RoleEnum.Admin)]
    public class SiteConfigurationController : Controller
    {
        DatabaseRepository<SiteConfiguration> siteConfigurationTable = new DatabaseRepository<SiteConfiguration>(new EF());
        // GET: Admin/StoreProfile
        public ActionResult Index() => View(siteConfigurationTable.Read());
        public HttpStatusCode PostSiteConfiguration(List<SiteConfiguration> siteConfigurations)
        {
            if (siteConfigurations.Count() > 0)
            {
                foreach (var item in siteConfigurations)
                {                   
                        var x = siteConfigurationTable.GetAll().Where(g => g.Key == item.Key).FirstOrDefault();
                        x.Value = item.Value;
                        siteConfigurationTable.Save();              
                }
            }

            return HttpStatusCode.OK;
        }
    }
}
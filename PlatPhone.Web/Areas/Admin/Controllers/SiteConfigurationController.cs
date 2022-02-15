using Microsoft.AspNetCore.Mvc;
using PlatPhone.Auth;
using PlatPhone.DataLayer;
using PlatPhone.DataLayer.Enum;
using PlatPhone.DataLayer.Service;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace PlatPhone.Areas.Admin.Controllers
{
    [SessionAuthorize(true, RoleEnum.Admin)]
    public class SiteConfigurationController : BaseController
    {
        DatabaseRepository<SiteConfiguration> siteConfigurationService;

        public SiteConfigurationController(DatabaseRepository<SiteConfiguration> siteConfigurationService)
        {
            this.siteConfigurationService = siteConfigurationService;
        }

        public IActionResult Index() => View(siteConfigurationService.Read());
        public string PostSiteConfiguration(List<SiteConfiguration> siteConfigurations)
        {
            if (siteConfigurations.Count() > 0)
            {
                foreach (var item in siteConfigurations)
                {                   
                        var x = siteConfigurationService.GetAll().Where(g => g.Key == item.Key).FirstOrDefault();
                        x.Value = item.Value;
                        siteConfigurationService.Save();              
                }
            }

            return HttpStatusCode.OK.ToString();
        }

    }
}
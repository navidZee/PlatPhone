using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace PlatPhone.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public string UserEmail { get=> User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value; }

    }
}
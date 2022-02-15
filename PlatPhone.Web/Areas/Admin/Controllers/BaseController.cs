using DataLayer;
using DataLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FloristStore.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        DatabaseRepository<User> uerTable = new DatabaseRepository<User>(new EF());

        protected new readonly User User;
        public BaseController()
        {
            

        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PlatPhone.DataLayer;
using PlatPhone.DataLayer.Enum;
using PlatPhone.DataLayer.Service;
using System.Linq;
using System.Security.Claims;

namespace PlatPhone.Auth
{
    public class SessionAuthorizeAttribute : ActionFilterAttribute
    {
        private bool IsAuth { get; set; }
        private RoleEnum[] ActiveRole { get; set; }
        public SessionAuthorizeAttribute(bool isAuth, params RoleEnum[] activeRole)
        {
            IsAuth = isAuth;
            ActiveRole = activeRole;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (IsAuth)
            {
                
                if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    if (filterContext.HttpContext.Request.Path.Value!= null)
                        filterContext.Result =
                            new RedirectResult("/Account/Login?redirectToUrl=" + filterContext.HttpContext.Request.Path.Value);
                    return;
                }

                var  userService = (DatabaseRepository<User>)filterContext.HttpContext.RequestServices.GetService(typeof(DatabaseRepository<User>));

                var email = filterContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;

                RoleEnum userRole = userService.GetAll().Where(g => g.Email == email).Select(g => g.Role).FirstOrDefault();

                if (!ActiveRole.Contains(userRole))
                {
                    filterContext.Result = new RedirectResult("/Home/Error403");
                    return;
                }
                base.OnActionExecuting(filterContext);
            }
        }
    }
}

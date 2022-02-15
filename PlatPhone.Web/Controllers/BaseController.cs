using Microsoft.AspNetCore.Mvc;
using PlatPhone.DataLayer;
using PlatPhone.DataLayer.Service;
using System.Linq;
using System.Security.Claims;

namespace PlatPhone.Controllers
{
    [Area("Admin")]
    public class BaseController : Controller
    {
        private DatabaseRepository<Category> categoryService;
        private DatabaseRepository<ClientMenuLink> clientMenuLinkService;

        public BaseController()
        {
            //var clientMenuLinkService = (DatabaseRepository<ClientMenuLink>)HttpContext.RequestServices.GetService(typeof(DatabaseRepository<ClientMenuLink>));
            //var categoryService = (DatabaseRepository<Category>)HttpContext.RequestServices.GetService(typeof(DatabaseRepository<Category>));
            //ViewBag.ShopCartCount = GetCountProductInShopCart();
            //ViewBag.ClientMenuLinks = clientMenuLinkService.GetAll().Where(g => g.IsDeleted != true).OrderByDescending(g => g.Id).ToList();
            //ViewBag.Categories = categoryService.GetAll().Where(g => g.IsDeleted != true && g.Parent == 0).ToList();
        }

        public int GetCountProductInShopCart()
        {
            return 0;
            //if (Session == null || Session["ShopCart"] == null)
            //    return 0;
            //return (Session["ShopCart"] as List<ShopCartViewModel>).Sum(p => p.Count);
        }

        public string UserEmail { get => User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value; }

    }
}
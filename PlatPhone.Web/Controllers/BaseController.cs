using FloristStore.Models.ViewModel.ShopCart;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FloristStore.Controllers
{

    public class BaseController : Controller
    {
        //DatabaseRepository<ClientMenuLink> myCMLTable = new DatabaseRepository<ClientMenuLink>(new EF());
        //DatabaseRepository<Category> myCategoryTable = new DatabaseRepository<Category>(new EF());

        public BaseController()
        {
            //ViewBag.ShopCartCount = GetCountProductInShopCart();
            //ViewBag.ClientMenuLinks = myCMLTable.GetAll().Where(g => g.IsDeleted != true).OrderByDescending(g => g.Id).ToList();
            //ViewBag.Categories = myCategoryTable.GetAll().Where(g => g.IsDeleted != true && g.Parent == 0).ToList();
        }

        public int GetCountProductInShopCart()
        {
            return 0;
            //if (Session == null || Session["ShopCart"] == null)
            //    return 0;
            //return (Session["ShopCart"] as List<ShopCartViewModel>).Sum(p => p.Count);
        }

    }
}
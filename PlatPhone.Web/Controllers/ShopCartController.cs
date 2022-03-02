using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlatPhone.Areas.Admin.Controllers;
using PlatPhone.Auth;
using PlatPhone.DataLayer;
using PlatPhone.DataLayer.Enum;
using PlatPhone.DataLayer.Service;
using PlatPhone.Models.ViewModel;
using PlatPhone.Models.ViewModel.ShopCart;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlatPhone.Controllers
{
    public class ShopCartController : BaseController
    {
        private DatabaseRepository<User> userService;
        private DatabaseRepository<Product> productService;
        private DatabaseRepository<InvoiceHeader> invoiceHeaderService;
        private DatabaseRepository<InvoiceDetail> invoiceDetailService;
        private DatabaseRepository<SiteConfiguration> siteConfigurationService;

        public ShopCartController(DatabaseRepository<User> userService,
            DatabaseRepository<Product> productService,
            DatabaseRepository<InvoiceHeader> invoiceHeaderService,
            DatabaseRepository<InvoiceDetail> invoiceDetailService,
            DatabaseRepository<SiteConfiguration> siteConfigurationService)
        {
            this.userService = userService;
            this.productService = productService;
            this.invoiceHeaderService = invoiceHeaderService;
            this.invoiceDetailService = invoiceDetailService;
            this.siteConfigurationService = siteConfigurationService;
        }

        // GET: ShopCart
        public IActionResult Index() => View();

        [SessionAuthorize(true, RoleEnum.Admin, RoleEnum.Customer)]
        public IActionResult Shoping()
        {
            User user = userService.GetAll().Where(g => g.Email == UserEmail).FirstOrDefault();
            if (user == null)
                return Redirect("/Account/Login");

            if (user.Name == null || user.Family == null || user.UserAddress == null || user.Tell == null)
            {
                ViewBag.EditePersonalInformation = "FullInfo";
                return Redirect("/User/ProfileUser?shopcart=true");
            }

            SetCartHeader(GetShopCartFromSession(), GetCartHeaderFromSession());
            return Redirect("/ShopCart/Payment");
        }

        #region Select 

        public JsonResult GetShopCart()
        {
            if (IsNotNullSession("ShopCart"))
            {
                List<ShopCartViewModel> cart = GetShopCartFromSession();

                if (IsNotNullSession("CartHeader"))
                    return Json(GetRecord(cart, GetCartHeaderFromSession()));

                return Json(GetCart(cart));
            }
            return Json(false);
        }

        public JsonResult GetShopingInformation()
        {
            List<ShopCartViewModel> cart = GetShopCartFromSession();
            List<InvoiceHeader> RecordCartHeader = GetCartHeaderFromSession();

            dynamic x = GetRecord(cart.ToList(), RecordCartHeader);

            return Json(x);
        }

        #region GetShopCart

        public List<ShopCartViewModel> GetCart(List<ShopCartViewModel> cart) => cart.Select(p => new ShopCartViewModel()
        {
            Count = p.Count,
            Sal = p.Sal,
            Product = p.Product,
            Status = p.Status,
            Price = p.Price,
        }).ToList();

        public dynamic GetRecord(List<ShopCartViewModel> cart, List<InvoiceHeader> RecordCartHeader)
        {
            User user = GetUser();

            if (cart.Where(item => item.Status == 0).ToList().Count != 0)
                SetCartHeader(cart.Select(p => new ShopCartViewModel()
                {
                    Count = p.Count,
                    Sal = p.Sal,
                    Product = p.Product,
                    Status = p.Status,
                    Price = p.Price,
                }).ToList(), RecordCartHeader);

            var record = from cc in cart
                         select new
                         {
                             User_Id = user.Id,
                             Count = cc.Count,
                             Price = cc.Price,
                             Product = cc.Product,
                             Sal = cc.Sal,
                             Address = user.UserAddress,
                             FirstName = user.Name,
                             LastName = user.Family,
                         };

            return record;
        }

        #endregion

        #endregion

        #region Create

        public JsonResult AddToCart(int id)
        {
            List<ShopCartViewModel> cart = new List<ShopCartViewModel>();

            if (IsNotNullSession("ShopCart"))
                cart = GetShopCartFromSession();

            ProductListViewModel product = GetProduct();

            //چک میکنیم که محصول داخل سشن وجود دارد یا برای اولین بار است داخل سشن میریزیم
            if (cart.Any(item => item.Product.Id == id))
                UpdateSession();
            else
                AddToSession();

            if (IsNotNullSession("CartHeader"))
                return Json(GetRecord(cart, GetCartHeaderFromSession()));

            #region LocalFunction 

            ProductListViewModel GetProduct()
            {
                var x = productService.GetAll().Where(item => item.Id == id)
                  .Select(item => new ProductListViewModel
                  {
                      Id = item.Id,
                      Count = item.Inventory,
                      Sal = item.Discount,
                      ProductName = item.Name,
                      Price = item.Price,
                      Image = (item.ImageUrl != null || item.ImageUrl != "") ? "/Image/Uploade/ProductImage/" + item.ImageUrl : "/Image/Icon/picture.svg"
                  }).FirstOrDefault();
                return x;
            }
            void AddToSession()
            {
                decimal ProductsPrice = ((int)(product.Price * (decimal)(100 - product.Sal)) / 100);

                cart.Add(new ShopCartViewModel()
                {
                    Status = 0,
                    Count = 1,
                    //مبلغ پرداختی به صورت ریال و با محاسبه تخفیف میباشد
                    Price = ProductsPrice,
                    //میزان تخفیف
                    Sal = product.Price - ProductsPrice,
                    Product = product,
                });
            }

            void UpdateSession()
            {
                int index = cart.FindIndex(item => item.Product.Id == id);
                cart[index].Count += 1;
                var query = productService.GetAll().Where(item => item.Id == id).FirstOrDefault();
                int ProductsPrice = (int)(query.Price * (100 - query.Discount)) / 100;
                cart[index].Price += ProductsPrice;
                cart[index].Sal = (query.Price * cart[index].Count) - cart[index].Price;
            }

            #endregion

            SetSession("ShopCart", cart);
            return Json(GetCart(cart));
        }

        //پر کردن تمام کارت دیتیل ههایی که فاکتور هدرشون نال هستن
        public void SetCartHeader(List<ShopCartViewModel> cart, List<InvoiceHeader> RecordCartHeader)
        {
            foreach (var item in cart.Where(p => p.Status == 0))
            {
                var query = productService.GetAll().Where(itemm => itemm.Id == item.Product.Id).FirstOrDefault();
                //قیمت تکی محصول با محاسبه تخفیف
                int ProductsPrice = (int)(query.Price *
                    (100 - query.Discount)) / 100;
                decimal sal = query.Discount * 0;
                if (query.Discount != 0)
                    sal = (query.Price * item.Count) -
                        ((query.Price * (100 - query.Discount) / 100)
                        * item.Count);

                //اگر اون فروشگاه تاحالا تو فاکتور نبوده یک بار ادش کن
                Random random = new Random();
                int FactorCode = random.Next(10000, 65000);
                while (invoiceHeaderService.GetAll().Where(p => p.FactorCode == FactorCode).Any())
                    FactorCode = random.Next(10000, 65000);

                if (RecordCartHeader == null)
                {
                    RecordCartHeader = new List<InvoiceHeader>();
                }

                User user = GetUser();

                RecordCartHeader.Add(new InvoiceHeader
                {
                    User_Id = user.Id,
                    User = user,
                    FactorCode = FactorCode,
                    IsFinaly = false,
                    RequestLevel = RequestLevel.Sending

                });

                item.Status = RecordCartHeader.Any() ? RecordCartHeader[0].FactorCode : FactorCode;

                SetSession("CartHeader", RecordCartHeader);
                SetSession("ShopCart", cart);
            }
        }
        public bool AddFactors(List<InvoiceHeader> FactorHeaders, List<ShopCartViewModel> ShopCartViewModel)
        {
            try
            {
                foreach (var factorHeaders in FactorHeaders)
                {
                    factorHeaders.CreateDate = DateTime.Now;
                    factorHeaders.User = null;
                    invoiceHeaderService.Create(factorHeaders);
                    invoiceHeaderService.Save();
                    foreach (var invoetails in ShopCartViewModel.Where(p => p.Status == factorHeaders.FactorCode).Select(p => new InvoiceDetail()
                    {
                        Count = p.Count,

                        Price = p.Price,
                        Discount = p.Sal,
                        Product_Id = p.Product.Id,

                    }).ToList())
                    {

                        invoetails.InvoiceHeader_Id = factorHeaders.Id;
                        invoiceDetailService.Create(invoetails);
                        invoiceDetailService.Save();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Update

        public JsonResult ChangeCount(int ProductID, bool status, int count)
        {
            if (count == 1 && status == false)
                //Error
                return Json(false);


            List<ShopCartViewModel> cart = GetShopCartFromSession();
            int index = cart.FindIndex(item => item.Product.Id == ProductID);
            var query = productService.GetAll().Where(item => item.Id == ProductID).FirstOrDefault();
            int ProductsPrice = (int)(query.Price * (100 - query.Discount)) / 100;
            if (status == true)
            {
                //++               
                cart[index].Count += 1;
                cart[index].Price += ProductsPrice;
                if (query.Discount != 0)
                    cart[index].Sal = (query.Price * cart[index].Count) - (int)(((query.Price * (100 - query.Discount)) / 100) * cart[index].Count);
            }
            else
            {
                //--                    
                cart[index].Count -= 1;
                cart[index].Price -= ProductsPrice;
                if (query.Discount != 0)
                    cart[index].Sal = (int)(query.Price * cart[index].Count) - (int)(((query.Price * (100 - query.Discount)) / 100) * cart[index].Count);
            }

            SetSession("ShopCart", cart);

            if (IsNotNullSession("CartHeader"))
                return Json(GetRecord(cart, GetCartHeaderFromSession()));

            return Json(GetCart(cart));
        }

        #endregion

        #region Delete

        public JsonResult RemoveFromCart(int productId)
        {
            try
            {
                List<ShopCartViewModel> cart = GetShopCartFromSession();
                cart.Remove(cart.Where(item => item.Product.Id == productId).FirstOrDefault());

                SetSession("ShopCart", cart);

                if (IsNotNullSession("CartHeader"))
                    return Json(GetRecord(cart, GetCartHeaderFromSession()));

                return Json(GetCart(cart));
            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        public IActionResult ClearShopCart()
        {
            ClearSession();
            return Redirect("/ShopCart");
        }

        #endregion

        public IActionResult Payment()
        {
            return View();
        }

        public IActionResult Verify(bool status)
        {
            if (!status)
            {
                ClearSession();
                return Redirect("/ShopCart");
            }

            var cartHeader = GetCartHeaderFromSession();
            int factCode = cartHeader[0].FactorCode;
            InvoiceHeader invoiceHeader = invoiceHeaderService.GetAll().Where(g => g.FactorCode == factCode).FirstOrDefault();
            invoiceHeader.IsFinaly = true;
            invoiceHeaderService.Save();
            ClearSession();

            return View();
        }

        bool IsNotNullSession(string sessionName) => !string.IsNullOrEmpty(HttpContext.Session.GetString(sessionName));
        void ClearSession() => HttpContext.Session.Clear();

        private User GetUser()
        {
            User user = userService.GetAll().Where(g => g.Email == UserEmail).FirstOrDefault();
            return user;
        }

        private void SetSession(string name, object data)
        {
            HttpContext.Session.SetString(name, JsonConvert.SerializeObject(data));
        }

        private List<InvoiceHeader> GetCartHeaderFromSession()
        {
            if (IsNotNullSession("CartHeader"))
                return JsonConvert.DeserializeObject<List<InvoiceHeader>>(HttpContext.Session.GetString("CartHeader"));
            return new List<InvoiceHeader>();
        }

        private List<ShopCartViewModel> GetShopCartFromSession()
        {
            if (IsNotNullSession("ShopCart"))
                return JsonConvert.DeserializeObject<List<ShopCartViewModel>>(HttpContext.Session.GetString("ShopCart"));
            return new List<ShopCartViewModel>();
        }

    }
}
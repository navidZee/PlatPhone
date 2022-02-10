using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayer.Service;
using System.Collections;
using FloristStore.Models.ViewModel.ShopCart;
using DataLayer.Enum;
using FloristStore.Auth;

namespace FloristStore.Controllers
{
    public class ShopCartController : BaseController
    {
        DatabaseRepository<User> userTable = new DatabaseRepository<User>(new EF());
        DatabaseRepository<Product> productTable = new DatabaseRepository<Product>(new EF());
        DatabaseRepository<InvoiceHeader> invoiceHeaderTable = new DatabaseRepository<InvoiceHeader>(new EF());
        DatabaseRepository<InvoiceDetail> invoiceDetailTable = new DatabaseRepository<InvoiceDetail>(new EF());
        DatabaseRepository<SiteConfiguration> siteConfigurationTable = new DatabaseRepository<SiteConfiguration>(new EF());
        // GET: ShopCart
        public IActionResult Index() => View();

        [SessionAuthorize(true, RoleEnum.Admin, RoleEnum.Customer)]
        public IActionResult Shoping()
        {
            string email = Session["USER"] as string;
            DataLayer.User user = userTable.GetAll().Where(g => g.Email == email).FirstOrDefault();
            if (user == null)
                return Redirect("/Account/Login");

            if (user.Name == null ||
                            user.Family == null ||
                            user.UserAddress == null ||
                            user.Tell == null)
            {
                ViewBag.EditePersonalInformation = "FullInfo";
                return Redirect("/User/ProfileUser?shopcart=true");
            }

            SetCartHeader(Session["ShopCart"] as List<ShopCartViewModel>, Session["CartHeader"] as List<InvoiceHeader>);
            return Redirect("/ShopCart/Payment");
        }

        #region Select 

        public JsonResult GetShopCart()
        {
            if (Session["ShopCart"] != null)
            {
                List<ShopCartViewModel> cart = Session["ShopCart"] as List<ShopCartViewModel>;
                if (Session["CartHeader"] != null)
                    return Json(GetRecord(cart, Session["CartHeader"] as List<InvoiceHeader>), JsonRequestBehavior.AllowGet);
                return Json(GetCart(cart), JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetShopingInformation()
        {
            List<ShopCartViewModel> cart = Session["ShopCart"] as List<ShopCartViewModel>;
            List<InvoiceHeader> RecordCartHeader = new List<InvoiceHeader>();
            if (Session["CartHeader"] != null)
                RecordCartHeader = Session["CartHeader"] as List<InvoiceHeader>;
            dynamic x = GetRecord(cart.ToList(), RecordCartHeader);

            return Json(x, JsonRequestBehavior.AllowGet);
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
            string Email = Session["USER"] as string;
            DataLayer.User user = userTable.GetAll().Where(g => g.Email == Email).FirstOrDefault();


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
            if (Session["ShopCart"] != null)
                cart = Session["ShopCart"] as List<ShopCartViewModel>;

            ProductListViewModel product = GetProduct();

            //چک میکنیم که محصول داخل سشن وجود دارد یا برای اولین بار است داخل سشن میریزیم
            if (cart.Any(item => item.Product.Id == id))
                UpdateSession();
            else
                AddToSession();
            if (Session["CartHeader"] != null)
                return Json(GetRecord(cart, Session["CartHeader"] as List<InvoiceHeader>), JsonRequestBehavior.AllowGet);

            #region LocalFunction 

            ProductListViewModel GetProduct()
            {
                return productTable.GetAll().Where(item => item.Id == id)
                  .Select(item => new ProductListViewModel
                  {
                      Id = item.Id,
                      Count = item.Inventory,
                      Sal = item.Discount,
                      ProductName = item.Name,
                      Price = item.Price,
                      Image = (item.ImageUrl != null || item.ImageUrl != "") ? "/www/Image/Uploade/ProductImage/" + item.ImageUrl : "/www/Image/Icon/picture.svg"
                  }).FirstOrDefault();
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
                var query = productTable.GetAll().Where(item => item.Id == id).FirstOrDefault();
                int ProductsPrice = (int)(query.Price * (100 - query.Discount)) / 100;
                cart[index].Price += ProductsPrice;
                cart[index].Sal = (query.Price * cart[index].Count) - cart[index].Price;
            }
            #endregion
            Session["ShopCart"] = cart;
            return Json(GetCart(cart), JsonRequestBehavior.AllowGet);
        }

        //پر کردن تمام کارت دیتیل ههایی که فاکتور هدرشون نال هستن
        public void SetCartHeader(List<ShopCartViewModel> cart, List<InvoiceHeader> RecordCartHeader)
        {
            foreach (var item in cart.Where(p => p.Status == 0))
            {
                var query = productTable.GetAll().Where(itemm => itemm.Id == item.Product.Id).FirstOrDefault();
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
                while (invoiceHeaderTable.GetAll().Where(p => p.FactorCode == FactorCode).Any())
                    FactorCode = random.Next(10000, 65000);

                if (RecordCartHeader == null)
                {
                    RecordCartHeader = new List<InvoiceHeader>();
                }


                string Email = Session["USER"] as string;
                DataLayer.User user = userTable.GetAll().Where(g => g.Email == Email).FirstOrDefault();

                RecordCartHeader.Add(new InvoiceHeader
                {
                    User_Id = user.Id,
                    User = user,
                    FactorCode = FactorCode,
                    IsFinaly = false,
                    RequestLevel = DataLayer.Enum.RequestLevel.Sending

                });

                item.Status = RecordCartHeader.Any() ? RecordCartHeader[0].FactorCode : FactorCode;

                Session["CartHeader"] = RecordCartHeader;
                Session["ShopCart"] = cart;
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
                    invoiceHeaderTable.Create(factorHeaders);
                    invoiceHeaderTable.Save();
                    foreach (var invoetails in ShopCartViewModel.Where(p => p.Status == factorHeaders.FactorCode).Select(p => new InvoiceDetail()
                    {
                        Count = p.Count,

                        Price = p.Price,
                        Discount = p.Sal,
                        Product_Id = p.Product.Id,

                    }).ToList())
                    {

                        invoetails.InvoiceHeader_Id = factorHeaders.Id;
                        invoiceDetailTable.Create(invoetails);
                        invoiceDetailTable.Save();
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
                return Json(false, JsonRequestBehavior.AllowGet);


            List<ShopCartViewModel> cart = Session["ShopCart"] as List<ShopCartViewModel>;
            int index = cart.FindIndex(item => item.Product.Id == ProductID);
            var query = productTable.GetAll().Where(item => item.Id == ProductID).FirstOrDefault();
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

            Session["ShopCart"] = cart;
            if (Session["CartHeader"] != null)
                return Json(GetRecord(cart, Session["CartHeader"] as List<InvoiceHeader>), JsonRequestBehavior.AllowGet);
            return Json(GetCart(cart), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Delete

        public JsonResult RemoveFromCart(int productId)
        {
            try
            {
                List<ShopCartViewModel> cart = Session["ShopCart"] as List<ShopCartViewModel>;
                cart.Remove(cart.Where(item => item.Product.Id == productId).FirstOrDefault());
                Session["ShopCart"] = cart;
                if (Session["CartHeader"] != null)
                    return Json(GetRecord(cart, Session["CartHeader"] as List<InvoiceHeader>), JsonRequestBehavior.AllowGet);
                return Json(GetCart(cart), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        public IActionResult ClearShopCart()
        {
            Session["ShopCart"] = null;
            if (Session["CartHeader"] != null)
                Session["CartHeader"] = null;
            return Redirect("/ShopCart");
        }

        #endregion

        #region ZarinPal

        public IActionResult Payment()
        {
            if (AddFactors(Session["CartHeader"] as List<InvoiceHeader>, Session["ShopCart"] as List<ShopCartViewModel>))
            {
                var shopCart = Session["ShopCart"] as List<ShopCartViewModel>;
                var carHeader = Session["CartHeader"] as List<InvoiceHeader>;
                decimal Amount = shopCart.Sum(g => g.Price);

                System.Net.ServicePointManager.Expect100Continue = false;
                ZarinPal.PaymentGatewayImplementationServicePortTypeClient zp = new ZarinPal.PaymentGatewayImplementationServicePortTypeClient();
                string Authority;

                int Status = zp.PaymentRequest(
                    "XXXX-XXXX-XXXX-XXXX", (int)Amount / 10,
                    "فروشگاه گل و گیاه",
                    "soumayeh825@gmail.com"
                    , "09155157736", "http://localhost:9112/ShopCart/Verify", out Authority);

                if (Status == 100)
                {
                    //Response.Redirect("https://www.zarinpal.com/pg/StartPay/" + Authority);
                    Response.Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + Authority);
                }
                else
                {
                    ViewBag.Error = "Error : " + Status;
                }
            }
            return View();
        }


        public IActionResult Verify()
        {

            if (Request.QueryString["Status"] != "" && Request.QueryString["Status"] != null && Request.QueryString["Authority"] != "" && Request.QueryString["Authority"] != null)
            {
                if (Request.QueryString["Status"].ToString().Equals("OK"))
                {
                    var shopCart = Session["ShopCart"] as List<ShopCartViewModel>;
                    var carHeader = Session["CartHeader"] as List<InvoiceHeader>;
                    decimal Amount = shopCart.Sum(g => g.Price);

                    long RefID;
                    System.Net.ServicePointManager.Expect100Continue = false;
                    ZarinPal.PaymentGatewayImplementationServicePortTypeClient zp = new ZarinPal.PaymentGatewayImplementationServicePortTypeClient();

                    int Status = zp.PaymentVerification(
                        "XXXX-XXXX-XXXX-XXXX"
                        , Request.QueryString["Authority"].ToString(),
                        (int)Amount / 10, out RefID);

                    if (Status == 100)
                    {
                        int factCode = carHeader[0].FactorCode;
                        InvoiceHeader invoiceHeader = invoiceHeaderTable.GetAll().Where(g => g.FactorCode == factCode).FirstOrDefault();
                        invoiceHeader.IsFinaly = true;
                        invoiceHeaderTable.Save();
                        ViewBag.IsSuccess = true;
                        ViewBag.RefId = RefID;
                        return Redirect("/User/Orders?isdone=true");
                    }
                    else
                    {
                        ViewBag.Status = Status;
                    }

                }
                else
                {
                    Response.Write("Error! Authority: " + Request.QueryString["Authority"].ToString() + " Status: " + Request.QueryString["Status"].ToString());
                }
            }
            else
            {
                Response.Write("Invalid Input");
            }
            ViewBag.IsSuccess = false;
            return View();
        }

        #endregion

    }
}
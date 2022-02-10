using PlatPhone.DataLayer;
using System.Collections.Generic;

namespace FloristStore.Models.ViewModel
{
    public class HomePageViewModel
    {
        public List<Product> NewAboutUs { get; set; }
        public List<Product> HasDiscountProducts { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> NewProducts { get; set; }
        public List<News> News { get; set; }
        public List<ClientMenuLink> ClientMenuLinks { get; set; }
    }
}
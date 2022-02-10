using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloristStore.Models.ViewModel.ShopCart
{
    public class ProductListViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int GroupProduct_Id { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public double Sal { get; set; }
        public string Image { get; set; } 
    }
}

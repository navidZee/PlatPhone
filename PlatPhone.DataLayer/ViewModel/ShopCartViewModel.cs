﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloristStore.Models.ViewModel.ShopCart
{
    public class ShopCartViewModel 
    {
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal Sal { get; set; }
        public ProductListViewModel Product { get; set; }
        public int Status { get; set; } 
    }
}

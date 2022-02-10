namespace PlatPhone.Models.ViewModel
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

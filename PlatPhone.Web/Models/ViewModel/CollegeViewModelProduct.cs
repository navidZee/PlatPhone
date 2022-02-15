using System.Collections.Generic;

namespace PlatPhone.DataLayer.ViewMadel
{
    public class CollegeViewModelProduct
    {
        public CollegeViewModelProduct(IEnumerable<Product> product, IEnumerable<Image> image, IEnumerable<Category> category)
        {
            Product = product;
            Image = image;
            Category = category;
        }
        
        public IEnumerable<Product> Product { get; set; }
        public IEnumerable<Image> Image { get; set; }
        public IEnumerable<Category> Category { get; set; }
    }
}

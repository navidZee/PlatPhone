using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FloristStore.Models.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }
        public IFormFile UploadedFile { get; set; }
        public string ImageUrl { get; set; }
        public byte Discount { get; set; }
    }

    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile ImageName { get; set; }
    }

    public class SubCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Parent { get; set; }
    }
}
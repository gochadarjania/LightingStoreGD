using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightingStore_GD.Services.Models.Responses
{
    public class GetProductsResponse
    {
        public IEnumerable<Product> Products { get; set; }
        public int TotalCountPage { get; set; }
        public int CurrentPage { get; set; }
        public string Search { get; set; }
        public string Category { get; set; }

        public class Product
        {
            public int ProductId { get; set; }
            public string Name { get; set; }
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
            public decimal Price { get; set; }
            public string ImgUrl { get; set; }
        }
    }
}

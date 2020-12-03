using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightingStore_GD.Services.Models.Responses
{
    public class GetProductDetailResponse
    {
        public IEnumerable<ProductDetail> ProductDetails { get; set; }
        public class ProductDetail
        {
            public int ProductId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string CategoryName { get; set; }
            public decimal Price { get; set; }
            public string ImgUrl { get; set; }
        }
    }
}

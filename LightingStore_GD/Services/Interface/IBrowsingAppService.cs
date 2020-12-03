using LightingStore_GD.Services.Models.Requests;
using LightingStore_GD.Services.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightingStore_GD.Services.Interface
{
    public interface IBrowsingAppService
    {
        public GetCategoriesResponse GetCategories(GetCategoriesRequest request);

        public GetProductsResponse GetProducts(GetProductsRequest request);
        public GetProductDetailResponse GetProductDetail(GetProductDetailRequest request);

    }
}

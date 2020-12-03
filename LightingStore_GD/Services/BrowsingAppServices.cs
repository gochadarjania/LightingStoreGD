using LightingStore_GD.MyDbContexts;
using LightingStore_GD.Services.Interface;
using LightingStore_GD.Services.Models.Requests;
using LightingStore_GD.Services.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightingStore_GD.Services
{
    public class BrowsingAppServices : IBrowsingAppService
    {
        MyDbContext _dbContext;
        public BrowsingAppServices(MyDbContext dbContext) => _dbContext = dbContext;
        public GetCategoriesResponse GetCategories(GetCategoriesRequest request)
        {
            var result = _dbContext.Categories
                .Select(p => new GetCategoriesResponse.Category
                {
                    CategoryId = p.CategoryId,
                    Name = p.Name
                });
            return new GetCategoriesResponse
            {
                Categories = result.ToList()
            };
        }

        public GetProductDetailResponse GetProductDetail(GetProductDetailRequest request)
        {
            var filteredProducts = _dbContext.Products
                 .Where(p => (p.ProductId == request.ProductId));

            var result = filteredProducts
                .Select(p => new GetProductDetailResponse.ProductDetail
                {
                    Name = p.Name,
                    ProductId = p.ProductId,
                    CategoryName = p.CategoryName,
                    Price = p.Price,
                    Description = p.Description,
                    ImgUrl = p.ProductImages.SingleOrDefault(i => true).ImageUrl
                });

            return new GetProductDetailResponse
            {
                ProductDetails = result.ToList()
            };

        }

        public GetProductsResponse GetProducts(GetProductsRequest request)
        {

            var filteredProducts = _dbContext.Products
                .Where(p => (p.CategoryName == request.CategoryName || request.CategoryName == null) &&
                            (p.Name.Contains(request.Searching) || request.Searching == null));

            var totalCountProduct = filteredProducts.Count();

            var result = filteredProducts
                .Skip(request.PageSize * (request.Page - 1))
                .Take(request.PageSize)
                .Select(p => new GetProductsResponse.Product
                {
                    Name = p.Name,
                    ProductId = p.ProductId,
                    CategoryId = p.CategoryId,
                    Price = p.Price,
                    ImgUrl = p.ProductImages.SingleOrDefault(i => true).ImageUrl
                });


            return new GetProductsResponse
            {
                Products = result.ToList(),
                TotalCountPage = (int)Math.Ceiling((decimal)totalCountProduct / request.PageSize),
                CurrentPage = request.Page,
                Search = request.Searching,
                Category = request.CategoryName

            };
        }
    }
}

using LightingStore_GD.Models;
using LightingStore_GD.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LightingStore_GD.Controllers
{
    public class HomeController : Controller
    {

        IBrowsingAppService _browsingAppService;

        public HomeController(IBrowsingAppService browsingAppService)
        {
            _browsingAppService = browsingAppService;
        }

        public IActionResult Index(string categoryName, string searching, int page = 1)
        {
            var products = _browsingAppService.GetProducts(new Services.Models.Requests.GetProductsRequest
            {
                CategoryName = categoryName,
                Page = page,
                PageSize = 20,
                Searching = searching
            });

            return View(products);

        }

        public IActionResult ProductDetail(int? id)
        {
            var productDetail = _browsingAppService.GetProductDetail(new Services.Models.Requests.GetProductDetailRequest
            {
                ProductId = (int)id
            });            

            return View(productDetail);

        }

        public IActionResult Search(string categoryName, int page = 1, string searching = null)
        {
            var products = _browsingAppService.GetProducts(new Services.Models.Requests.GetProductsRequest
            {

                CategoryName = categoryName,
                Page = page,
                PageSize = 20,
                Searching = searching
            });

            return View(products);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

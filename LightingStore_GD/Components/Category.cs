using LightingStore_GD.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightingStore_GD.Components
{
    public class Category : ViewComponent
    {
        IBrowsingAppService _browsingAppService;

        public Category(IBrowsingAppService browsingAppService)
        {
            _browsingAppService = browsingAppService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _browsingAppService.GetCategories(new Services.Models.Requests.GetCategoriesRequest { });

            return View(categories);
        }

    }
}

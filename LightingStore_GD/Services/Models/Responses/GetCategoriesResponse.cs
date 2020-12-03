using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightingStore_GD.Services.Models.Responses
{
    public class GetCategoriesResponse
    {
        public IEnumerable<Category> Categories { get; set; }

        public class Category
        {
            public int CategoryId { get; set; }
            public string Name { get; set; }
        }
    }
}

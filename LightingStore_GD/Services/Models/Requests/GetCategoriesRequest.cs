using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightingStore_GD.Services.Models.Requests
{
    public class GetCategoriesRequest
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}

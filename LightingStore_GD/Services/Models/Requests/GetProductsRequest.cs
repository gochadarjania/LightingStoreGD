﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightingStore_GD.Services.Models.Requests
{
    public class GetProductsRequest
    {
        public string ProductName { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public string Searching { get; set; }

    }
}

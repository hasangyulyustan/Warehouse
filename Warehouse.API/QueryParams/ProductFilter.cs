using System;
namespace Warehouse.API.QueryParams
{
    public class ProductFilter
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? Highlights { get; set; }
    }
}


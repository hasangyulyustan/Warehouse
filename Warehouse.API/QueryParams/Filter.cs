using System;
namespace Warehouse.API.QueryParams
{
    public class Filter
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? Highlights { get; set; }
    }
}


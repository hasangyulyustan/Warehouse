namespace Warehouse.API.Models.Requests
{
    public class ProductFilterRequest
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? Highlights { get; set; }
    }
}


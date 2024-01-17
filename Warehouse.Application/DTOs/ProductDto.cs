using Warehouse.Common.Extensions;
using Warehouse.Domain.Entities;

namespace Warehouse.Application.DTOs
{
	public class ProductDto
	{
        public string Title { get; set; }
        public decimal Price { get; set; }
        public List<string> Sizes { get; set; }
        public string Description { get; set; }

        public ProductDto(Product product, string[] highlights)
        {
            Title = product.Title;
            Price = product.Price;
            Sizes = product.Sizes;
            Description = product.Description.AddTags(highlights, "<em>", "</em>");
        }
    }
}


namespace Warehouse.Domain.Entities
{
	public class Product
	{
        public required string Title { get; set; }
        public decimal Price { get; set; }
        public required List<string> Sizes { get; set; }
        public required string Description { get; set; }
    }
}


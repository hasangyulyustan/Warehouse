namespace Warehouse.Application.DTOs
{
    public class FilteredProductsResponseDto
	{
        public required List<ProductDto> Products { get; set; }
        public required FilterDto Filter { get; set; }
    }
}


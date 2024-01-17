using System;
namespace Warehouse.Application.DTOs
{
	public class FilterDto
	{
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public required List<string> Sizes { get; set; }
        public required List<string> CommonWords { get; set; }
    }
}


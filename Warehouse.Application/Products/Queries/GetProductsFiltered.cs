using MediatR;
using Warehouse.Application.DTOs;

namespace Warehouse.Application.Products.Queries
{
    public record GetProductsFiltered : IRequest<FilteredProductsResponseDto>
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? Highlights { get; set; }
    }
}


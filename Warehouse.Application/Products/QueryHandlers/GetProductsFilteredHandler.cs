using MediatR;
using Warehouse.Application.DTOs;
using Warehouse.Application.Helpers;
using Warehouse.Application.Interfaces.Repositories;
using Warehouse.Application.Products.Queries;
using Warehouse.Domain.Entities;

namespace Warehouse.Application.Products.QueryHandlers
{
    public class GetProductsFilteredHandler : IRequestHandler<GetProductsFiltered, FilteredProductsResponseDto>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsFilteredHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<FilteredProductsResponseDto> Handle(GetProductsFiltered request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllProducts();

            IEnumerable<Product> filtered = products;

            if (request.MinPrice.HasValue)
            {
                filtered = filtered.Where(product => product.Price >= request.MinPrice);
            }

            if (request.MaxPrice.HasValue)
            {
                filtered = filtered.Where(product => product.Price <= request.MaxPrice);
            }


            var ordered = products.OrderBy(product => product.Price);


            HashSet<string> allSizes = new HashSet<string>();

            foreach (var product in ordered)
            {
                allSizes.UnionWith(new HashSet<string>(product.Sizes));
            }


            var allWords = new List<string>();


            foreach (var product in products)
            {
                allWords.AddRange(WordsCountHelper.GetWords(product.Description));
            }

            var orderedWords = allWords
              .GroupBy(x => x)
              .Select(x => new {
                  KeyField = x.Key,
                  Count = x.Count()
              })
              .OrderByDescending(x => x.Count)
              .Skip(5)
              .Take(10);

            var filter = new FilterDto
            {
                MinPrice = ordered.First().Price,
                MaxPrice = ordered.Last().Price,
                CommonWords = orderedWords.Select(x => x.KeyField).ToList(),
                Sizes = new List<string>(allSizes)
            };

            var highlightsArr = new string[0];

            if (request.Highlights is not null)
            {
                highlightsArr = request.Highlights.Split(",");
            }

            var response = new FilteredProductsResponseDto()
            {
                Products = filtered.Select(x => new ProductDto(x, highlightsArr)).ToList(),
                Filter = filter
            };


            return response;
        }
    }
}


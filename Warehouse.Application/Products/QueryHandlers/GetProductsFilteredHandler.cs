﻿using MediatR;
using Warehouse.Application.DTOs;
using Warehouse.Application.Helpers;
using Warehouse.Application.Interfaces.Repositories;
using Warehouse.Application.Products.Queries;
using Warehouse.Common.Extensions;
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

            // Filtering products by price
            IEnumerable<Product> filtered = products.FilterByMaxPrice(request.MaxPrice).FilterByMinPrice(request.MinPrice);

            var ordered = products.OrderBy(product => product.Price);

            // Using HashSet to get all existing sizes as a result
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

            // Getting most common 10 words skipping first 5
            var orderedWords = allWords
              .GroupBy(x => x)
              .Select(x => new {
                  KeyField = x.Key,
                  Count = x.Count()
              })
              .OrderByDescending(x => x.Count)
              .Skip(5)
              .Take(10);

            // Instantiating filter object. Still not sure if it is the best way. TBD
            var filter = new FilterDto
            {
                MinPrice = ordered.First().Price,
                MaxPrice = ordered.Last().Price,
                CommonWords = orderedWords.Select(x => x.KeyField).ToList(),
                Sizes = new List<string>(allSizes)
            };

            // Instantiating the final model. Also TBD
            var response = new FilteredProductsResponseDto()
            {
                Products = filtered.Select(x => new ProductDto(x, request.Highlights.GetHighlightsArray())).ToList(),
                Filter = filter
            };

            return response;
        }
    }
}


using Warehouse.Application.Interfaces.Repositories;
using Warehouse.Domain.Entities;
using Warehouse.Infrastructure.RestClient.Configuration;
using Warehouse.Infrastructure.RestClient.Products;


namespace Warehouse.Infrastructure
{
	public class ProductRemoteDataRepository : IProductRepository
    {
        private readonly ProductsRestClient _client;

        public ProductRemoteDataRepository(ProductsRestClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _client.GetAll();

            return products.ToList();
        }
    }
}


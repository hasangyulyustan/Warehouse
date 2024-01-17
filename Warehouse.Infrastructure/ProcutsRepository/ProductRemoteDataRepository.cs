using Warehouse.Application.Interfaces.Repositories;
using Warehouse.Domain.Entities;
using Warehouse.Infrastructure.RestClient.Configuration;
using Warehouse.Infrastructure.RestClient.Products;


namespace Warehouse.Infrastructure
{
	public class ProductRemoteDataRepository : IProductRepository
    {
        private readonly MockyProductsConfiguration _configuration;

        public ProductRemoteDataRepository(MockyProductsConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            ProductsRestClient client = new ProductsRestClient(_configuration);
            var products = await client.GetAll();

            return products.ToList();
        }
    }
}


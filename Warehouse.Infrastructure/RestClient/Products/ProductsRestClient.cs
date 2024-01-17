using Warehouse.Domain.Entities;
using Warehouse.Infrastructure.RestClient.Configuration;

namespace Warehouse.Infrastructure.RestClient.Products
{
	public class ProductsRestClient
	{
        private readonly RestClient<Product, string> _restClient;

        public ProductsRestClient(MockyProductsConfiguration configuration)
        {
            _restClient = new RestClient<Product, string>(configuration.Url);
        }

        public async Task<Product> Get(string id)
        {
            var result = await _restClient.GetAsync(id);
            return result;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var result = await _restClient.GetAll();
            return result;
        }
    }
}


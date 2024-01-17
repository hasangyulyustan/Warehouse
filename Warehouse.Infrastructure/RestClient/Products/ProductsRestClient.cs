using Warehouse.Common;
using Warehouse.Domain.Entities;

namespace Warehouse.Infrastructure.RestClient.Products
{
	public class ProductsRestClient
	{
        private readonly RestClient<Product, string> _restClient;

        public ProductsRestClient()
        {
            _restClient = new RestClient<Product, string>(Constants.BaseProductsUrl);
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


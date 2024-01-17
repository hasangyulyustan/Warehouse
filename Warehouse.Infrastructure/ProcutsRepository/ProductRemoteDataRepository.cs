using Warehouse.Application.Interfaces.Repositories;
using Warehouse.Domain.Entities;
using Warehouse.Infrastructure.RestClient.Products;


namespace Warehouse.Infrastructure
{
	public class ProductRemoteDataRepository : IProductRepository
    {
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            ProductsRestClient client = new ProductsRestClient();
            var products = await client.GetAll();

            return products.ToList();
        }
    }
}


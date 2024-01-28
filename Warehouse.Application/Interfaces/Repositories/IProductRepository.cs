using Warehouse.Domain.Entities;

namespace Warehouse.Application.Interfaces.Repositories
{
	public interface IProductRepository
	{
        Task<IEnumerable<Product>> GetAllProducts();
    }
}


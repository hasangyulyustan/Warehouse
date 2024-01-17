using Warehouse.Application.Interfaces.Repositories;
using Warehouse.Domain.Entities;

namespace Warehouse.Infrastructure;

public class ProductInMemoryRepository : IProductRepository
{
    public static List<Product> lstProducts = new List<Product>()
        {
           new Product {Price = 6.55m, Title = "Test Title", Description = "Test Description", Sizes = new List<string>{"Small", "Large" } }
        };

    public List<Product> GetAllProducts()
    {
        return lstProducts;
    }

    Task<IEnumerable<Product>> IProductRepository.GetAllProducts()
    {
        throw new NotImplementedException();
    }
}


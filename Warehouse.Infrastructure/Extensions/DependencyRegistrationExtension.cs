using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Options;
using Warehouse.Application.Interfaces.Repositories;
using Warehouse.Infrastructure.Constants;
using Warehouse.Infrastructure.RestClient.Configuration;
using Warehouse.Infrastructure.RestClient.Products;

namespace Warehouse.Infrastructure.Extensions
{
    public static class DependencyRegistrationExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductRepository, ProductMockRepository>();
            services.AddScoped<IProductRepository, ProductRemoteDataRepository>();
            _ = services.Configure<MockyProductsConfiguration>(configuration.GetSection(Configuration.MockyProductsUrlKey));
            services.AddSingleton(resolver =>
                    resolver.GetRequiredService<IOptions<MockyProductsConfiguration>>().Value);
            services.AddSingleton<ProductsRestClient>();

            return services;
        }
    }
}


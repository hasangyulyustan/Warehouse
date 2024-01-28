using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Warehouse.Application.Interfaces.Repositories;
using Warehouse.Common;
using Warehouse.Infrastructure.RestClient.Configuration;

namespace Warehouse.Infrastructure.Extensions
{
    public static class DependencyRegistrationExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductRepository, ProductRemoteDataRepository>();
            services.Configure<MockyProductsConfiguration>(configuration.GetSection(Constants.MockyProductsUrlKey));
            services.AddSingleton(resolver =>
                    resolver.GetRequiredService<IOptions<MockyProductsConfiguration>>().Value);

            return services;
        }
    }
}


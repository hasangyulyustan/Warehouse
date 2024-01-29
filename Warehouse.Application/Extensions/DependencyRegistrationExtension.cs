using Microsoft.Extensions.DependencyInjection;
using Warehouse.Application.Common.Logging;
using Warehouse.Application.Products.Queries;

namespace Warehouse.Application.Extensions
{
    public static class DependencyRegistrationExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssemblies(typeof(GetProductsFiltered).Assembly);
                cfg.AddOpenBehavior(typeof(LoggingPipelineBehavior<,>));
            });

            //TBD
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //TBD
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}


using MediatR;
using Microsoft.Extensions.Options;
using Warehouse.Application.Interfaces.Repositories;
using Warehouse.Application.Products.Queries;
using Warehouse.Common;
using Warehouse.Infrastructure;
using Warehouse.Infrastructure.RestClient.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register repositories
builder.Services.AddScoped<IProductRepository, ProductRemoteDataRepository>();

// Register mediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetProductsFiltered).Assembly));

builder.Services.Configure<MockyProductsConfiguration>(builder.Configuration.GetSection(Constants.MockyProductsUrlKey));
builder.Services.AddSingleton(resolver =>
        resolver.GetRequiredService<IOptions<MockyProductsConfiguration>>().Value);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


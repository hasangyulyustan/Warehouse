using MediatR;
using Microsoft.Extensions.Options;
using Serilog;
using Warehouse.Application.Common.Logging;
using Warehouse.Application.Extensions;
using Warehouse.Application.Interfaces.Repositories;
using Warehouse.Application.Products.Queries;
using Warehouse.Common;
using Warehouse.Infrastructure;
using Warehouse.Infrastructure.Extensions;
using Warehouse.Infrastructure.RestClient.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container for all layers.
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Logging with SERILOG
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

//Support to logging request with SERILOG
app.UseSerilogRequestLogging();

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


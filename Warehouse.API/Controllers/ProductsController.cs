using Microsoft.AspNetCore.Mvc;
using MediatR;
using Warehouse.Application.Products.Queries;
using Warehouse.Domain.Entities;

namespace Warehouse.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private IMediator _mediator;

    public ProductsController(IMediator mediator, ILogger<ProductsController> logger)
    {
        _logger = logger;
        _mediator = mediator;
    }

    // GET: api/<ProductController>
    [HttpGet]
    [Route("api/filter")]
    public async Task<ActionResult<IList<Product>>> GetFiltered(decimal? minPrice, decimal? maxPrice, string? highlights)
    {
        var getPerson = new GetProductsFiltered { MinPrice = minPrice, MaxPrice = maxPrice, Highlights = highlights};
        var result = await _mediator.Send(getPerson);

        return Ok(result);
    }
}


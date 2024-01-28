using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Products.Queries;
using Warehouse.Domain.Entities;
using Warehouse.API.Models.Requests;
using MediatR;

namespace Warehouse.API.Controllers;

public class ProductsController : BaseController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {}

    // GET: api/<ProductController>
    [HttpGet]
    [Route("api/filter")]
    public async Task<ActionResult<IList<Product>>> GetFiltered([FromQuery] ProductFilterRequest filter)
    {
        var getPerson = new GetProductsFiltered { MinPrice = filter.MinPrice, MaxPrice = filter.MaxPrice, Highlights = filter.Highlights};
        var result = await _mediator.Send(getPerson);

        return Ok(result);
    }
}


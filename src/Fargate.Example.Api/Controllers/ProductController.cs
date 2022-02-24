using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Fargate.Example.Api.Domain.Product;
using Bogus;

namespace Fargate.Example.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly Faker<Product> _productFactory = new Faker<Product>()
            .RuleFor(x => x.Name, f => f.Commerce.ProductName())
            .RuleFor(x => x.Description, f => f.Commerce.ProductDescription());

    private readonly IDynamoDBContext _context;

    public ProductController(IDynamoDBContext context)
        => (_context) = (context);

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var product = await _context.LoadAsync<Product>(id, nameof(Product));

        if (product is null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create()
    {
        var product = _productFactory.Generate();

        await _context.SaveAsync(product);

        return Ok(product);
    }
}

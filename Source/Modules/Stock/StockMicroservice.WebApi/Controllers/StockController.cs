using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockMicroservice.WebApi.Data;
using StockMicroservice.WebApi.Data.Entities;

namespace StockMicroservice.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly StockDbContext _stockDbContext;

    public StockController(StockDbContext stockDbContext)
    {
        _stockDbContext = stockDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _stockDbContext.Stocks.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(StockEntity stockCreate, CancellationToken cancellationToken)
    {
        await _stockDbContext.Stocks.AddAsync(stockCreate, cancellationToken);
        await _stockDbContext.SaveChangesAsync(cancellationToken);

        return Ok();
    }
}

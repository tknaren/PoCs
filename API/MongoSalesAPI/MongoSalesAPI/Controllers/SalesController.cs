using MongoSalesAPI.Models;
using MongoSalesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MongoSalesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesController : Controller
{
    private readonly ISalesService _salesService;
    private readonly ILogger _logger;

    public SalesController(ISalesService salesService, ILogger<SalesController> logger) 
    {
        _salesService = salesService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<List<Sale>> Get() => await _salesService.GetSalesAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Sale>> Get(string id)
    {
        var sale = await _salesService.GetSalesAsync(id);

        if(sale == null)
        {
            _logger.LogWarning("No data found for " + id);

            return NotFound();
            
        }

        return Ok(sale);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Sale newSale)
    {
        await _salesService.CreateAsync(newSale);

        _logger.LogInformation("New Sale created " + newSale.Id);

        //return the status-201, okay response with created object. So call the get method with the newly created objectid.
        return CreatedAtAction(nameof(Get), new { id = newSale.Id }, newSale);

    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Sale updatedSale)
    {
        var sale = await _salesService.GetSalesAsync(id);

        if (sale is null)
        {
            _logger.LogWarning("No data found for " + id);

            return NotFound();
        }


        updatedSale.Id = sale.Id;

        await _salesService.UpdateAsync(id, updatedSale);

        _logger.LogInformation("Sale got updated " + id);

        //returns the Status-204 - Okay but NoContent response
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _salesService.GetSalesAsync(id);

        if (book is null)
        {
            _logger.LogWarning("No data found for " + id);

            return NotFound();
        }

        await _salesService.DeleteAsync(id);

        _logger.LogInformation("Sale got deleted " + id);

        //returns the Status-204 - Okay but NoContent response
        return NoContent();
    }
}

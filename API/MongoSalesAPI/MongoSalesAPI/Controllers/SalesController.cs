using MongoSalesAPI.Models;
using MongoSalesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MongoSalesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesController : Controller
{
    private readonly SalesService _salesService;

    public SalesController(SalesService salesService) => _salesService = salesService;

    [HttpGet]
    public async Task<List<Sale>> Get() => await _salesService.GetSalesAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Sale>> Get(string id)
    {
        var sale = await _salesService.GetSalesAsync(id);

        if(sale == null)
        {
            return NotFound();  
        }

        return Ok(sale);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Sale newSale)
    {
        await _salesService.CreateAsync(newSale);

        //return the status-201, okay response with created object. So call the get method with the newly created objectid.
        return CreatedAtAction(nameof(Get), new { id = newSale.Id }, newSale);

    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Sale updatedSale)
    {
        var sale = await _salesService.GetSalesAsync(id);

        if (sale is null)
        {
            return NotFound();
        }

        updatedSale.Id = sale.Id;

        await _salesService.UpdateAsync(id, updatedSale);

        //returns the Status-204 - Okay but NoContent response
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _salesService.GetSalesAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _salesService.DeleteAsync(id);

        //returns the Status-204 - Okay but NoContent response
        return NoContent();
    }
}

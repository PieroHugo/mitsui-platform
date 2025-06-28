using CrewWeb.VehixPlatform.API.Sale.Application.Internals.Commands;
using CrewWeb.VehixPlatform.API.Sale.Application.Internals.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CrewWeb.VehixPlatform.API.Sale.Interfaces.REST;

/// <summary>
/// Bills endpoint exposing creation operation.
/// </summary>
[ApiController]
[Route("api/v1/bills")]
public class BillsController : ControllerBase
{
    private readonly CreateBillCommandHandler _handler;

    /// <summary>
    /// Constructor.
    /// </summary>
    public BillsController(CreateBillCommandHandler handler)
    {
        _handler = handler;
    }

    /// <summary>
    /// Creates a new bill.
    /// </summary>
    /// <param name="command">Bill data.</param>
    /// <returns>The created bill resource.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(BillResource), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> PostBill([FromBody] CreateBillCommand command)
    {
        try
        {
            var resource = await _handler.Handle(command, HttpContext.RequestAborted);
            return Created($"api/v1/bills/{resource.BillNumber}", resource);
        }
        catch (InvalidOperationException ex) when (ex.Message == "Invoice already exists")
        {
            return Conflict(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}

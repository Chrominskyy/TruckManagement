using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using TruckManagement.Application.Services;
using TruckManagement.Domain.Models;

namespace TruckManagement.Controllers;

[ApiController]
[Route("v1/trucks")]
public class TruckController : ControllerBase
{

    private readonly ITruckService _truckService;
    
    private readonly ILogger<TruckController> _logger;

    public TruckController(ILogger<TruckController> logger, ITruckService truckService)
    {
        _logger = logger;
        _truckService = truckService;
    }

    /// <summary>
    /// Get list of trucks registered in the system.
    /// </summary>
    /// <returns>List of trucks.</returns>
    [HttpGet]
    // [Produces(MediaTypeNames.Application.Json)]
    // [ProducesResponseType(typeof(List<Truck>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var ret = await _truckService.GetTrucksAsync();
        return Ok(ret);
    }
    
    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok(new { Message = "Hello, world!" });
    }

    /// <summary>
    /// Get truck by code.
    /// </summary>
    /// <param name="code"></param>
    /// <returns>Truck. <see cref="Truck"/></returns>
    [HttpGet("{code}")]
    [ProducesResponseType(typeof(Truck), StatusCodes.Status200OK)]
    public async Task<Truck> Get(string code)
    {
        return await _truckService.GetTruckByCodeAsync(code);
    }

    /// <summary>
    /// Add truck to the system.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    /// </remarks>
    /// <param name="truck">Truck <see cref="Truck"/>.</param>
    /// <returns>Added truck.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Truck), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([Required][FromBody] Truck truck)
    {
        return Ok(await _truckService.AddTruckAsync(truck));
    }

    /// <summary>
    /// Updates truck in the system.
    /// </summary>
    /// <param name="truck">Truck.</param>
    /// <returns>Updated truck.</returns>
    [HttpPut]
    [ProducesResponseType(typeof(Truck), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put([FromBody] Truck truck)
    {
        return Ok(await _truckService.UpdateTruckAsync(truck));
    }

    /// <summary>
    /// Removes truck from the system.
    /// </summary>
    /// <param name="code">Code.</param>
    /// <returns>Nothing</returns>
    [HttpDelete("{code}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(string code)
    {
        await _truckService.DeleteTruckAsync(code);
        return NoContent();
    }
    
}

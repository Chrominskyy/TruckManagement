using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using TruckManagement.Application.Services;
using TruckManagement.Domain.Enums;
using TruckManagement.Domain.Models;

namespace TruckManagement.Controllers;

[ApiController]
[Route("v1/trucks")]
public class TruckController : ControllerBase
{
    private static readonly string SomethingWentWrongMessage = "Something went wrong";
    private static readonly string TruckNotFoundMessage = "Truck not found";
    private static readonly string TruckAlreadyExistsMessage = "Truck with this code already exists";
    
    private readonly ITruckService _truckService;
    
    private readonly ILogger<TruckController> _logger;

    public TruckController(ILogger<TruckController> logger, ITruckService truckService)
    {
        _logger = logger;
        _truckService = truckService;
    }

    /// <summary>
    /// Gets list of trucks registered in the system.
    /// </summary>
    /// <returns>List of trucks.</returns>
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(List<Truck>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        return Ok(await _truckService.GetTrucksAsync());
    }

    /// <summary>
    /// Gets truck by code.
    /// </summary>
    /// <param name="code"></param>
    /// <returns>Truck. <see cref="Truck"/></returns>
    [HttpGet("{code}")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(Truck), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(string code)
    {
        var response = await _truckService.GetTruckByCodeAsync(code);
        return response != null?  Ok(response) : NotFound(new { message = TruckNotFoundMessage });
    }

    /// <summary>
    /// Adds truck to the system.
    /// </summary>
    /// <param name="truck">Truck <see cref="Truck"/>.</param>
    /// <returns>Added truck.</returns>
    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(Truck), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([Required][FromBody] Truck truck)
    {
        if(CheckIfTruckExists(truck.Code))
            return BadRequest(new {message = TruckAlreadyExistsMessage});
        
        var truckResponse = await _truckService.AddTruckAsync(truck);
        if(truckResponse == null)
            return BadRequest(new {message = SomethingWentWrongMessage});
        return Ok(truckResponse);
    }

    /// <summary>
    /// Updates truck in the system.
    /// </summary>
    /// <param name="truck">Truck.</param>
    /// <returns>Updated truck.</returns>
    [HttpPut]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(Truck), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put([FromBody] Truck truck)
    {
        if(!CheckIfTruckExists(truck.Code))
            return NotFound(new {message = TruckNotFoundMessage});
        
        var truckResponse = await _truckService.UpdateTruckAsync(truck);
        if(truckResponse == null)
            return BadRequest(new {message = SomethingWentWrongMessage});
        return Ok(truckResponse);
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
        var response = await _truckService.DeleteTruckAsync(code);
        return response? NoContent() : BadRequest(new { message = SomethingWentWrongMessage });
    }
    
    /// <summary>
    /// Gets list of truck filtered and sorted based on parameters.
    /// </summary>
    /// <param name="code">Code eg. "ABC123"</param>
    /// <param name="name">Name eg. "Truck Name 123"</param>
    /// <param name="status">StatusEnum eg. 3</param>
    /// <param name="sortColumn">Column that needs to be sorted by eg. "Name"</param>
    /// <param name="sortDirection">Direction "ASC" or "DESC"</param>
    /// <returns>List of trucks</returns>
    [HttpGet("search")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(List<Truck>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Search([FromQuery] string? code, [FromQuery] string? name, [FromQuery] StatusEnum? status, [FromQuery] string? sortColumn, [FromQuery] string? sortDirection )
    {
        return Ok(await _truckService.SearchTrucksAsync(code, name, status, sortColumn, sortDirection));
    }

    private bool CheckIfTruckExists(string code)
    {
        return _truckService.GetTruckByCodeAsync(code).Result != null;
    }
}

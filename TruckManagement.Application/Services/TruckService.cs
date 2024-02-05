using System.Collections;
using Microsoft.Extensions.Logging;
using TruckManagement.Domain.Enums;
using TruckManagement.Domain.Models;
using TruckManagement.Infrastructure.Repositories;

namespace TruckManagement.Application.Services;

/// <inheritdoc />
public class TruckService : ITruckService
{
    private readonly ITruckRepository _truckRepository;
    
    private readonly ILogger<TruckService> _logger;

    /// <summary>
    /// Default constructor for TruckService.
    /// </summary>
    /// <param name="truckRepository"></param>
    public TruckService(ITruckRepository truckRepository, ILogger<TruckService> logger)
    {
        _truckRepository = truckRepository;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Truck>> GetTrucksAsync()
    {
        _logger.LogDebug("GetTrucksAsync started");
        return await _truckRepository.GetTrucksAsync();
    }

    /// <inheritdoc />
    public async Task<Truck?> GetTruckByCodeAsync(string code)
    {
        _logger.LogDebug("GetTruckByCodeAsync started");
        return await _truckRepository.GetTruckByCodeAsync(code);
    }

    /// <inheritdoc />
    public async Task<Truck?> AddTruckAsync(Truck truck)
    {
        _logger.LogDebug("AddTruckAsync started");
        
        var returnedTruck = await _truckRepository.AddTruckAsync(truck);
        if(returnedTruck == null)
            _logger.LogError("AddTruckAsync failed");
        return returnedTruck;
    }

    /// <inheritdoc />
    public async Task<Truck?> UpdateTruckAsync(Truck truck)
    {
        _logger.LogDebug("UpdateTruckAsync started");
        
        var updatedTruck = await _truckRepository.UpdateTruckAsync(truck);
        if(updatedTruck == null)
            _logger.LogError("UpdateTruckAsync failed");
        
        return updatedTruck;
    }

    /// <inheritdoc />
    public async Task<bool> DeleteTruckAsync(string code)
    {
        _logger.LogDebug("DeleteTruckAsync started");
        var response = await _truckRepository.DeleteTruckAsync(code);
        
        return response;
    }
}
using System.Collections;
using Microsoft.Extensions.Logging;
using TruckManagement.Domain.Enums;
using TruckManagement.Domain.Models;
using TruckManagement.Infrastructure.Helpers;
using TruckManagement.Infrastructure.Repositories;

namespace TruckManagement.Application.Services;

/// <inheritdoc />
public class TruckService : ITruckService
{
    private readonly ITruckRepository _truckRepository;
    
    private readonly ILogger<TruckService> _logger;

    private readonly StatusHelper _statusHelper;

    /// <summary>
    /// Default constructor for TruckService.
    /// </summary>
    /// <param name="truckRepository"></param>
    public TruckService(ITruckRepository truckRepository, ILogger<TruckService> logger, StatusHelper statusHelper)
    {
        _truckRepository = truckRepository;
        _logger = logger;
        _statusHelper = statusHelper;
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

        var existingTruck = await _truckRepository.GetTruckByCodeAsync(truck.Code);
        var expectedStatus = _statusHelper.MoveToNextStatus(existingTruck.Status);
        if (truck.Status == StatusEnum.OutOfService)
            truck.Status = _statusHelper.MoveToOutOfService(truck.Status);
        
        if (truck.Status != existingTruck.Status &&
            existingTruck.Status != StatusEnum.OutOfService &&
            truck.Status != StatusEnum.OutOfService &&
            truck.Status != expectedStatus)
        {
            _logger.LogError("UpdateTruckAsync status is incorrect, expected: {ExpectedStatus}, actual: {ActualStatus}", expectedStatus, truck.Status);
            return null;
        }
        
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
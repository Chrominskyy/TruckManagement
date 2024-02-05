using System.Collections;
using TruckManagement.Domain.Models;
using TruckManagement.Infrastructure.Repositories;

namespace TruckManagement.Application.Services;

/// <inheritdoc />
public class TruckService : ITruckService
{
    private readonly ITruckRepository _truckRepository;

    public TruckService(ITruckRepository truckRepository)
    {
        _truckRepository = truckRepository;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Truck>> GetTrucksAsync()
    {
        return await _truckRepository.GetTrucksAsync();
    }

    /// <inheritdoc />
    public async Task<Truck> GetTruckByCodeAsync(string code)
    {
        return await _truckRepository.GetTruckByCodeAsync(code);
    }

    /// <inheritdoc />
    public async Task<Truck> AddTruckAsync(Truck truck)
    {
        return await _truckRepository.AddTruckAsync(truck);
    }

    /// <inheritdoc />
    public async Task<Truck> UpdateTruckAsync(Truck truck)
    {
        return await _truckRepository.UpdateTruckAsync(truck);
    }

    /// <inheritdoc />
    public async Task<bool> DeleteTruckAsync(string code)
    {
        var deleteTask = _truckRepository.DeleteTruckAsync(code);
        
        //TODO: Fix cancellationToken
        await deleteTask.WaitAsync(new CancellationToken());
        
        return deleteTask.IsCompletedSuccessfully;
    }
}
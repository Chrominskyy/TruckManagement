using TruckManagement.Domain.Models;

namespace TruckManagement.Infrastructure.Repositories;

/// <summary>
/// Repository for managing truck data.
/// </summary>
public interface ITruckRepository
{
    /// <summary>
    /// Used to list all trucks.
    /// </summary>
    /// <returns>List of trucks.</returns>
    public Task<List<Truck>> GetTrucksAsync();
    
    /// <summary>
    /// Used to get specific truck by code.
    /// </summary>
    /// <param name="code">Code string.</param>
    /// <returns>Truck <see cref="Truck"/>.</returns>
    public Task<Truck> GetTruckByCodeAsync(string code);
    
    /// <summary>
    /// Used to add truck.
    /// </summary>
    /// <param name="truck">Truck data <see cref="Truck"/>.</param>
    /// <returns>Added truck <see cref="Truck"/>.</returns>
    public Task<Truck> AddTruckAsync(Truck truck);
    
    /// <summary>
    /// Used to update truck.
    /// </summary>
    /// <param name="truck">Truck data <see cref="Truck"/>.</param>
    /// <returns>Updated truck <see cref="Truck"/>.</returns>
    public Task<Truck> UpdateTruckAsync(Truck truck);
    
    /// <summary>
    /// Used to remove truck.
    /// </summary>
    /// <param name="code">Code string.</param>
    /// <returns>Nothing.</returns>
    public Task DeleteTruckAsync(string code);
}
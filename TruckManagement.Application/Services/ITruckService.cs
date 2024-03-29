using TruckManagement.Domain.Enums;
using TruckManagement.Domain.Models;

namespace TruckManagement.Application.Services;

/// <summary>
/// Service for managing truck data.
/// </summary>
public interface ITruckService
{
    /// <summary>
    /// Used to list all trucks.
    /// </summary>
    /// <returns>List of trucks.</returns>
    public Task<IEnumerable<Truck>> GetTrucksAsync();
    
    /// <summary>
    /// Used to get specific truck by code.
    /// </summary>
    /// <param name="code">Code string.</param>
    /// <returns>Truck <see cref="Truck"/>.</returns>
    public Task<Truck?> GetTruckByCodeAsync(string code);
    
    /// <summary>
    /// Used to add truck.
    /// </summary>
    /// <param name="truck">Truck data <see cref="Truck"/>.</param>
    /// <returns>Added truck <see cref="Truck"/>.</returns>
    public Task<Truck?> AddTruckAsync(Truck truck);
    
    /// <summary>
    /// Used to update truck.
    /// </summary>
    /// <param name="truck">Truck data <see cref="Truck"/>.</param>
    /// <returns>Updated truck <see cref="Truck"/>.</returns>
    public Task<Truck?> UpdateTruckAsync(Truck truck);
    
    /// <summary>
    /// Used to remove truck.
    /// </summary>
    /// <param name="code">Code string.</param>
    /// <returns>True/false whether deletion was completed. Note: It will return True if truck with specific code wasn't found.</returns>
    public Task<bool> DeleteTruckAsync(string code);
    
    /// <summary>
    /// Used to filter and sort list of trucks.
    /// </summary>
    /// <param name="code">Code string</param>
    /// <param name="name">Name string</param>
    /// <param name="status">StatusEnum value <see cref="StatusEnum"/></param>
    /// <param name="sortColumn">Sort column name</param>
    /// <param name="sortDirection">Sort direction</param>
    /// <returns>Filtered and sorted list of trucks.</returns>
    public Task<List<Truck>> SearchTrucksAsync(string? code, string? name, StatusEnum? status, string? sortColumn, string? sortDirection );
}
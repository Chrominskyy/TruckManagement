using TruckManagement.Domain.Enums;

namespace TruckManagement.Domain.Models;

/// <summary>
/// Data transfer object for Truck entity.
/// </summary>
public class TruckDto : Truck
{
    /// <summary>
    /// Id of entity in database - Guid
    /// </summary>
    public Guid Id { get; set; }

    /// <inheritdoc />
    public TruckDto(string code, string name, string description, StatusEnum status) : base(code, name, description, status)
    {
        Id = Guid.NewGuid();
    }
}
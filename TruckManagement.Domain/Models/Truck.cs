using TruckManagement.Domain.Enums;

namespace TruckManagement.Domain.Models;

/// <summary>
/// Truck model.
/// </summary>
public class Truck
{
    /// <summary>
    /// Unique alphanumeric code given by the user.
    /// </summary>
    /// <example> ABC123 </example>
    public string Code { get; set; }
    
    /// <summary>
    /// A name of a truck.
    /// </summary>
    /// <example> ABC Truck </example>
    public string Name { get; set; }
    
    /// <summary>
    /// A description of a truck.
    /// </summary>
    /// <example> ABC Truck is used only to transport livestock. DO NOT TRANSPORT hay with it. </example>
    public string Description { get; set; }
    
    /// <summary>
    /// Truck status <see cref="StatusEnum"/>
    /// </summary>
    public StatusEnum Status { get; set; }

    /// <summary>
    /// Default constructor for Truck object.
    /// </summary>
    /// <param name="code">Unique code.</param>
    /// <param name="name">Name.</param>
    /// <param name="description">Description</param>
    /// <param name="status">Status <see cref="StatusEnum"/>.</param>
    public Truck(string code, string name, string description, StatusEnum status)
    {
        Code = code;
        Name = name;
        Description = description;
        Status = status;
    }
}
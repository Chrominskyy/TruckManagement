namespace TruckManagement.Domain.Enums;

/// <summary>
/// Status enum.
/// You can use both numeric and string representations of enum:
/// * 0 - OutOfService,
/// * 1 - Loading,
/// * 2 - ToJob,
/// * 3 - AtJob,
/// * 4 - Returning
/// </summary>
public enum StatusEnum
{
    /// <summary>
    /// 0 - OutOfService
    /// </summary>
    OutOfService,
    /// <summary>
    /// 1 - Loading
    /// </summary>
    Loading,
    /// <summary>
    /// 2 - ToJob
    /// </summary>
    ToJob,
    /// <summary>
    /// 3 - AtJob
    /// </summary>
    AtJob,
    /// <summary>
    /// 4 - Returning
    /// </summary>
    Returning
}
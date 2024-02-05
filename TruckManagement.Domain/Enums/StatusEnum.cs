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

/// <summary>
/// Status enum class to manage statuses.
/// </summary>
public class Status
{
    /// <summary>
    /// Used to get status string.
    /// </summary>
    /// <param name="status"></param>
    /// <returns>String representation of status.</returns>
    public string GetStatusString(StatusEnum status)
    {
        return status switch
        {
            StatusEnum.OutOfService => "Out of Service",
            StatusEnum.Loading => "Loading",
            StatusEnum.ToJob => "To Job",
            StatusEnum.AtJob => "At Job",
            StatusEnum.Returning => "Returning",
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
        };
    }

    /// <summary>
    /// Used to push status forward.
    /// </summary>
    /// <param name="currentStatus">Current instance of StatusEnum.</param>
    /// <returns></returns>
    public StatusEnum MoveToNextStatus(StatusEnum currentStatus)
    {
        return currentStatus switch
        {
            StatusEnum.OutOfService => StatusEnum.Loading,
            StatusEnum.Loading => StatusEnum.ToJob,
            StatusEnum.ToJob => StatusEnum.AtJob,
            StatusEnum.AtJob => StatusEnum.Returning,
            StatusEnum.Returning => StatusEnum.Loading,
            _ => StatusEnum.OutOfService
        };
    }

    /// <summary>
    /// Used to change status to Out of Service.
    /// </summary>
    /// <param name="currentStatus">Current instance of StatusEnum.</param>
    /// <returns>Updated status.</returns>
    public StatusEnum MoveToOutOfService(StatusEnum currentStatus)
    {
        return StatusEnum.OutOfService;
    }

}
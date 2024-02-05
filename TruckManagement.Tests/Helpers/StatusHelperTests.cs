using TruckManagement.Domain.Enums;
using TruckManagement.Infrastructure.Helpers;

namespace TruckManagement.Tests.Helpers;

[TestClass]
public class StatusHelperTests
{
    // Setup
    private readonly StatusHelper _statusHelper = new();
    
    [TestMethod]
    public void MoveToNextStatus_FromOutOfService_ReturnsLoading()
    {
        var result = _statusHelper.MoveToNextStatus(StatusEnum.OutOfService);
        Assert.AreEqual(StatusEnum.Loading, result);
    }

    [TestMethod]
    public void MoveToNextStatus_FromLoading_ReturnsToJob()
    {
        var result = _statusHelper.MoveToNextStatus(StatusEnum.Loading);
        Assert.AreEqual(StatusEnum.ToJob, result);
    }

    [TestMethod]
    public void MoveToNextStatus_FromToJob_ReturnsAtJob()
    {
        var result = _statusHelper.MoveToNextStatus(StatusEnum.ToJob);
        Assert.AreEqual(StatusEnum.AtJob, result);
    }

    [TestMethod]
    public void MoveToNextStatus_FromAtJob_ReturnsReturning()
    {
        var result = _statusHelper.MoveToNextStatus(StatusEnum.AtJob);
        Assert.AreEqual(StatusEnum.Returning, result);
    }

    [TestMethod]
    public void MoveToNextStatus_FromReturning_ReturnsLoading()
    {
        var result = _statusHelper.MoveToNextStatus(StatusEnum.Returning);
        Assert.AreEqual(StatusEnum.Loading, result);
    }

    [TestMethod]
    public void MoveToNextStatus_FromInvalidStatus_ReturnsOutOfService()
    {
        var invalidStatus = (StatusEnum)999;
        var result = _statusHelper.MoveToNextStatus(invalidStatus);
        Assert.AreEqual(StatusEnum.OutOfService, result);
    }
    
    [TestMethod]
    public void MoveToNextStatus_WithMaxEnumValue_ReturnsOutOfService()
    {
        var maxEnumValue = (StatusEnum)int.MaxValue;
        var result = _statusHelper.MoveToNextStatus(maxEnumValue);
        Assert.AreEqual(StatusEnum.OutOfService, result);
    }

    [TestMethod]
    public void MoveToNextStatus_WithMinEnumValue_ReturnsExpectedValueOrOutOfService()
    {
        var minEnumValue = (StatusEnum)int.MinValue;
        var expectedResult = StatusEnum.OutOfService;
        var result = _statusHelper.MoveToNextStatus(minEnumValue);
        Assert.AreEqual(expectedResult, result);
    }
    
    [TestMethod]
    public void MoveToNextStatus_WithUndefinedEnumValueAdjacentToDefined_ReturnsOutOfService()
    {
        var undefinedStatus = StatusEnum.Returning + 1;
        var result = _statusHelper.MoveToNextStatus(undefinedStatus);
        Assert.AreEqual(StatusEnum.OutOfService, result);
    }
}
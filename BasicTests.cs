using Xunit;
using UstaPlatform.Domain.Entities;

namespace UstaPlatform.Tests;

public class BasicTests
{
    [Fact]
    public void WorkOrder_Creation_ShouldWork()
    {
        // Arrange & Act - Object Initializer kullan
        var workOrder = new WorkOrder
        {
            Id = 1,
            RequestId = 1,
            MasterId = 1,
            BasePrice = 100m,
            ScheduledDate = DateTime.Now
        };

        // Assert
        Assert.NotNull(workOrder);
        Assert.Equal(100m, workOrder.BasePrice);
        Assert.Equal(1, workOrder.RequestId);
    }

    [Fact]
    public void Master_Creation_ShouldWork()
    {
        // Arrange & Act - Object Initializer kullan
        var master = new Master
        {
            Id = 1,
            Name = "Ahmet Tesisatçı",
            Expertise = "Tesisat",
            Location = "Merkez",
            Rating = 4.5,
            Workload = 2
        };

        // Assert
        Assert.NotNull(master);
        Assert.Equal("Ahmet Tesisatçı", master.Name);
        Assert.Equal("Tesisat", master.Expertise);
    }

    [Fact]
    public void Master_WithConstructor_ShouldWork()
    {
        // Arrange & Act - Constructor kullan
        var master = new Master("Mehmet Elektrikçi", "Elektrik", "Merkez");

        // Assert
        Assert.NotNull(master);
        Assert.Equal("Mehmet Elektrikçi", master.Name);
        Assert.Equal("Elektrik", master.Expertise);
    }
}
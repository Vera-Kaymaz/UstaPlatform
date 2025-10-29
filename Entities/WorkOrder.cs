namespace UstaPlatform.Domain.Entities;

public class WorkOrder
{
    public int Id { get; init; }
    public int RequestId { get; init; }
    public int MasterId { get; init; }
    public decimal BasePrice { get; init; }
    public decimal FinalPrice { get; set; }
    public DateTime ScheduledDate { get; init; }
    public string Status { get; set; } = "Planlandı";
    public List<(int X, int Y)> RoutePoints { get; set; } = new();

    // Parameterless constructor
    public WorkOrder() { }

    // Constructor with parameters - DÜZELTİLDİ
    public WorkOrder(int requestId, int masterId, decimal basePrice, DateTime scheduledDate)
    {
        RequestId = requestId;
        MasterId = masterId;
        BasePrice = basePrice;
        ScheduledDate = scheduledDate;
        FinalPrice = basePrice;
    }
}
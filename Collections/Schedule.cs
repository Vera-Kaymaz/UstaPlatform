using UstaPlatform.Domain.Entities;
using UstaPlatform.Infrastructure.Helpers; // Bu satırı ekleyin

namespace UstaPlatform.Infrastructure.Collections;

public class Schedule
{
    private readonly Dictionary<DateOnly, List<WorkOrder>> _dailySchedule = new();

    // Dizinleyici (Indexer)
    public List<WorkOrder> this[DateOnly date]
    {
        get
        {
            if (!_dailySchedule.ContainsKey(date))
                _dailySchedule[date] = new List<WorkOrder>();

            return _dailySchedule[date];
        }
    }

    public void AddWorkOrder(WorkOrder workOrder)
    {
        Guard.AgainstNull(workOrder, nameof(workOrder));
        var date = DateOnly.FromDateTime(workOrder.ScheduledDate);
        this[date].Add(workOrder);
    }

    public IEnumerable<WorkOrder> GetWorkOrdersForDate(DateOnly date) => this[date];

    public bool HasWorkOrdersForDate(DateOnly date) => _dailySchedule.ContainsKey(date) && _dailySchedule[date].Count > 0;
}
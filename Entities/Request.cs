using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain.Entities;

public class Request
{
    public int Id { get; init; }
    public int CitizenId { get; init; }
    public required string Description { get; init; }
    public required string ServiceType { get; init; }
    public required string Location { get; init; }
    public DateTime RequestDate { get; init; } = DateTime.Now;
    public bool IsUrgent { get; init; }

    public Request() { }

    public Request(int citizenId, string description, string serviceType, string location, bool isUrgent = false)
    {
        CitizenId = citizenId;
        Description = description;
        ServiceType = serviceType;
        Location = location;
        IsUrgent = isUrgent;
    }
}

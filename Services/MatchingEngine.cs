using UstaPlatform.Domain.Entities;
using UstaPlatform.Infrastructure.Helpers;

namespace UstaPlatform.App.Services;

public class MatchingEngine
{
    public Master? FindBestMaster(Request request, List<Master> availableMasters)
    {
        Guard.AgainstNull(request, nameof(request));
        Guard.AgainstNull(availableMasters, nameof(availableMasters));

        var suitableMasters = availableMasters
            .Where(m => m.Expertise == request.ServiceType)
            .OrderBy(m => m.Workload)
            .ThenByDescending(m => m.Rating)
            .ToList();

        return suitableMasters.FirstOrDefault();
    }
}
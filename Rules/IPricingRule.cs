using UstaPlatform.Domain.Entities;

namespace UstaPlatform.Pricing.Interfaces;

public interface IPricingRule
{
    string RuleName { get; }
    decimal Apply(decimal basePrice, WorkOrder workOrder);
}
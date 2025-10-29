using UstaPlatform.Domain.Entities;
using UstaPlatform.Pricing.Interfaces;

namespace UstaPlatform.Pricing.Rules;

public class UrgentPricingRule : IPricingRule
{
    public string RuleName => "Acil Çağrı Ücreti";

    public decimal Apply(decimal basePrice, WorkOrder workOrder)
    {
        return workOrder.Status.Contains("Acil") ? basePrice * 1.5m : basePrice;
    }
}
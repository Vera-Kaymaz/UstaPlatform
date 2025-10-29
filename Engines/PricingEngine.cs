using System.Reflection;
using UstaPlatform.Domain.Entities;
using UstaPlatform.Pricing.Interfaces;

namespace UstaPlatform.Pricing;

public class PricingEngine
{
    private readonly List<IPricingRule> _rules = new();

    public void AddRule(IPricingRule rule)
    {
        if (rule == null)
            throw new ArgumentNullException(nameof(rule));

        _rules.Add(rule);
    }

    public decimal CalculateFinalPrice(decimal basePrice, WorkOrder workOrder)
    {
        decimal currentPrice = basePrice;

        foreach (var rule in _rules)
        {
            currentPrice = rule.Apply(currentPrice, workOrder);
            Console.WriteLine($"{rule.RuleName} uygulandı. Yeni fiyat: {currentPrice:C}");
        }

        return currentPrice;
    }

    public void LoadRulesFromAssembly(string assemblyPath)
    {
        if (!File.Exists(assemblyPath))
        {
            Console.WriteLine($"DLL bulunamadı: {assemblyPath}");
            return;
        }

        try
        {
            var assembly = Assembly.LoadFrom(assemblyPath);
            var ruleTypes = assembly.GetTypes()
                .Where(t => typeof(IPricingRule).IsAssignableFrom(t) &&
                           !t.IsInterface && !t.IsAbstract);

            foreach (var type in ruleTypes)
            {
                var rule = Activator.CreateInstance(type) as IPricingRule;
                if (rule != null)
                {
                    _rules.Add(rule);
                    Console.WriteLine($"Yeni kural yüklendi: {rule.RuleName}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Kural yüklenirken hata: {ex.Message}");
        }
    }

    public IEnumerable<string> GetActiveRules() => _rules.Select(r => r.RuleName);
}
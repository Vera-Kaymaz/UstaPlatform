namespace UstaPlatform.Infrastructure.Helpers;

public static class MoneyFormatter
{
    public static string Format(decimal amount) => $"{amount:C}";

    public static string FormatWithCurrency(decimal amount, string currencyCode = "TRY")
    {
        return $"{amount:N2} {currencyCode}";
    }
}
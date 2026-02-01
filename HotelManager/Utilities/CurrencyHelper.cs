using System.Globalization;

namespace HotelManager.Utilities
{
    public static class CurrencyHelper
    {
        private static readonly CultureInfo ZarCulture = new CultureInfo("en-ZA");

        public static string FormatToRands(decimal amount)
        {
            return amount.ToString("C", ZarCulture);
        }

        public static string FormatToRandsNoSymbol(decimal amount)
        {
            return amount.ToString("N2", ZarCulture) + " ZAR";
        }

        public static decimal ConvertToRands(decimal amount, string fromCurrency)
        {
            // Simple conversion rates (in real app, use API or current rates)
            var conversionRates = new Dictionary<string, decimal>
            {
                { "USD", 18.50m },
                { "EUR", 20.00m },
                { "GBP", 23.00m },
                { "ZAR", 1.00m }
            };

            if (conversionRates.ContainsKey(fromCurrency.ToUpper()))
            {
                return amount * conversionRates[fromCurrency.ToUpper()];
            }

            return amount; // Default to original if currency not found
        }
    }
}
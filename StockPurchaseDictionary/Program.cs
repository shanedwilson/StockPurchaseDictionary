using System;
using System.Collections.Generic;
using System.Linq;

namespace StockPurchaseDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> stocks = new Dictionary<string, string>();
            List<(string ticker, double shares, double price)> purchases = new List<(string, double, double)>();
            Dictionary<string, double> aggregatedPurchases = new Dictionary<string, double>();
            double updatedValuation = 0;

            stocks.Add("AAPL", "Apple");
            stocks.Add("SPOT", "Spotify");
            stocks.Add("TSLA", "Tesla");
            stocks.Add("AMZN", "Amazon");
            stocks.Add("PYPL", "PayPal");

            purchases.Add((ticker: "AAPL", shares: 150, price: 173.48));
            purchases.Add((ticker: "AAPL", shares: 32, price: 170.32));
            purchases.Add((ticker: "AAPL", shares: 80, price: 171.53));
            purchases.Add((ticker: "SPOT", shares: 100, price: 145.16));
            purchases.Add((ticker: "SPOT", shares: 41, price: 139.96));
            purchases.Add((ticker: "SPOT", shares: 63, price: 140.02));
            purchases.Add((ticker: "TSLA", shares: 95, price: 276.80));
            purchases.Add((ticker: "TSLA", shares: 22, price: 275.19));
            purchases.Add((ticker: "TSLA", shares: 73, price: 275.11));
            purchases.Add((ticker: "AMZN", shares: 1, price: 1603.98));
            purchases.Add((ticker: "AMZN", shares: 1, price: 1609.52));
            purchases.Add((ticker: "AMZN", shares: 80, price: 1604.24));
            purchases.Add((ticker: "PYPL", shares: 88, price: 95.16));
            purchases.Add((ticker: "PYPL", shares: 13, price: 94.82));
            purchases.Add((ticker: "PYPL", shares: 22, price: 95.75));

            var ownershipReport =
                stocks.Join(purchases, (stock => stock.Key), (purchase => purchase.ticker),
                            ((stock, purchase) => new { Name = stock.Value, Valuation = (purchase.shares * purchase.price) }));
            //.ToDictionary(t => t.Name, t => t.Valuation);

            foreach (var stock in ownershipReport)
            {
                if (aggregatedPurchases.ContainsKey(stock.Name))
                {
                    aggregatedPurchases[stock.Name] = aggregatedPurchases[stock.Name] + (stock.Valuation);
                } else
                {
                    aggregatedPurchases.Add(stock.Name, stock.Valuation);
                }
            }

            foreach (var stock in aggregatedPurchases)
            {
                Console.WriteLine($"You own ${stock.Value} of {stock.Key}.");
            }

            Console.ReadKey();
        }
    }
}

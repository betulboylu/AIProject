using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AIProject.Services
{
    public class DataGeneratorService
    {
        private static readonly Random _rand = new();

        private static readonly string[] MerchantCategories = { "Grocery", "Electronics", "Clothing", "Restaurants", "Gas", "Travel" };
        private static readonly string[] Locations = { "NY", "CA", "TX", "FL", "IL", "WA" };
        private static readonly string[] TransactionTypes = { "Online", "In-Store" };

        /// <summary>
        /// Generates transaction data to train the model
        /// Uses it to predict fraud
        /// </summary>
        public static void GenerateDataCsv(string filePath, int numRows = 10000)
        {
            using var writer = new StreamWriter(filePath);
            writer.WriteLine("TransactionId,Amount,HourOfDay,MerchantCategory,Location,TransactionType,HistoricalAvgAmount,NumTransactionsLast24h,IsFraud");

            for (int i = 1; i <= numRows; i++)
            {
                var amount = GenerateAmount();
                var hour = _rand.Next(0, 24);
                var category = MerchantCategories[_rand.Next(MerchantCategories.Length)];
                var location = Locations[_rand.Next(Locations.Length)];
                var transactionType = TransactionTypes[_rand.Next(TransactionTypes.Length)];
                var historicalAvg = Math.Max(1f, (float)(amount * (0.5 + _rand.NextDouble())));
                var numTxLast24h = _rand.Next(0, 10);

                double fraudRisk = 0.0;
                if (amount > 1000) fraudRisk += 0.4;
                if (hour < 6 || hour > 22) fraudRisk += 0.3;
                if (transactionType == "Online") fraudRisk += 0.2;
                if (numTxLast24h == 0) fraudRisk += 0.1;

                bool isFraud = _rand.NextDouble() < fraudRisk;

                var line = string.Join(",",
                    i,
                    amount.ToString("F2", CultureInfo.InvariantCulture),
                    hour,
                    category,
                    location,
                    transactionType,
                    historicalAvg.ToString("F2", CultureInfo.InvariantCulture),
                    numTxLast24h,
                    isFraud ? 1 : 0);

                writer.WriteLine(line);
            }
        }

        private static float GenerateAmount()
        {
            var baseAmount = (float)(_rand.NextDouble() * 200);
            if (_rand.NextDouble() < 0.05)
                baseAmount += (float)(_rand.NextDouble() * 3000);
            return baseAmount;
        }


        /// <summary>
        /// Generates sentiment data to train the model
        /// Saves it as a CSV file on desktop
        /// </summary>
        public static void GenerateData()
        {
            // Sample phrases for text generation
            List<string> positivePhrases = new List<string>
            {
                "I love this product",
                "The experience was amazing",
                "What a great day",
                "I feel so happy right now",
                "This is fantastic",
                "I'm so excited about this",
                "Totally worth it",
                "Highly recommend it",
                "This place is awesome",
                "Best decision ever"
            };

            List<string> negativePhrases = new List<string>
            {
                "I hate this product",
                "The service was awful",
                "I'm so disappointed",
                "This is a complete failure",
                "Such a waste of time",
                "Worst purchase ever",
                "Never coming back here",
                "Really bad experience",
                "Terrible service",
                "So upset with it"
            };

            // Create a list to hold the data
            List<Tuple<string, string>> data = new List<Tuple<string, string>>();

            // Random number generator
            Random random = new Random();

            // Generate 10,000 entries
            for (int i = 0; i < 10000; i++)
            {
                bool sentiment = random.Next(0, 2) == 0; // Randomly choose between True and False
                string text = sentiment ? positivePhrases[random.Next(positivePhrases.Count)] : negativePhrases[random.Next(negativePhrases.Count)];
                string sentimentString = sentiment ? "true" : "false";

                data.Add(new Tuple<string, string>(text, sentimentString));
            }

            // Define the CSV file path
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "sentiment_dataset.csv");

            // Write to CSV
            using (var writer = new StreamWriter(filePath))
            {
                // Write the header
                writer.WriteLine("text,sentiment");

                // Write the data rows
                foreach (var entry in data)
                {
                    writer.WriteLine($"{entry.Item1},{entry.Item2}");
                }
            }

            Console.WriteLine($"Dataset with 10,000 entries generated and saved to {filePath}");
        }
    }
}

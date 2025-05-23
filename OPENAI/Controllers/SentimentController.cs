using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AIProject.Models;
using AIProject.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AIProject.Controllers
{
    public class SentimentController : Controller
    {
        private readonly MLModelBuilder _mlModelBuilder;

        public SentimentController(MLModelBuilder mlModelBuilder)
        {
            _mlModelBuilder = mlModelBuilder;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //GenerateData();
            return View();
        }

        /// <summary>
        /// Gets two parameters from user; Text and File
        /// Decides the sentiment of the Text after training the model with File
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Index(Prediction mod)
        {
            if (ModelState.IsValid)
            {
                if (mod.File != null && mod.File.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", mod.File.FileName);

                    // Ensure the uploads folder exists
                    var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    // Save the file
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        mod.File.CopyToAsync(stream);
                    }

                    // Train the model with the uploaded CSV file
                    var model = _mlModelBuilder.TrainModel(filePath);
                    List<SentimentPrediction> predictions = new List<SentimentPrediction>();

                    if (!String.IsNullOrEmpty(mod.Text))
                    {
                        var sentimentData = new SentimentData() { Text = mod.Text };
                        var prediction = _mlModelBuilder.PredictSentiment(sentimentData);
                        prediction.Text = mod.Text;
                        predictions.Add(prediction);
                    }
                    return View("Result", predictions);
                }
                return View("Result", null);
            }
            else
                return View("Index");

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

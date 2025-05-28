using AIProject.Models;
using AIProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AIProject.Controllers
{
    public class FraudController : Controller
    {
        private readonly FraudService _fraudModel;

        public FraudController()
        {
            _fraudModel = new FraudService();
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewBag.Error = "Please upload a valid CSV file.";
                return View("Index");
            }

            var uploads = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            if (!Directory.Exists(uploads))
                Directory.CreateDirectory(uploads);

            var filePath = Path.Combine(uploads, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Train model on uploaded data
            _fraudModel.Train(filePath);

            // Read transactions and predict fraud
            var transactions = new List<TransactionData>();
            using (var reader = new StreamReader(filePath))
            {
                var header = await reader.ReadLineAsync(); // skip header

                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    var parts = line.Split(',');

                    if (parts.Length == 9)
                    {
                        transactions.Add(new TransactionData
                        {
                            TransactionId = parts[0],
                            Amount = float.Parse(parts[1], CultureInfo.InvariantCulture),
                            HourOfDay = float.Parse(parts[2], CultureInfo.InvariantCulture),
                            MerchantCategory = parts[3],
                            Location = parts[4],
                            TransactionType = parts[5],
                            HistoricalAvgAmount = float.Parse(parts[6], CultureInfo.InvariantCulture),
                            NumTransactionsLast24h = float.Parse(parts[7], CultureInfo.InvariantCulture),
                            // We ignore IsFraud here because we want to predict
                        });
                    }
                }
            }

            // Get predictions
            var results = transactions.Select(t =>
            {
                var prediction = _fraudModel.Predict(t);
                return new TransactionResultViewModel
                {
                    TransactionId = t.TransactionId,
                    Amount = t.Amount,
                    HourOfDay = t.HourOfDay,
                    MerchantCategory = t.MerchantCategory,
                    Location = t.Location,
                    TransactionType = t.TransactionType,
                    HistoricalAvgAmount = t.HistoricalAvgAmount,
                    NumTransactionsLast24h = t.NumTransactionsLast24h,
                    IsFraudPredicted = prediction.IsFraud,
                    Score = prediction.Score
                };
            }).ToList();

            return View("Result", results);
        }
    }
}

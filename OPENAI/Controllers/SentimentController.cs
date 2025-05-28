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
        private readonly SentimentService _mlModelBuilder;

        private readonly DataGeneratorService _syntheticDataService;

        public SentimentController(SentimentService mlModelBuilder, DataGeneratorService  syntheticDataService)
        {
            _mlModelBuilder = mlModelBuilder;
            _syntheticDataService = syntheticDataService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //_syntheticDataService.GenerateData();
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
    }
}

using AIProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AIProject.Controllers
{
    public class SummarizerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SummarizerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Summarize(SummarizeViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.InputText))
            {
                ModelState.AddModelError("", "Text is required");
                return View("Index", model);
            }

            // Call HuggingFace summarization model (or any API)
            var client = _httpClientFactory.CreateClient();


            client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", "******");

            var content = new StringContent(JsonSerializer.Serialize(new { inputs = model.InputText }), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://api-inference.huggingface.co/models/sshleifer/distilbart-cnn-12-6", content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<JsonElement>(json);
                model.Summary = result[0].GetProperty("summary_text").GetString();
            }
            else
            {
                model.Summary = "Error summarizing text.";
            }

            return View("Result", model);
        }
    }
}

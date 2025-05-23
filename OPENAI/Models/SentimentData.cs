using Microsoft.AspNetCore.Http;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIProject.Models
{
    /// <summary>
    /// SentimentData model
    /// Model for CSV file to import
    /// </summary>
    public class SentimentData
    {
        [LoadColumn(0)]
        public string Text { get; set; }
        [LoadColumn(1), ColumnName("Label")]
        public bool Label { get; set; }
    }

    public class SentimentPrediction
    {
        public string Text { get; set; }

        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }
        public float Probability { get; set; }
    }
}

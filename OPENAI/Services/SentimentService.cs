using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.Text;
using AIProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AIProject.Services
{
    public class SentimentService
    {
        private readonly MLContext _mlContext;
        private ITransformer _model;

        public SentimentService()
        {
            _mlContext = new MLContext();
        }

        /// <summary>
        /// Gets file path to reach the file
        /// Uses Logistic Regression to train the model with the data in file
        /// </summary>
        /// <param name="dataPath"></param>
        /// <returns>trained model</returns>
        public ITransformer TrainModel(string dataPath)
        {
            // Load the CSV file into IDataView
            IDataView data = _mlContext.Data.LoadFromTextFile<SentimentData>(dataPath, separatorChar: ',', hasHeader: true);

            // Define a pipeline for text featurization (converting text to numerical features)
            var pipeline = _mlContext.Transforms.Text.FeaturizeText("Features", nameof(SentimentData.Text))
                .Append(_mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(
                    labelColumnName: nameof(SentimentData.Label),
                   featureColumnName: "Features"));

            // Train the model
            _model = pipeline.Fit(data);
            return _model;
        }

        /// <summary>
        /// Makes prediction based on trained model for each Text input
        /// </summary>
        /// <param name="model"></param>
        /// <returns>SentimentPrediction</returns>
        public SentimentPrediction PredictSentiment(SentimentData model)
        {
            var predictionEngine = _mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(_model);
            var prediction = predictionEngine.Predict(model);

            return prediction;
        }
    }
}

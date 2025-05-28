using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIProject.Services
{
    using AIProject.Models;
    using Microsoft.ML;
    using Microsoft.ML.Data;
    using System;
    using System.IO;

    public class FraudService
    {
        private readonly string _modelPath = Path.Combine(Environment.CurrentDirectory, "MLModel.zip");
        private readonly MLContext _mlContext;
        private ITransformer _model;

        public FraudService()
        {
            _mlContext = new MLContext(seed: 0);
            if (File.Exists(_modelPath))
                _model = _mlContext.Model.Load(_modelPath, out _);
        }

        public void Train(string dataPath)
        {
            var dataView = _mlContext.Data.LoadFromTextFile<TransactionData>(dataPath, hasHeader: true, separatorChar: ',');

            // Data process pipeline
            var pipeline = _mlContext.Transforms.Categorical.OneHotEncoding(new[]
                {
                new InputOutputColumnPair("MerchantCategoryEncoded", "MerchantCategory"),
                new InputOutputColumnPair("LocationEncoded", "Location"),
                new InputOutputColumnPair("TransactionTypeEncoded", "TransactionType"),
            })
                .Append(_mlContext.Transforms.Concatenate("Features",
                    "Amount", "HourOfDay", "HistoricalAvgAmount", "NumTransactionsLast24h",
                    "MerchantCategoryEncoded", "LocationEncoded", "TransactionTypeEncoded"))
                    .Append(_mlContext.BinaryClassification.Trainers.FastForest(
            labelColumnName: "IsFraud",
            featureColumnName: "Features"));

            _model = pipeline.Fit(dataView);
            _mlContext.Model.Save(_model, dataView.Schema, _modelPath);
        }

        public TransactionPrediction Predict(TransactionData transaction)
        {
            if (_model == null)
                throw new Exception("Model not trained.");

            var predEngine = _mlContext.Model.CreatePredictionEngine<TransactionData, TransactionPrediction>(_model);
            return predEngine.Predict(transaction);
        }
    }
}

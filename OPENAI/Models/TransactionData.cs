using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIProject.Models
{
    using Microsoft.ML.Data;

    public class TransactionData
    {
        [LoadColumn(0)]
        public string TransactionId;

        [LoadColumn(1)]
        public float Amount;

        [LoadColumn(2)]
        public float HourOfDay;

        [LoadColumn(3)]
        public string MerchantCategory;

        [LoadColumn(4)]
        public string Location;

        [LoadColumn(5)]
        public string TransactionType;

        [LoadColumn(6)]
        public float HistoricalAvgAmount;

        [LoadColumn(7)]
        public float NumTransactionsLast24h;

        [LoadColumn(8)]
        public bool IsFraud;
    }

    public class TransactionPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool IsFraud;

        public float Score;
    }
}

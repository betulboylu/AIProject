using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIProject.Models
{
    public class TransactionResultViewModel
    {
        public string TransactionId { get; set; }
        public float Amount { get; set; }
        public float HourOfDay { get; set; }
        public string MerchantCategory { get; set; }
        public string Location { get; set; }
        public string TransactionType { get; set; }
        public float HistoricalAvgAmount { get; set; }
        public float NumTransactionsLast24h { get; set; }
        public bool IsFraudPredicted { get; set; }
        public float Score { get; set; }
    }
}

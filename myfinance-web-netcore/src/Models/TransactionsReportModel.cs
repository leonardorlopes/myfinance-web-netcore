using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfinance_web_netcore.Models
{
    public class TransactionsReportModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<TransactionModel> Transactions { get; set; }
        public int CountIncomeTransactions { get; set; }
        public int CountExpensesTransactions { get; set; }

        public TransactionsReportModel()
        {
            Transactions = new List<TransactionModel>();
        }
    }
}
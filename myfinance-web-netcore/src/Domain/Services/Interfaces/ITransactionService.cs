using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Domain.Services.Interfaces
{
    public interface ITransactionService
    {
        List<TransactionModel> GetAll();
        TransactionModel Get(int id);
        void Save(TransactionModel transactionModel);
        void Delete(int id);
        TransactionsReportModel GetAllByPeriod(DateTime dataInicio, DateTime dataFim);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain.Entities;
using myfinance_web_netcore.Domain.Services.Interfaces;
using myfinance_web_netcore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_netcore.Domain.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly MyFinanceDbContext _dbContext;

        public TransactionService(MyFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TransactionModel> GetAll()
        {
            var dbSet = _dbContext.Transacao.Include(x => x.PlanoConta);
            List<TransactionModel> transactionList = new List<TransactionModel>();

            foreach (var item in dbSet)
            {
                transactionList.Add(new TransactionModel
                {
                    Id = item.Id,
                    DateTransaction = item.Data,
                    History = item.Historico,
                    Value = item.Valor,
                    AccountPlanTransaction =
                        new AccountPlanModel
                        {
                            Id = item.PlanoConta.Id,
                            Description = item.PlanoConta.Descricao,
                            Type = item.PlanoConta.Tipo
                        },
                    AccountPlanId = (int)item.PlanoConta.Id,
                });
            }
            return transactionList;
        }

        public TransactionModel Get(int id)
        {
            var dbSet = _dbContext.Transacao
                .Where(x => x.Id.Equals(id))
                .First();

            return new TransactionModel
            {
                Id = dbSet.Id,
                DateTransaction = dbSet.Data,
                History = dbSet.Historico,
                Value = dbSet.Valor,
                AccountPlanId = dbSet.PlanoContaId
            };
        }

        public void Save(TransactionModel transaction)
        {
            var dbSet = _dbContext.Transacao;

            var entity = new Transacao()
            {
                Id = transaction.Id,
                Data = transaction.DateTransaction,
                Historico = transaction.History,
                Valor = transaction.Value,
                PlanoContaId = transaction.AccountPlanId
            };

            if (entity.Id == null)
            {
                dbSet.Add(entity);
            }
            else
            {
                dbSet.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
            }

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var accountPlan = _dbContext.Transacao
                .Where(x => x.Id.Equals(id))
                .First();

            _dbContext.Attach(accountPlan);
            _dbContext.Remove(accountPlan);
            _dbContext.SaveChanges();
        }

        public TransactionsReportModel GetAllByPeriod(DateTime startDate, DateTime endDate)
        {

            var dbSet = _dbContext.Transacao
                .Include(x => x.PlanoConta)
                .Where(x => x.Data >= startDate.Date && x.Data <= endDate.Date);

            List<TransactionModel> transactionList = new List<TransactionModel>();

            foreach (var item in dbSet)
            {
                transactionList.Add(new TransactionModel
                {
                    Id = item.Id,
                    DateTransaction = item.Data,
                    History = item.Historico,
                    Value = item.Valor,
                    AccountPlanTransaction =
                        new AccountPlanModel
                        {
                            Id = item.PlanoConta.Id,
                            Description = item.PlanoConta.Descricao,
                            Type = item.PlanoConta.Tipo
                        },
                    AccountPlanId = (int)item.PlanoConta.Id,
                    AccountPlanType = item.PlanoConta.Tipo
                });
            }

            TransactionsReportModel reports = new TransactionsReportModel();
            reports.StartDate = startDate;
            reports.EndDate = endDate;
            reports.Transactions = transactionList;
            reports.CountIncomeTransactions = transactionList
                .Where(x => x.AccountPlanType.Equals("R"))
                .ToList()
                .Count();
            reports.CountExpensesTransactions = transactionList
                .Where(x => x.AccountPlanType.Equals("D"))
                .ToList()
                .Count();
            return reports;
        }
    }
}
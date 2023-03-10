using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain.Entities;
using myfinance_web_netcore.Domain.Services.Interfaces;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Domain.Services
{
    public class AccountPlanService : IAccountPlanService
    {
        private readonly MyFinanceDbContext _dbContext;

        public AccountPlanService(MyFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<AccountPlanModel> GetAll()
        {
            var dbSet = _dbContext.PlanoConta;
            List<AccountPlanModel> accountPlanModelList = new List<AccountPlanModel>();

            foreach (var item in dbSet)
            {
                accountPlanModelList.Add(new AccountPlanModel
                {
                    Id = item.Id,
                    Description = item.Descricao,
                    Type = item.Tipo
                });
            }
            return accountPlanModelList;
        }

        public AccountPlanModel Get(int id)
        {
            var dbSet = _dbContext.PlanoConta.Where(x => x.Id.Equals(id)).First();
            return new AccountPlanModel
            {
                Id = dbSet.Id,
                Description = dbSet.Descricao,
                Type = dbSet.Tipo
            };
        }

        public void Save(AccountPlanModel accountPlanModel)
        {
            var dbSet = _dbContext.PlanoConta;
            var entity = new PlanoConta()
            {
                Id = accountPlanModel.Id,
                Descricao = accountPlanModel.Description,
                Tipo = accountPlanModel.Type
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
            var accountPlan = _dbContext.PlanoConta.Where(x => x.Id.Equals(id)).First();
            _dbContext.Attach(accountPlan);
            _dbContext.Remove(accountPlan);
            _dbContext.SaveChanges();
        }
    }
}
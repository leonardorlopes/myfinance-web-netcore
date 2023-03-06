using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain.Entities;
using myfinance_web_netcore.Domain.Services.Interfaces;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Domain.Services
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly MyFinanceDbContext _dbContext;

        public PlanoContaService(MyFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<PlanoContaModel> GetAll()
        {
            var dbSet = _dbContext.PlanoConta;
            List<PlanoContaModel> planoContaModelList = new List<PlanoContaModel>();

            foreach (var item in dbSet)
            {
                planoContaModelList.Add(new PlanoContaModel
                {
                    Id = item.Id,
                    Descricao = item.Descricao,
                    Tipo = item.Tipo
                });
            }
            return planoContaModelList;
        }

        public PlanoContaModel Get(int id)
        {
            var dbSet = _dbContext.PlanoConta.Where(x => x.Id.Equals(id)).First();
            return new PlanoContaModel
            {
                Id = dbSet.Id,
                Descricao = dbSet.Descricao,
                Tipo = dbSet.Tipo
            };
        }

        public void Save(PlanoContaModel planoContaModel)
        {
            var dbSet = _dbContext.PlanoConta;
            var entity = new PlanoConta()
            {
                Id = planoContaModel.Id,
                Descricao = planoContaModel.Descricao,
                Tipo = planoContaModel.Tipo
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
            var planoConta = Get(id);
            _dbContext.Attach(planoConta);
            _dbContext.Remove(planoConta);
            _dbContext.SaveChanges();
        }
    }
}
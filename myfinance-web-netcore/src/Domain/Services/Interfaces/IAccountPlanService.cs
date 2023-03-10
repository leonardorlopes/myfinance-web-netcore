using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Domain.Services.Interfaces
{
    public interface IAccountPlanService
    {
        List<AccountPlanModel> GetAll();
        AccountPlanModel Get(int id);
        void Save(AccountPlanModel accountPlanModel);
        void Delete(int id);
    }
}
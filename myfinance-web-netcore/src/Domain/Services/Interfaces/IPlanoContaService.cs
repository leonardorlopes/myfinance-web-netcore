using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Domain.Services.Interfaces
{
    public interface IPlanoContaService
    {
        List<PlanoContaModel> GetAll();
        PlanoContaModel Get(int id);
        void Save(PlanoContaModel planoContaModel);
        void Delete(int id);
    }
}
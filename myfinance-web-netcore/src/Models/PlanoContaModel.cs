using myfinance_web_netcore.Domain.Entities;

namespace myfinance_web_netcore.Models
{
    public class PlanoContaModel
    {
        public int? Id { get; set; }
        public string? Descricao { get; set; }
        public string? Tipo { get; set; }

        public PlanoContaModel() { }
        
    }
}
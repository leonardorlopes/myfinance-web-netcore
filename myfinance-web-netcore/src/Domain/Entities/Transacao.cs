namespace myfinance_web_netcore.Domain.Entities
{
    public class Transacao
    {
        public int? Id { get; set; }
        public DateTime Data { get; set; }
        public Decimal Valor { get; set; }
        public String? Historico { get; set; }
        public PlanoConta PlanoConta { get; set; }
        public int PlanoContaId {get; set;}
    }
}
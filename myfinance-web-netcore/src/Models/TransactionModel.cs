using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_netcore.Models
{
    public class TransactionModel
    {
        public int? Id { get; set; }
        public DateTime DateTransaction { get; set; }
        public Decimal Value { get; set; }
        public String? History { get; set; }
        public int AccountPlanId { get; set; }
        public String AccountPlanType {get; set;}
        public AccountPlanModel AccountPlanTransaction { get; set; }
        public IEnumerable<SelectListItem>? AccountPlans { get; set; }
    }
}
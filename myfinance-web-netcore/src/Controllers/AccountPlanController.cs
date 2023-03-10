using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Domain.Services.Interfaces;

namespace myfinance_web_netcore.Controllers
{
    [Route("[controller]")]
    public class AccountPlanController : Controller
    {
        private readonly ILogger<AccountPlanController> _logger;
        private readonly IAccountPlanService _service;

        public AccountPlanController(ILogger<AccountPlanController> logger,
        IAccountPlanService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.ListAccountPlan = _service.GetAll();
            return View();
        }

        [HttpGet]
        [Route("Register")]
        [Route("Register/{id}")]
        public IActionResult Register(int? id)
        {
            if (id != null)
            {
                var accountPlan = _service.Get((int)id);
                return View(accountPlan);
            }
            return View();
        }

        [HttpPost]
        [Route("Register")]
        [Route("Register/{id}")]
        public IActionResult Register(AccountPlanModel model)
        {
            _service.Save(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
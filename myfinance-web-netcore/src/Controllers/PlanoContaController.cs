using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Domain.Services.Interfaces;

namespace myfinance_web_netcore.Controllers
{
    [Route("[controller]")]
    public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;
        private readonly IPlanoContaService _service;

        public PlanoContaController(ILogger<PlanoContaController> logger,
        IPlanoContaService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.ListPlanoConta = _service.GetAll();
            return View();
        }

        [HttpGet]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(int? id)
        {
            if (id != null)
            {
                var planoConta = _service.Get((int)id);
                return View(planoConta);
            }
            return View();
        }

        [HttpPost]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(PlanoContaModel model)
        {
            _service.Save(model);
            return RedirectToAction("Index");
        }        

        [HttpPost]        
        [Route("Excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
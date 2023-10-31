using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Services;
using CurrentXpose_Admin.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CurrentXpose_Admin.Controllers
{
    public class PredioController : Controller
    {
        private readonly IPredioService _predioService;

        public PredioController(IPredioService predioService)
        {
            _predioService = predioService;
        }

        public IActionResult Index()
        {
            var predios =  _predioService.ObterPredios();
            return View(predios);
        }
    }
}

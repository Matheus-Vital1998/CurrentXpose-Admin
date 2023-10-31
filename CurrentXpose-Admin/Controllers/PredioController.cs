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

        public async Task<IActionResult> Lista()
        {
            var predios = await _predioService.ObterPredios();
            return View(predios);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Excluir()
        {
            return View();
        }
    }
}

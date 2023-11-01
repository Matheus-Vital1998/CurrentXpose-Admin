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

        [HttpPost]
        public async Task<IActionResult> Cadastro(Predio novoPredio)
        {
            if (ModelState.IsValid)
            {
                await _predioService.InserirPredio(novoPredio);
                return RedirectToAction(nameof(Lista));
            }

            return View(novoPredio);
        }

        public IActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Predio predioEditado)
        {
            if (ModelState.IsValid)
            {
                await _predioService.AtualizarPredio(predioEditado);
                return RedirectToAction(nameof(Lista));
            }

            return View(predioEditado);
        }

        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Excluir()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int predioId)
        {
            await _predioService.ExcluirPredio(predioId);
            return RedirectToAction(nameof(Lista));
        }
    }
}
using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Services;
using CurrentXpose_Admin.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CurrentXpose_Admin.Controllers
{
    [Authorize]
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
            await _predioService.InserirPredio(novoPredio);
            return RedirectToAction(nameof(Lista));
        }

        public async Task<IActionResult> Editar(int id)
        {
            var predios = await _predioService.DetalhesPredio(id);
            return View(predios);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Predio predioEditado)
        {
            await _predioService.AtualizarPredio(predioEditado);
            return RedirectToAction(nameof(Lista));

        }

        public async Task <IActionResult> Detalhes(int id)
        {
            var predios = await _predioService.DetalhesPredio(id);
            return View(predios);
        }

        public async Task <IActionResult> Excluir(int id)
        {
            var predios = await _predioService.DetalhesPredio(id);
            return View(predios);
        }

        [HttpPost]
        public async Task<IActionResult> Deletar(int id)
        {
            await _predioService.ExcluirPredio(id);
            return RedirectToAction("Lista");
        }
    }
}
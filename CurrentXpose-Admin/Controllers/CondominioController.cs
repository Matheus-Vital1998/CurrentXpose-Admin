using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Services;
using CurrentXpose_Admin.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CurrentXpose_Admin.Controllers
{
    [Authorize]
    public class CondominioController : Controller
    {
        private readonly ICondominioService _condominioService;

        public CondominioController(ICondominioService condominioService)
        {
            _condominioService = condominioService;
        }

        public async Task<IActionResult> Lista()
        {
            var condominios = await _condominioService.ObterCondominios();
            return View(condominios);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(Condominio condominio)
        {
            await _condominioService.InserirCondominio(condominio);
            return RedirectToAction("Lista");
        }

        public async Task<IActionResult> Editar(int id)
        {
            var condominio = await _condominioService.DetalhesCondominio(id);
            return View(condominio);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Condominio condominio)
        {
            await _condominioService.AtualizarCondominio(condominio);
            return RedirectToAction("Lista");
        }

        public async Task<IActionResult> Detalhes(int id)
        {
            var condominio = await _condominioService.DetalhesCondominio(id);
            return View(condominio);
        }

        public async Task <IActionResult> Excluir(int id)
        {
            var condominio = await _condominioService.DetalhesCondominio(id);
            return View(condominio);
        }

        [HttpPost]
        public async Task<IActionResult> Deletar(int id)
        {
            await _condominioService.ExcluirCondominio(id);
            return RedirectToAction("Lista");
        }
    }

}

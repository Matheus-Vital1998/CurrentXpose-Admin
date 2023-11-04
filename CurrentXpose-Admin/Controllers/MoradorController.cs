using CurrentXpose_Admin.Entidades;
using CurrentXpose_Admin.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CurrentXpose_Admin.Controllers
{
    [Authorize]
    public class MoradorController : Controller
    {
        private readonly IMoradorService _moradorService;

        public MoradorController(IMoradorService moradorService)
        {
            _moradorService = moradorService;
        }

        public async Task<IActionResult> Lista()
        {
            var moradores = await _moradorService.ObterMoradores();
            return View(moradores);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(Morador novoMorador)
        {
            await _moradorService.InserirMorador(novoMorador);
            return RedirectToAction("Lista");
        }

        public async Task<IActionResult> Editar(int id)
        {
            var morador = await _moradorService.DetalhesMorador(id);
            return View(morador);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Morador moradorEditado)
        {
            await _moradorService.AtualizarMorador(moradorEditado);
            return RedirectToAction("Lista");
        }

        public async Task<IActionResult> Detalhes(int id)
        {
            var morador = await _moradorService.DetalhesMorador(id);
            return View(morador);
        }

        public async Task<IActionResult> Excluir(int id)
        {
            var morador = await _moradorService.DetalhesMorador(id);
            return View(morador);
        }

        [HttpPost]
        public async Task<IActionResult> Deletar(int id)
        {
            await _moradorService.ExcluirMorador(id);
            return RedirectToAction("Lista");
        }
    }
}
